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
            modelBuilder.Entity<User>()
              .HasMany<Team>(s => s.belongInteams)
              .WithMany(c => c.members)
              .Map(cs =>
              {
                  cs.MapLeftKey("IDUser");
                  cs.MapRightKey("IDTeam");
                  cs.ToTable("Members");
              });
            modelBuilder.Entity<ScoreUserInTeam>()
                .HasRequired<Team>(s => s.theTeam) // BlackBoard entity requires Team 
                .WithMany(s => s.scoresOfUsers)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<BlackBoard>()
                  .HasRequired<Team>(s => s.teamBelongs) // BlackBoard entity requires Team 
                  .WithMany(s => s.boards)
                  .WillCascadeOnDelete(false);
            modelBuilder.Entity<EstablishedScoreTeam>()
                              .HasRequired<Team>(s => s.teamScore) // Mark Address property optional in Student entity
                              .WithRequiredDependent(ad => ad.EstablishedScoreTeam); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Stude
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
