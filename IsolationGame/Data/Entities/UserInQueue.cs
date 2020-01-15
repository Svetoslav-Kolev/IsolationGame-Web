using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsolationGame.Data.Entities
{
    public class UserInQueue
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string GameId { get; set; }
    }
}
