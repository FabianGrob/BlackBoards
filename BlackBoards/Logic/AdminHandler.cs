﻿using BlackBoards;
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
        /*
       
        
        public bool ModifyUser(string lookUpEmail, string name, string lastName, string email, DateTime birthDate, string password, Repository theRepository)
        {
            bool modified = false;
            User anUser = new Collaborator(name, lastName, lookUpEmail, birthDate, password);
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            bool doesUserExists = repHandler.UserAlreadyExists(anUser);
            User modUser = new Collaborator();
            modUser.Email = email;
            bool userWithNewEmailValid = !theRepository.UserList.Contains(modUser) || lookUpEmail.Equals(email);
            if (doesUserExists && userWithNewEmailValid)
            {
                repHandler.ModifyUser(lookUpEmail, name, lastName, email, birthDate, password);
                modified = true;
            }
            return modified;
        }
        public bool DeleteUser(string email, Repository repository)
        {
            bool deleted = false;
            RepositoryHandler repHandler = new RepositoryHandler(repository);
            User u = new Admin();
            u.Email = email;
            bool doesUserExists = repHandler.UserAlreadyExists(u);
            if (doesUserExists)
            {
                repHandler.DeleteUser(email);
                deleted = true;
            }
            return deleted;
        }

        public ValidationReturn CreateTeam(string name, string description, int maxUsers, List<User> members, List<BlackBoard> boards, Repository theRepository)
        {
            ValidationReturn added = new ValidationReturn(false, "El equipo ya existe");
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            Team newTeam = new Team();
            newTeam.Name = name;
            newTeam.Description = description;
            newTeam.MaxUsers = maxUsers;
            newTeam.Members = members;
            newTeam.Boards = boards;
            newTeam.CreationDate = DateTime.Today;
            if (!repHandler.TeamAlreadyExists(name) && newTeam.IsValid().Validation)
            {
                repHandler.AddTeam(newTeam);
                added.Validation = true;
                added.Message = "El equipo ha sido ingresado.";
            }
            return added;
        }
        public bool ModifyTeam(string oldName, string name, string description, int maxUsers, List<User> members, List<BlackBoard> boards, Repository theRepository)
        {
            bool modified = false;
            RepositoryHandler handler = new RepositoryHandler(theRepository);
            Team abstractTeam = new Team(name, DateTime.Today, description, maxUsers, members, boards);
            ValidationReturn validModifications = abstractTeam.IsValid();
            Team oldTeam = new Team();
            oldTeam.Name = oldName;
            bool teamExists = theRepository.TeamList.Contains(oldTeam);
            if (validModifications.Validation && teamExists && (!handler.TeamAlreadyExists(name) || oldName.Equals(name)))
            {
                Team toModificate = handler.GetSpecificTeam(oldName);
                modified = true;
                toModificate.Name = name;
                toModificate.Description = description;
                toModificate.MaxUsers = maxUsers;
                toModificate.Members = members;
                toModificate.Boards = boards;
            }
            return modified;
        }
        public bool DeleteTeam(string name, Repository theRepository)
        {
            bool deleted = false;
            RepositoryHandler handler = new RepositoryHandler(theRepository);
            bool teamAlreadyExists = handler.TeamAlreadyExists(name);
            if (teamAlreadyExists)
            {
                Team toDelete = handler.GetSpecificTeam(name);
                theRepository.TeamList.Remove(toDelete);
                deleted = true;
            }
            return deleted;
        }
        */
    }
}

