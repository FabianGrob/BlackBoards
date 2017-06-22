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
        public Facade()
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
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo administrador.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            validation = adminHandler.CreateAdmin(name, lastName, email, birthDate, fstPass, adminContext);
            return validation;
        }
        public ValidationReturn modifyUser(string oldEmail,string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido modificar el usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            validation.Validation = adminHandler.ModifyUser(oldEmail,name,lastName, email, birthDate, fstPass, adminContext);
            return validation;
        }
        public ValidationReturn deleteUser(string emailAdmin, string email)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido eliminar el usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            User userToDelete = adminContext.GetUserByEmail(email);
            validation = adminHandler.DeleteUser(userToDelete, adminContext);
            return validation;
        }
        public List<User> GetAllUSersInDB()
        {
            UserPersistance userContext = new UserPersistance();
            return userContext.allUsers();
        }
        public ValidationReturn CanLogWithUser(string email, string password)
        {
            ValidationReturn validate = new ValidationReturn(false, "contraseña inválida");
            UserPersistance userContext = new UserPersistance();
            User loggingUser = userContext.GetUserByEmail(email);
            validate.Validation = loggingUser.Password.Equals(password);
            if (validate.Validation)
            {
                validate.Message = "Datos correctamente ingresados";
            }
            return validate;
        }
        public User GetSpecificUser(string email)
        {
            UserPersistance userContext = new UserPersistance();
            return userContext.GetUserByEmail(email);
        }
        public bool isUserAdmin(string email)
        {
            UserPersistance userContext = new UserPersistance();
            User anUser = userContext.GetUserByEmail(email);
            return anUser is Admin;
        }
        public List<Team> GetTeamsBelongs(string email) {
            UserPersistance userContext = new UserPersistance();
            return userContext.GetUserByEmail(email).belongInteams;
        }
        #endregion User

        #region Team
        public ValidationReturn newTeam(string loggedAdmin, string teamName, string description, int maxUsers, List<User> members, List<BlackBoard> blackBoards)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin admin = adminContext.GetUserByEmail(loggedAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(admin);
            TeamPersistance teamContext = new TeamPersistance();
            validation = adminHandler.CreateTeam(teamName, description, maxUsers, members, blackBoards, teamContext);
            return validation;
        }
        public ValidationReturn modifyTeam(string loggedAdmin, string teamName, string description, int maxUsers, List<User> members, List<BlackBoard> blackBoards)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin admin = adminContext.GetUserByEmail(loggedAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(admin);
            TeamPersistance teamContext = new TeamPersistance();
            validation = adminHandler.CreateTeam(teamName, description, maxUsers, members, blackBoards, teamContext);
            return validation;
        }
        public ValidationReturn deleteTeam(string loggedAdmin, string name)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin admin = adminContext.GetUserByEmail(loggedAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(admin);
            validation = adminHandler.DeleteTeam(name, teamContext);
            return validation;
        }
        #endregion Team
        #region Team
        public ValidationReturn newBlackBoard(string logged, Team aTeam, BlackBoard aBlackBoard)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            UserPersistance userContext = new UserPersistance();
            User user = userContext.GetUserByEmail(logged) as User;
            UserHandler userHandler = new UserHandler(user);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            validation.Validation = userHandler.CreateBlackBoard(aTeam, aBlackBoard);
            return validation;
        }
        public ValidationReturn modifyBlackBoard(string logged, Team aTeam, BlackBoard newBlackBoard)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            UserPersistance userContext = new UserPersistance();
            User user = userContext.GetUserByEmail(logged) as User;
            UserHandler userHandler = new UserHandler(user);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard oldBlackBoard = new BlackBoard();
            //BlackBoard oldBlackBoard = blackBoardContext.GetBlackBoardByName(newBlackBoard.Name);
            validation.Validation = userHandler.ModifyBlackBoard(aTeam, oldBlackBoard, newBlackBoard);
            return validation;
        }
        public ValidationReturn deleteBlackBoard(string logged, string name)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            UserPersistance userContext = new UserPersistance();
            User user = userContext.GetUserByEmail(logged) as User;
            UserHandler userHandler = new UserHandler(user);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            //BlackBoard oldBlackBoard = blackBoardContext.GetBlackBoardByName(newBlackBoard.Name);
            //validation.Validation = userHandler.RemoveBlackBoard(oldBlackBoard);
            return validation;
        }
        public List<Team> GetAllTeamsInDB() {
            TeamPersistance teamContext = new TeamPersistance();
            return teamContext.GetAllTeams();
        }
        public Team GetSpecificTeam(string name) {
            TeamPersistance teamContext = new TeamPersistance();
            return teamContext.GetTeamByName(name);
        }
        public List<BlackBoard> GetBoardsFromTeam(Team aTeam) {
            TeamPersistance teamContext = new TeamPersistance();
            return teamContext.GetBoardsFromSpecificTeam(aTeam);
        }
        #endregion Team
    }
}
