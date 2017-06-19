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
   public partial class BlackBoardsContext: DbContext
    {
        public BlackBoardsContext()
            :base("name=BlackBoardsContextConnectionString") 
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // base.OnModelCreating(modelBuilder);
            //  modelBuilder.Entity<User>().ToTable("User");

            //throw new UnintentionalCodeFirstException();
        }
        public DbSet<User> users { get; set; }
       // public virtual DbSet<Admin> admins { get; set; }
       // public virtual DbSet<Team> teams { get; set; }
        

    }
}
