using BlackBoards;
using BlackBoards.Domain.BlackBoards;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace System
{
    public class Facade
    {
        public Facade(string modelo = "AdministradorContextoPruebas")
        {
            BlackBoardsContext context = new BlackBoardsContext();
        }
        #region User
        public ValidationReturn newUser(string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            validation = adminHandler.CreateCollaborator(name, lastName, email, birthDate, fstPass, adminContext);
            return validation;
        }
        public ValidationReturn newAdmin(string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            validation = adminHandler.CreateAdmin(name, lastName, email, birthDate, fstPass, adminContext);
            return validation;
        }
        public ValidationReturn modifyUser(string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido modificar el usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            validation = adminHandler.CreateAdmin(name, lastName, email, birthDate, fstPass, adminContext);
            return validation;
        }
        #endregion User
    }
}
