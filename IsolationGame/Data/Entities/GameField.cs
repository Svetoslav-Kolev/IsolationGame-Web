using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsolationGame.Data.Entities
{
    public class GameField
    {
        public Guid Id { get; set; }
        public string PlayerOneId { get; set; }
        public string PlayerTwoId { get; set; }
        public string Field { get; set; }
        public byte CurrentPlayerAndTurn { get; set; }
        public bool PlayerOneWon { get; set; }
        public bool IsRematch { get; set; }
        public string PreviousPlayerOneId { get; set; }
        public string PreviousPlayerTwoId { get; set; }
    }
}
