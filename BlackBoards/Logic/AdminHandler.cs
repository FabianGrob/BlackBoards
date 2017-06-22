using BlackBoards;
using BlackBoards.Domain.BlackBoards;
using Persistance;
using System;
using System.Collections.Generic;

namespace BlackBoards
{
    public class AdminHandler
    {
        private Admin admin;
        public AdminHandler(Admin anAdmin)
        {
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
        private ValidationReturn ExistsUser(User anUser, UserPersistance userContext)
        {
            ValidationReturn validation = new ValidationReturn();
            bool exists = userContext.Exists(anUser);
            if (!exists)
            {
                validation.RedefineValues(false, "El usuario no existe");
            }
            else
            {
                validation.RedefineValues(true, "El usuario existe");
            }
            return validation;
        }
        public ValidationReturn CreateCollaborator(string name, string lastName, string email, DateTime birthDate, string password, UserPersistance userContext)
        {
            Collaborator aCollaborator = new Collaborator(name, lastName, email, birthDate, password);
            ValidationReturn validation = this.ExistsUser(aCollaborator, userContext);
            bool canAdd = !validation.Validation;
            if (canAdd)
            {
                userContext.AddUser(aCollaborator);
                validation.Message = "El usuario se ha creado con exito";
            }
            validation.Validation = canAdd;
            return validation;
        }


        public ValidationReturn CreateAdmin(string name, string lastName, string email, DateTime birthDate, string password, AdminPersistance adminrContext)
        {
            Admin anAdmin = new Admin(name, lastName, email, birthDate, password);
            ValidationReturn validation = this.ExistsUser(anAdmin, adminrContext);
            bool canAdd = !validation.Validation;
            if (canAdd)
            {
                adminrContext.AddAdmin(anAdmin);
                validation.Message = "El usuario se ha creado con exito";
            }
            validation.Validation = canAdd;
            return validation;
        }



        public bool ModifyUser(string lookUpEmail, string name, string lastName, string newEmail, DateTime birthDate, string password, AdminPersistance adminContext)
        {
            bool modified = false;
            User anUser = new Collaborator(name, lastName, lookUpEmail, birthDate, password);
            bool doesUserExists = adminContext.Exists(anUser);
            User modUser = new Collaborator();
            modUser.Email = newEmail;
            bool userWithNewEmailValid = !adminContext.Exists(modUser) || lookUpEmail.Equals(newEmail);
            if (doesUserExists && userWithNewEmailValid)
            {
                adminContext.ModifyUser(lookUpEmail, name, lastName, newEmail, birthDate, password);
                modified = true;
            }
            return modified;
        }
        private ValidationReturn isAdmin(User anUser, AdminPersistance adminContext)
        {
            ValidationReturn isAnAdmin = new ValidationReturn(false, "El usuario no es un administador");
            if (adminContext.ExistsAdmin(anUser))
            {
                isAnAdmin.RedefineValues(true, "El usuario es un Administrador");
            }
            return isAnAdmin;
        }
        public ValidationReturn DeleteUser(User toDelete, AdminPersistance adminContext)
        {
            ValidationReturn deleted = new ValidationReturn(false, "El usuario no existe");

            ValidationReturn exists = this.ExistsUser(toDelete, adminContext);
            if (exists.Validation)
            {
                adminContext.Delete(toDelete);
                deleted.Validation = true;
                deleted.Message = "deleted";
                if (this.isAdmin(toDelete, adminContext).Validation)
                {
                    adminContext.DeleteAdmin(toDelete as Admin);
                }
            }
            return deleted;
        }
        public int getIdUserByEmail(User anUser, UserPersistance userContext)
        {
            int idUser = -1; //-1 means user is not in the db
            ValidationReturn exists = this.ExistsUser(anUser, userContext);
            if (exists.Validation)
            {
                idUser = userContext.IDByEmail(anUser.Email);
            }
            return idUser;
        }
        public ValidationReturn CreateTeam(string name, string description, int maxUsers, List<User> members, List<BlackBoard> boards, TeamPersistance teamContext)
        {
            ValidationReturn added = new ValidationReturn(false, "El equipo ya existe");
            Team newTeam = new Team();
            newTeam.Name = name;
            newTeam.Description = description;
            newTeam.MaxUsers = maxUsers;
            newTeam.members = members;
            newTeam.boards = boards;
            newTeam.CreationDate = DateTime.Today;
            if (!teamContext.Exists(newTeam) && newTeam.IsValid().Validation)
            {
                teamContext.AddTeam(newTeam);
                added.Validation = true;
                added.Message = "El equipo ha sido ingresado.";
            }
            return added;
        }
        public ValidationReturn DeleteTeam(string name, TeamPersistance teamContext)
        {
            ValidationReturn validation = new ValidationReturn(false, "El equipo no ha sido eliminado.");
            int lookUpIdTeam = teamContext.IDByName(name);
            Team lookUpTeam = teamContext.GetTeam(lookUpIdTeam);
            bool teamAlreadyExists = teamContext.Exists(lookUpTeam);
            if (teamAlreadyExists)
            {
                teamContext.Delete(lookUpTeam);
                validation.RedefineValues(true, "El equipo ha sido eliminado.");
            }
            return validation;
        }
        public ValidationReturn ModifyTeam(string oldName, string name, string description, int maxUsers, List<User> members, List<BlackBoard> boards, TeamPersistance teamContext)
        {
            bool modified = false;
            Team abstractTeam = new Team(name, DateTime.Today, description, maxUsers, members, boards);
            ValidationReturn validModifications = abstractTeam.IsValid();
            int id = teamContext.IDByName(oldName);
            Team oldTeam = teamContext.GetTeam(id);
            Team toModificate = teamContext.GetTeam(id);
            toModificate.Name = name;
            bool teamExists = teamContext.Exists(oldTeam);
            if (validModifications.Validation && teamExists && (!teamContext.Exists(toModificate) || oldName.Equals(name)))
            {
                toModificate = teamContext.GetTeamByName(oldName);
                modified = true;
                toModificate.Name = name;
                toModificate.Description = description;
                toModificate.MaxUsers = maxUsers;
                toModificate.members = members;
                toModificate.boards = boards;
                teamContext.ModifyTeam(toModificate, oldTeam);
                validModifications.Message = "El equipo ha sido modificado";
            }
            return validModifications;
        }
    }
}

