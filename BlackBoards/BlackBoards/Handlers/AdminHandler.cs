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
        public bool CreateCollaborator(string name, string lastName, string email, DateTime birthDate, string password, Repository theRepository) {
            Collaborator aCollaborator = new Collaborator(name, lastName, email, birthDate, password);
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            bool canRegister = !repHandler.UserAlreadyExists(aCollaborator);
            if (canRegister)
            {
                repHandler.AddUser(aCollaborator);
            }
            return canRegister;
        }
        public bool ModifyUser(string lookUpEmail, string name, string lastName, string email, DateTime birthDate, string password, Repository theRepository) {
            bool modified = false;
            User anUser = new Collaborator(name, lastName, lookUpEmail, birthDate, password);
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            if (repHandler.UserAlreadyExists(anUser))
            {
                repHandler.ModifyUser(lookUpEmail,name,lastName,email,birthDate,password);
                modified = true;
                               
            }
            return modified;
        }
    }
}
