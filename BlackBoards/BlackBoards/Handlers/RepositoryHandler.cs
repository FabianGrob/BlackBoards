using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
   public class RepositoryHandler
    {
        private Repository repository;

        public RepositoryHandler(Repository theRepository) {
            this.repository = theRepository;
        }
        public Repository Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }
        public void AddUser(User anUser) {
            this.repository.UserList.Add(anUser);
        }
        public void AddAdmin(Admin anAdmin)
        {
            this.repository.AdministratorList.Add(anAdmin);
            this.AddUser(anAdmin);
        }
        public void AddTeam(Team aTeam) {
            this.repository.TeamList.Add(aTeam);
        }
    }
}
