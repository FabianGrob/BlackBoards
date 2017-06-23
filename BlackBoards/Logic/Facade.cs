using BlackBoards;
using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using BlackBoards.Handlers;
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

        public void createFirstUser()
        {
            List<User> allUsers = this.GetAllUSersInDB();
            if (allUsers.Count == 0)
            {
                this.newAdmin("logged@logged", "admin@admin", "admin", "Administrador", "", DateTime.Now);
            }
        }

        #region User
        public ValidationReturn newUser(string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            User u = new Admin();
            u.Email = email;
            ValidationReturn validEmail = u.IsValid();
            if (validEmail.Validation)
            {
                validation = adminHandler.CreateCollaborator(name, lastName, email, birthDate, fstPass, adminContext);
                validation.Message = "Colaborador creado con exito";
            }
            validation.Message = validEmail.Message;
            return validation;
        }
        public ValidationReturn newAdmin(string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo administrador.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = new Admin();
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            User u = new Admin();
            u.Email = email;
            ValidationReturn validEmail = u.IsValid();
            if (validEmail.Validation)
            {
                validation = adminHandler.CreateAdmin(name, lastName, email, birthDate, fstPass, adminContext);
                validation.Message = "Administrador creado con exito";
            }
            validation.Message = validEmail.Message;
            return validation;
        }
        public ValidationReturn modifyUser(string oldEmail, string emailAdmin, string email, string fstPass, string name, string lastName, DateTime birthDate)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido modificar el usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            User u = new Admin();
            u.Email = email;
            ValidationReturn validEmail = u.IsValid();
            if (validEmail.Validation)
            {
                validation.Validation = adminHandler.ModifyUser(oldEmail, name, lastName, email, birthDate, fstPass, adminContext);
                validation.Message = "Usuario modificado con exito";

            }
            validation.Message = validEmail.Message;
            return validation;
        }

        private bool sameUser(string emailAdmin, string email)
        {
            return (emailAdmin.Equals(email));
        }

        public ValidationReturn deleteUser(string emailAdmin, string email)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se puede eliminar a si mismo");
            if (!sameUser(emailAdmin, email))
            {
                validation = this.ereaseUser(emailAdmin, email);
            }
            return validation;
        }
        private ValidationReturn ereaseUser(string emailAdmin, string email)
        {
            TeamPersistance teamContext = new TeamPersistance();
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido eliminar el usuario.");
            AdminPersistance adminContext = new AdminPersistance();
            Admin loggedAdmin = adminContext.GetUserByEmail(emailAdmin) as Admin;
            AdminHandler adminHandler = new AdminHandler(loggedAdmin);
            User userToDelete = adminContext.GetUserByEmail(email);
            List<Team> belongingTeams = adminContext.GetBelongingTeams(userToDelete);
            validation = adminHandler.DeleteUser(userToDelete, adminContext);
            bool cleanTeams = false;
            foreach (Team actualTeam in belongingTeams)
            {
                Team completeActualTeam = teamContext.GetTeamByName(actualTeam.Name);
                if (completeActualTeam.members.Count == 0)
                {
                    adminHandler.DeleteTeam(completeActualTeam.Name, teamContext);
                    cleanTeams = true;
                }
            }
            if (cleanTeams)
            {
                validation.Message = "Tambien se borraron equipos que quedaron vacios";
            }

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
        public List<Team> GetTeamsBelongs(string email)
        {
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
        #region BlackBoard
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
        public ValidationReturn modifyBlackBoard(string logged, Team aTeam, BlackBoard newBlackBoard, BlackBoard oldBlackBoard)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido ingresar el nuevo usuario.");
            UserPersistance userContext = new UserPersistance();
            User user = userContext.GetUserByEmail(logged) as User;
            UserHandler userHandler = new UserHandler(user);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
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
            BlackBoard oldBlackBoard = blackBoardContext.GetBlackBoardByName(name);
            validation = userHandler.RemoveBlackBoard(oldBlackBoard.teamBelongs, oldBlackBoard);
            return validation;
        }
        public List<Team> GetAllTeamsInDB()
        {
            TeamPersistance teamContext = new TeamPersistance();
            return teamContext.GetAllTeams();
        }
        public Team GetSpecificTeam(string name)
        {
            TeamPersistance teamContext = new TeamPersistance();
            return teamContext.GetTeamByName(name);
        }
        public List<BlackBoard> GetBoardsFromTeam(Team aTeam)
        {
            TeamPersistance teamContext = new TeamPersistance();
            return teamContext.GetBoardsFromSpecificTeam(aTeam);
        }
        #endregion BlackBoard
        #region Item
        public ValidationReturn newTextBox(BlackBoard container, string content, int heigth, int width, int xAxis, int yAxis, string font, int fontsize)
        {
            BlackBoardPersistance BBContext = new BlackBoardPersistance();
            ValidationReturn added = new ValidationReturn(false, "No se agrego el Item");
            BlackBoardHandler handler = new BlackBoardHandler(container);
            BlackBoard completeBB = BBContext.GetBlackBoardByName(container.Name);
            TextBox newTextBox = new TextBox(new Dimension(width, heigth), new List<Comment>(), new Coordinate(xAxis, yAxis), content, font, fontsize);
            newTextBox.blackBoardBelongs = completeBB;
            ValidationReturn canAdd = newTextBox.isValid();
            if (canAdd.Validation)
            {
                added = handler.AddItem(newTextBox);
            }
            added.Message = canAdd.Message;

            return added;
        }
        public ValidationReturn newPicture(BlackBoard container, string description, int heigth, int width, int xAxis, int yAxis, string imgPath)
        {
            BlackBoardPersistance BBContext = new BlackBoardPersistance();
            ValidationReturn added = new ValidationReturn(false, "No se agrego el Item");
            BlackBoardHandler handler = new BlackBoardHandler(container);
            BlackBoard completeBB = BBContext.GetBlackBoardByName(container.Name);
            Picture newPic = new Picture(new Dimension(width, heigth), new List<Comment>(), new Coordinate(xAxis, yAxis));
            newPic.Description = description;
            newPic.blackBoardBelongs = completeBB;
            newPic.ImgPath = imgPath;
            added = handler.AddItem(newPic);
            return added;
        }
        public void ModifyItemInBB(BlackBoard aBoard,Item anItem,Coordinate newCoordinates,Dimension newDimensions,User actualLogged) {
            UserHandler handler = new UserHandler(actualLogged);
            ItemPersistance itemctx = new ItemPersistance();
            Item completeItem = itemctx.GetItem(anItem.IDItem);
            handler.MoveItemBlackBoard(aBoard, completeItem, newCoordinates);
            handler.ResizeItemBlackBoard(aBoard, completeItem, newDimensions);

        }
        public bool DeleteItem(User anUser,BlackBoard aBoard, Item anItem) {
            UserHandler handler = new UserHandler(anUser);
           return handler.RemoveItemBlackBoard(aBoard, anItem);
        }
        #endregion Item
        #region Comment
        public ValidationReturn newComment(string loggedUser, Item aItem, string message)
        {
            UserPersistance userContext = new UserPersistance();
            User user = userContext.GetUserByEmail(loggedUser);
            UserHandler userHandler = new UserHandler(user);
            ValidationReturn added = userHandler.CreateNewComment(aItem, message);
            return added;
        }
        public ValidationReturn resolveComment(string loggedUser, Comment aComment)
        {
            UserPersistance userContext = new UserPersistance();
            User user = userContext.GetUserByEmail(loggedUser);
            UserHandler userHandler = new UserHandler(user);
            ValidationReturn added = userHandler.ResolveComment(aComment);
            return added;
        }
        public bool WasResolved(Comment selectedComment) {
            CommentHandler handler = new CommentHandler(selectedComment);
            return handler.WasResolved();
        }
        public List<Comment> ResolvedCommentsByUser(User anUser) {
            UserPersistance userContext = new UserPersistance();
            return userContext.GetUserByEmail(anUser.Email).resolvedComments;
        }
        public List<Comment> filterCommentingUser(List<Comment> comments, User commentingUser)
        {
            List<Comment> filtered = new List<Comment>();
            foreach (Comment actualComment in comments)
            {
                if (commentingUser.Equals(actualComment.commentingUser))
                {
                    filtered.Add(actualComment);
                }
            }
            return filtered;
        }
        public List<Comment> filterResolvingDate(List<Comment> comments, DateTime resolvingnDate)
        {
            List<Comment> filtered = new List<Comment>();
            foreach (Comment actualComment in comments)
            {
                if (resolvingnDate.Equals(actualComment.ResolvingDate))
                {
                    filtered.Add(actualComment);
                }
            }
            return filtered;

        }
        public List<Comment> filterCreationDate(List<Comment> comments, DateTime creationDate)
        {
            List<Comment> filtered = new List<Comment>();
            foreach (Comment actualComment in comments)
            {
                if (creationDate.Equals(actualComment.CommentingDate))
                {
                    filtered.Add(actualComment);
                }
            }
            return filtered;

        }
        #endregion Comment
    }
}
