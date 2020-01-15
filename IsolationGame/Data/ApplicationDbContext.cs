using System;
using System.Collections.Generic;
using System.Text;
using IsolationGame.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IsolationGame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public DbSet<GameField> games;
        //public DbSet<UserInQueue> Queue;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //games = this.Set<GameField>();
            //Queue = this.Set<UserInQueue>();
        }
        public DbSet<GameField> Games { get; set; }
        public DbSet<UserInQueue> Queue { get; set; }
    }
}
