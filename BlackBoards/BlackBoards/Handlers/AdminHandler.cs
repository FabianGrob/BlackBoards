using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class AdminHandler
    {
        private Admin admin;
        public AdminHandler(Admin anAdmin) {
            this.Admin = anAdmin;
        }
        public Admin Admin
        {
            get
            {
                return this.admin;
            }
            set
            {
                this.admin = value;
            }
        }
        public bool CreateCollaborator(string name,string lastName,string email,DateTime birthDate,string password,Repository theRepository) {
            Collaborator aCollaborator = new BlackBoards.Collaborator(name,lastName,email,birthDate,password);
            RepositoryHandler repHandler = new Handlers.RepositoryHandler(theRepository);
            bool canRegister = !repHandler.UserAlreadyExists(aCollaborator);
            if (canRegister)
            {
                repHandler.AddUser(aCollaborator);
            }
            return canRegister;
        }

    }
}
