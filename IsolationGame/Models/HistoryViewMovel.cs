using IsolationGame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsolationGame.Models
{
    public class HistoryViewMovel
    {
       public List<GameField> games { get; set; }
       public string userId { get; set; }
       public Dictionary<string, string> enemyUsernames { get; set; }
    }
}
