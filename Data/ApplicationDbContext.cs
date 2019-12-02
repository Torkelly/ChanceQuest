using System;
using System.Collections.Generic;
using System.Text;
using ChanceQuest.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChanceQuest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Quest> Quests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=tcp:chance-quest-server.database.windows.net,1433;Initial Catalog=ChanceQuestDB;Persist Security Info=False;User ID=CQAdmin;Password=Quest1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
