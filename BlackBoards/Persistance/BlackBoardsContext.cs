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
            this.Configuration.LazyLoadingEnabled = false;
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
                     .HasRequired<User>(s => s.theUser) // BlackBoard entity requires Team 
                     .WithMany(s => s.scoresInTeams)
                     .WillCascadeOnDelete(false);  // Team entity includes many BlackBoard entities
            modelBuilder.Entity<ScoreUserInTeam>()
                  .HasRequired<Team>(s => s.theTeam) // BlackBoard entity requires Team 
                  .WithMany(s => s.scoresOfUsers)
                  .WillCascadeOnDelete(false);  // Team entity includes many BlackBoard entities
            modelBuilder.Entity<BlackBoard>()
                     .HasRequired<Team>(s => s.teamBelongs) // BlackBoard entity requires Team 
                     .WithMany(s => s.boards)
                     .WillCascadeOnDelete(false); ; // Team entity includes many BlackBoard entities
            modelBuilder.Entity<Item>()
                     .HasRequired<BlackBoard>(s => s.blackBoardBelongs) // Item entity requires BlackBoard 
                     .WithMany(s => s.itemList)
                     .WillCascadeOnDelete(false);  // BlackBoard entity includes many Item entities
            modelBuilder.Entity<Comment>()
                     .HasRequired<Item>(s => s.itemBelong) // Comment entity requires Item 
                     .WithMany(s => s.comments)
                     .WillCascadeOnDelete(false);  // Item entity includes many Comment entities
            modelBuilder.Entity<Comment>()
                  .HasRequired<User>(s => s.resolvingUser) // Comment entity requires User 
                  .WithMany(s => s.resolvedComments) // User entity includes many Comment entities
            .HasForeignKey(s => s.resolvingUserID)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>()
                 .HasRequired<User>(s => s.commentingUser) // Comment entity requires User 
                 .WithMany(s => s.createdComments) // User entity includes many Comment entities
               .HasForeignKey(s => s.commentingUserID)
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<Connection>()
                        .HasOptional<Item>(s => s.to) // Mark Address property optional in Student entity
                        .WithRequired(ad => ad.to); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
            modelBuilder.Entity<Connection>()
                                .HasOptional<Item>(s => s.from) // Mark Address property optional in Student entity
                                .WithRequired(ad => ad.from); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
            modelBuilder.Entity<EstablishedScoreTeam>()
                               .HasRequired<Team>(s => s.teamScore) // Mark Address property optional in Student entity
                               .WithRequiredDependent(ad => ad.establishedScore); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Stude
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<BlackBoard> blackBoards { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<EstablishedScoreTeam> establishedScoresTeam { get; set; }
        public DbSet<ScoreUserInTeam> scoresUserInTeam { get; set; }
        public DbSet<Connection> connexions { get; set; }
    }
}
