using BlackBoards;
using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public partial class BlackBoardsContext : DbContext
    {
        public BlackBoardsContext()
            : base("name=BlackBoardsContextConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<BlackBoard> blackBoards { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<EstablishedScoreTeam> establishedScoresTeam { get; set; }
        public DbSet<ScoreUserInTeam> scoresUserInTeam { get; set; }
        public DbSet<Connection> connexions { get; set; }
    }
}
