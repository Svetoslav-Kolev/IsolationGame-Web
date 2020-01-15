using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IsolationGame.Models;
using Newtonsoft.Json;
using IsolationGame.Data;
using System.Security.Claims;
using IsolationGame.Data.Entities;

namespace IsolationGame.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                DeleteInactiveGames();
            }
            return View();
        }

        public IActionResult HowToPlay()
        {


            return View();
        }
        public IActionResult History()
        {
            HistoryViewMovel hvm = new HistoryViewMovel();
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Dictionary<string, string> enemyUsernames = new Dictionary<string, string>();
            hvm.games = _context.Games.Where(g => g.PlayerOneId == userId || g.PlayerTwoId == userId).ToList();
            hvm.userId = userId;
            foreach (var game in hvm.games)
            {
                if(game.PlayerOneId == userId)
                {
                    enemyUsernames[game.Id.ToString()] = _context.Users.Where(u => u.Id == game.PlayerTwoId).FirstOrDefault().UserName;
                }
                else
                {
                    enemyUsernames[game.Id.ToString()] = _context.Users.Where(u => u.Id == game.PlayerOneId).FirstOrDefault().UserName;
                }
            }
            hvm.enemyUsernames = enemyUsernames;
            return View(hvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void DeleteInactiveGames()
        {
            string yourId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            foreach (var game in _context.Games.Where(g => (g.PlayerOneId == yourId && g.PlayerTwoId == null) || (g.PlayerTwoId == yourId && g.PlayerOneId == null)))
            {        
                _context.Games.Remove(game);           
            }
            foreach (var queuedUp in _context.Queue.Where(u => u.UserId == yourId))
            {
                _context.Queue.Remove(queuedUp);
            }
            _context.SaveChanges();
            
        }
    }
}
