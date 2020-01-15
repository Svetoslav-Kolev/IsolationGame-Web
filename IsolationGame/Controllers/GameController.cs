using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsolationGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using IsolationGame.Extensions;
using IsolationGame.Data;
using Microsoft.EntityFrameworkCore;
using IsolationGame.Data.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace IsolationGame.Controllers
{
    public class GameController : Controller
    {

        static Random rnd = new Random();
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Play()
        {
            ViewData["Message"] = "Game";

            int queueCount = _context.Queue.Count();
            List<UserInQueue> allplayersInQueue = _context.Queue.ToList();
            List<GameField> allGamesInQueue = new List<GameField>();
            bool existsNonRematchedGame = false;
            foreach (var player in allplayersInQueue)
            {
                GameField currGame = _context.Games.Where(g => g.Id.ToString() == player.GameId).FirstOrDefault();
                if(currGame.IsRematch == false)
                {
                    existsNonRematchedGame = true;
                }
            } 
            if (!existsNonRematchedGame)
            {
                CreateGame();
            }
            else
            {
                List<UserInQueue> playersInQueue = _context.Queue.ToList();
                foreach (var player in playersInQueue)
                {
                    GameField currGame = _context.Games.Where(g => g.Id.ToString() == player.GameId).FirstOrDefault();
                    if (currGame.IsRematch == false)
                    {
                        _context.Queue.Remove(player);

                        currGame.PlayerTwoId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        ViewData["PlayerOneOrTwo"] = "Your are player two , indicated on the field by - P2";
                        HttpContext.Session.SetString("GameId", currGame.Id.ToString());
                        _context.SaveChanges();

                    }
                }  
            }

            ViewData["CurrentPlayerId"] = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewData["GameId"] = HttpContext.Session.GetString("GameId");

            return View();
        }

        public IActionResult PlayAsGuest()
        {

            MatrixViewModel mvm = new MatrixViewModel(7);
            ViewData["Message"] = "Game";
            IdentityUser guestUser = new IdentityUser();
            

            return View(mvm);
        }
        public IActionResult Action(string coordinates)
        {
            bool yourTurn = CheckTurn();

            if (yourTurn == true)
            {
                var game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
                if (game.CurrentPlayerAndTurn == 0 || game.CurrentPlayerAndTurn == 2)
                {

                    if (Move(coordinates))
                    {
                        if (game.CurrentPlayerAndTurn == 0)
                        {
                            _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 1;
                        }
                        else if(game.CurrentPlayerAndTurn == 2)
                        {
                            _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 3;
                        }

                        _context.SaveChanges();
                    }

                }
                else
                {
                    if (PossibleToBlock(JsonConvert.DeserializeObject<int[,]>(game.Field), coordinates))
                    {
                        BlockField(coordinates);
                        if (game.CurrentPlayerAndTurn == 3)
                        {
                            _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 0;
                        }
                        else if(game.CurrentPlayerAndTurn == 1)
                        {
                            _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 2;
                        }
                        _context.SaveChanges();
                    }

                }

            }

            return new EmptyResult();
        }
        public bool Move(string coordinates)
        {
            MatrixViewModel mvm = new MatrixViewModel(7);

            var game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            var field = JsonConvert.DeserializeObject<int[,]>(game.Field);
            mvm.Field = field;
            for (int i = 0; i < mvm.Field.GetLength(0); i++)
            {
                for (int j = 0; j < mvm.Field.GetLength(1); j++)
                {
                    if (mvm.Field[i, j] == 2)
                    {
                        mvm.PlayerOneCoordinates = $"{i}_{j}";
                    }
                    else if (mvm.Field[i, j] == 3)
                    {
                        mvm.PlayerTwoCoordinates = $"{i}_{j}";
                    }
                }
            }

            string[] coords = coordinates.Split('_').ToArray();
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            int playerMoving;
            string[] playerCoordinates = new string[2];
            if (game.PlayerOneId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                playerCoordinates = mvm.PlayerOneCoordinates.Split('_').ToArray();
                playerMoving = 2;
            }
            else
            {
                playerCoordinates = mvm.PlayerTwoCoordinates.Split('_').ToArray();
                playerMoving = 3;
            }
            //check if available

            if (InRangeToMove(mvm, playerCoordinates[0] + "_" + playerCoordinates[1], x + "_" + y))
            {
                if (mvm.Field[x, y] == 0)
                {
                    int coordX = int.Parse(playerCoordinates[0]);
                    int coordY = int.Parse(playerCoordinates[1]);
                    mvm.Field[coordX, coordY] = 0;
                    mvm.Field[x, y] = playerMoving;
                    _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().Field = JsonConvert.SerializeObject(mvm.Field);
                    _context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            //if (game.PlayerOneId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            //{
            //    if (CheckIfLost(mvm, mvm.PlayerTwoCoordinates))
            //    {
            //        _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 5;
            //        _context.SaveChanges();


            //    }
            //}
            //if (game.PlayerTwoId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            //{
            //    if (CheckIfLost(mvm, mvm.PlayerOneCoordinates))
            //    {
            //        _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 6;
            //        _context.SaveChanges();


            //    }
            //}

            return true;
            
        }
        private bool InRangeToMove(MatrixViewModel game, string playerCoord, string coordsToMove)
        {
            var gameInContext = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            game.Field = JsonConvert.DeserializeObject<int[,]>(gameInContext.Field);
            int[] playerCoordinates = playerCoord.Split('_').Select(int.Parse).ToArray();
            int playerX = playerCoordinates[0];
            int playerY = playerCoordinates[1];
            List<string> closestCells = new List<string>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (InRange(game, playerX + i, playerY + j))
                    {
                        int secondCoord = playerY + j;
                        closestCells.Add(playerX + i + "_" + secondCoord);
                    }
                }
            }
            if (closestCells.Contains(coordsToMove))
            {
                return true;
            }
            return false;
        }
        private bool CheckIfLost(MatrixViewModel game, string playerCoord)
        {

            var gameInContext = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            game.Field = JsonConvert.DeserializeObject<int[,]>(gameInContext.Field);
            int[] playerCoordinates = playerCoord.Split('_').Select(int.Parse).ToArray();
            int playerX = playerCoordinates[0];
            int playerY = playerCoordinates[1];
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (InRange(game, playerX + i, playerY + j) && game.Field[playerX + i, playerY + j] == 0)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
        private bool InRange(MatrixViewModel game, int x, int y)
        {
            if (x < 0 || x >= game.Field.GetLength(0) || y < 0 || y >= game.Field.GetLength(1))
            {
                return false;
            }

            return true;
        }
        public bool CheckTurn()
        {
            bool yourTurn = false;
            var game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            if (game.PlayerOneId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                if (game.CurrentPlayerAndTurn == 1 || game.CurrentPlayerAndTurn == 0)
                {
                    yourTurn = true;
                }

            }
            else if (game.PlayerTwoId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {

                if (game.CurrentPlayerAndTurn == 2 || game.CurrentPlayerAndTurn == 3)
                {
                    yourTurn = true;
                }
            }
            else
            {
                yourTurn = false;
            }
            return yourTurn;
        }
        public IActionResult BlockField(string coordinates)
        {
            MatrixViewModel mvm = new MatrixViewModel(7);
            var game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            var field = JsonConvert.DeserializeObject<int[,]>(game.Field);
            mvm.Field = field;
            for (int i = 0; i < mvm.Field.GetLength(0); i++)
            {
                for (int j = 0; j < mvm.Field.GetLength(1); j++)
                {
                    if (mvm.Field[i, j] == 2)
                    {
                        mvm.PlayerOneCoordinates = $"{i}_{j}";
                    }
                    else if (mvm.Field[i, j] == 3)
                    {
                        mvm.PlayerTwoCoordinates = $"{i}_{j}";
                    }
                }
            }
            string[] coords = coordinates.Split('_').ToArray();
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);


            mvm.Field[x, y] = 1;
            _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().Field = JsonConvert.SerializeObject(mvm.Field);
            _context.SaveChanges();

            if (game.PlayerOneId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                if (CheckIfLost(mvm, mvm.PlayerTwoCoordinates))
                {
                    _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 5;
                    _context.SaveChanges();
                    
                }
            }
            if (game.PlayerTwoId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                if (CheckIfLost(mvm, mvm.PlayerOneCoordinates))
                {
                    _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault().CurrentPlayerAndTurn = 6;
                    _context.SaveChanges();
                     
                }
            }
            return new EmptyResult();
        }
        public bool PossibleToBlock(int[,] field, string coordinates)
        {
            string[] coords = coordinates.Split('_').ToArray();
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            if (field[x, y] == 0)
            {

                return true;
            }
            return false;
        }
        public IActionResult EndGame()
        {
            GameField game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            if (game.PlayerOneId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                if (game.CurrentPlayerAndTurn == 5)
                {
                    ViewData["gameWinner"] = "You Won The Game!";
                }
                else
                {
                    ViewData["gameWinner"] = "You Lost The Game!";
                }
            }
            else if (game.PlayerTwoId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                if (game.CurrentPlayerAndTurn == 6)
                {
                    ViewData["gameWinner"] = "You Won The Game!";
                }
                else
                {
                    ViewData["gameWinner"] = "You Lost The Game!";
                }
            }

            return View();

        }
        public IActionResult Rematch()
        {
            GameField game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            UserInQueue queuedUser = _context.Queue.Where(g => g.UserId == getOppenentId(game)).FirstOrDefault();
            if (queuedUser == null)
            {
                GameField rematchedGame = CreateGame();
                //rematchedGame.PreviousPlayerOneId = game.PlayerOneId;
                //rematchedGame.PreviousPlayerTwoId = game.PlayerTwoId;
                //rematchedGame.IsRematch = true;
                _context.Games.Where(g => g.Id == rematchedGame.Id).FirstOrDefault().IsRematch = true;
                _context.Games.Where(g => g.Id == rematchedGame.Id).FirstOrDefault().PreviousPlayerOneId = game.PlayerOneId;
                _context.Games.Where(g => g.Id == rematchedGame.Id).FirstOrDefault().PreviousPlayerTwoId = game.PlayerTwoId;
                _context.SaveChanges();
            }
            else
            {
                string yourId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                GameField rematchedGame = _context.Games.Where(g => g.PreviousPlayerOneId == yourId && g.PlayerTwoId ==null|| g.PreviousPlayerTwoId == yourId && g.PlayerTwoId == null).FirstOrDefault();
                rematchedGame.PlayerTwoId = yourId;
                UserInQueue rematchedPlayer = _context.Queue.Where(u => u.GameId == rematchedGame.Id.ToString()).FirstOrDefault();
                ViewData["PlayerOneOrTwo"] = "Your are player two , indicated on the field by - P2";
                HttpContext.Session.SetString("GameId", rematchedGame.Id.ToString());
                _context.Queue.Remove(rematchedPlayer);
                _context.SaveChanges();
            }
            return View();
        }
        public JsonResult Update()
        {
            var game = _context.Games.Where(g => g.Id.ToString() == HttpContext.Session.GetString("GameId")).FirstOrDefault();
            return Json(game);
        }
        private string getOppenentId(GameField game)
        {
            if (game.PlayerTwoId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                return game.PlayerTwoId;
            }
            else
            {
                return game.PlayerOneId;
            }
        }
        private GameField CreateGame()
        {
            MatrixViewModel mvm = new MatrixViewModel(7);
            GameField currGame = new GameField();
            currGame.Id = new Guid();
            currGame.PlayerOneId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            currGame.Field = JsonConvert.SerializeObject(mvm.Field);
            byte[] startingTurn = new byte[2];
            startingTurn[0] = 0;
            startingTurn[1] = 2;

            currGame.CurrentPlayerAndTurn = startingTurn[rnd.Next(0, 2)];

            _context.Games.Add(currGame);
            _context.SaveChanges();

            UserInQueue newUser = new UserInQueue();
            newUser.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            newUser.GameId = currGame.Id.ToString();
            ViewData["PlayerOneOrTwo"] = "Your are player one , indicated on the field by - P1";
            HttpContext.Session.SetString("GameId", currGame.Id.ToString());
            _context.Queue.Add(newUser);
            _context.SaveChanges();
            return currGame;
        }

    }


    //public static class SessionExtensions
    //{
    //    public static void SetObjectAsJson(this ISession session, string key, object value)
    //    {
    //        session.SetString(key, JsonConvert.SerializeObject(value));
    //    }

    //    public static T GetObjectFromJson<T>(this ISession session, string key)
    //    {
    //        var value = session.GetString(key);
    //        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    //    }
    //}
}