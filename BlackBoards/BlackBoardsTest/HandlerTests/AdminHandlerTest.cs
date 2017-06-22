using BlackBoards;
using BlackBoards.Domain.BlackBoards;
using BlackBoards.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest.HandlerTests
{
    [TestClass]
    public class AdminHandlerTest
    {
        public void Initialize(UserPersistance userContext)
        {
            AdminPersistance adminContext = new AdminPersistance();
            Admin u = new Admin();
            AdminHandler handler = new AdminHandler(u);
            handler.CreateAdmin("generatedName", "generatedLastName", "generatedEmail@email.com", DateTime.Now, "generatedPassword", adminContext);
        }
        public void CleanDB(UserPersistance userContext, TeamPersistance teamPersistance)
        {
            userContext.Empty();
            teamPersistance.Empty();
        }
        [TestMethod]
        public void TestAdminHandlerBuilder()
        {
            //instance
            Admin admin = new Admin();
            AdminHandler handler = new AdminHandler(admin);
            //assertion
            bool result = admin.Equals(handler.Admin);
            Assert.IsTrue(result);
        }
        /*
           [TestMethod]
           public void TestModifyUserCorrectly()
           {
               //instance
               Repository repository = new Repository();
               Admin anAdmin = new Admin();
               AdminHandler handler = new AdminHandler(anAdmin);
               string name = "aNewName";
               string lastName = "aLastName";
               string email = "AnEmail";
               DateTime birthDate = DateTime.Today;
               string password = "aPassword";
               handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
               string modEmail = "AModifiedEmail";
               //assertion
               bool result = handler.ModifyUser(email, name, lastName, modEmail, birthDate, password, repository);
               Assert.IsTrue(result);
           }
           [TestMethod]
           public void TestModifyUserCheck()
           {
               //instance
               Repository repository = new Repository();
               RepositoryHandler repHandler = new RepositoryHandler(repository);
               Admin anAdmin = new Admin();
               AdminHandler handler = new AdminHandler(anAdmin);
               string name = "aNewName";
               string lastName = "aLastName";
               string email = "AnEmail";
               DateTime birthDate = DateTime.Today;
               string password = "aPassword";
               handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
               string modEmail = "AModifiedEmail";
               handler.ModifyUser(email, name, lastName, modEmail, birthDate, password, repository);
               //assertion
               bool result = repHandler.getSepcificUser(modEmail).Name.Equals(name);
               Assert.IsTrue(result);
           }*/

        [TestMethod]
        public void TestModifyUserDoesntExists()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string name = "aNewName";
            string lastName = "aLastName";
            string email = "AnEmail";
            DateTime birthDate = DateTime.Today;
            string password = "aPassword";
            string modEmail = "AModifiedEmail";
            AdminPersistance userContext = new AdminPersistance();
            //assertion
            bool result = handler.ModifyUser(email, name, lastName, modEmail, birthDate, password, userContext);
            Assert.IsFalse(result);
        }
        public void TestModifyUserAlreadyExistsEmail()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string name = "aNewName";
            string lastName = "aLastName";
            string email = "AnEmail@email";
            DateTime birthDate = DateTime.Today;
            string password = "aPassword";
            string modEmail = "AModifiedEmail";
            AdminPersistance adminContext = new AdminPersistance();
            handler.CreateCollaborator(name, lastName, email, birthDate, password, adminContext);
            ValidationReturn result = handler.CreateCollaborator(name, lastName, email, birthDate, password, adminContext);
            //assertion
            Assert.IsFalse(result.Validation);
        }
        [TestMethod]
        public void TestDeleteUserCorrectly()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string name = "aNewName";
            string lastName = "aLastName";
            string email = "test@AnEmail";
            DateTime birthDate = DateTime.Today;
            string password = "aPassword";
            User userToAdd = new Admin();
            userToAdd.BirthDate = birthDate;
            userToAdd.LastName = lastName;
            userToAdd.Password = password;
            userToAdd.Email = email;
            userToAdd.Name = name;
            AdminPersistance adminContext = new AdminPersistance();
            handler.CreateCollaborator(name, lastName, email, birthDate, password, adminContext);
            User userToDelete = adminContext.GetUserByEmail(email);
            //assertion
            ValidationReturn result = handler.DeleteUser(userToDelete, adminContext);
            Assert.IsTrue(result.Validation);
        }
        [TestMethod]
        public void TestDeleteUserDoesntExists()
        {
            //instance
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string email = "AnEmail";
            User newCollaborator = new Collaborator();
            newCollaborator.Email = email;
            AdminPersistance adminContext = new AdminPersistance();
            //assertion
            ValidationReturn result = handler.DeleteUser(newCollaborator, adminContext);
            Assert.IsFalse(result.Validation);
        }
        [TestMethod]
        public void TestCreateTeamCheck()
        {
            //cleanDB
            CleanDB(new UserPersistance(), new TeamPersistance());
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            anAdmin.Email = "tadmin@tadmin";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            col1.Email = "tcol@col";
            Collaborator col2 = new Collaborator();
            col2.Name = "Collaborator2";
            col2.Email = "tcol@col2";
            Collaborator col3 = new Collaborator();
            col3.Name = "Collaborator3";
            col3.Email = "tcol@col3";
            Admin anotherAdmin = new Admin();
            AdminHandler hA = new AdminHandler(anotherAdmin);
            AdminPersistance ap = new AdminPersistance();
            hA.CreateAdmin(anAdmin.Name, anAdmin.LastName, anAdmin.Email, anAdmin.BirthDate, anAdmin.passwordUser, ap);
            hA.CreateCollaborator(col1.Name, col1.LastName, col1.Email, col1.BirthDate, col1.passwordUser, ap);
            hA.CreateCollaborator(col2.Name, col2.LastName, col2.Email, col2.BirthDate, col2.passwordUser, ap);
            hA.CreateCollaborator(col3.Name, col3.LastName, col3.Email, col3.BirthDate, col3.passwordUser, ap);
            anAdmin = ap.GetUserByEmail(anAdmin.Email) as Admin;
            col1 = ap.GetUserByEmail(col1.Email) as Collaborator;
            col2 = ap.GetUserByEmail(col2.Email) as Collaborator;
            col3 = ap.GetUserByEmail(col3.Email) as Collaborator;
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(anAdmin);
            string name = "TEAM Z";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            int idCreatedTeam = teamContext.IDByName(name);
            bool result = teamContext.GetMembersById(idCreatedTeam).Count == 4;
            UserPersistance userContext = new UserPersistance();
            CleanDB(userContext, teamContext);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateTeamSameName()
        {
            //instance
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            handler.CreateTeam(name, description, maxUsers, new List<User>(), new List<BlackBoard>(), teamContext);
            //assertion
            ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, new List<User>(), new List<BlackBoard>(), teamContext);
            bool result = validation.Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCreateTeamIncorrectlyMax0()
        {
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            Collaborator col2 = new Collaborator();
            col1.Name = "Collaborator2";
            Collaborator col3 = new Collaborator();
            col1.Name = "Collaborator3";
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 0;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            //assertion
            ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            bool result = validation.Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCreateTeamIncorrectlyOverSized()
        {
            //instance
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            Collaborator col2 = new Collaborator();
            col1.Name = "Collaborator2";
            Collaborator col3 = new Collaborator();
            col1.Name = "Collaborator3";
            Collaborator col4 = new Collaborator();
            col1.Name = "Collaborator4";
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(col4);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            //assertion
            ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            bool result = validation.Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCreateTeamCheckWrong()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            Collaborator col2 = new Collaborator();
            col1.Name = "Collaborator2";
            Collaborator col3 = new Collaborator();
            col1.Name = "Collaborator3";
            Collaborator col4 = new Collaborator();
            col1.Name = "Collaborator4";
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(col4);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            // handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            //   bool result = repository.TeamList.Count == 0;
            // Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyTeamCorrectly()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            members.Add(col1);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            //  handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            string newName = "TEAMB";
            int newMaxUsers = 5;
            //assertion
            //  bool result = handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), repository);
            // Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyTeamCheck()
        {
            //instance
            UserPersistance userContext = new UserPersistance();
            CleanDB(userContext, new TeamPersistance());
            Initialize(userContext);
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            anAdmin.Email = "Admin@Test";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            col1.Email = "Collaborator@Test";
            TeamPersistance teamContext = new TeamPersistance();
            AdminPersistance adminContext = new AdminPersistance();
            adminContext.AddUser(col1);
            adminContext.AddUser(anAdmin);
            members.Add(col1);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            string newName = "TEAMB";
            int newMaxUsers = 5;
            members.Remove(col1);
            handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), teamContext);
            Team teamToLookingUp = teamContext.GetTeamByName(newName);
            bool result = teamToLookingUp.MaxUsers == 5;
            CleanDB(userContext, new TeamPersistance());
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyTeamIncorrectly()
        {
            //instance
            UserPersistance userContext = new UserPersistance();
            CleanDB(userContext, new TeamPersistance());
            Initialize(userContext);
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            anAdmin.Email = "Admin@Test";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            col1.Email = "Collaborator@Test";
            TeamPersistance teamContext = new TeamPersistance();
            AdminPersistance adminContext = new AdminPersistance();
            adminContext.AddUser(col1);
            adminContext.AddUser(anAdmin);
            members.Add(col1);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            string newName = "TEAMB";
            int newMaxUsers = 1;
            Team teamToLookingUp = teamContext.GetTeamByName(name);
            handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), teamContext);
            Team team = teamContext.GetTeam(teamToLookingUp.IDTeam);
            bool result = team.MaxUsers == 4;
            CleanDB(userContext, new TeamPersistance());
            //assertion
            Assert.IsTrue(result);
        }
        
        /*
        [TestMethod]
        public void TestModifyTeamCheckWrong()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            List<User> members = new List<User>();
            Collaborator col1 = new Collaborator();
            col1.Name = "Collaborator1";
            members.Add(col1);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            string newName = "";
            int newMaxUsers = 5;
            handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), teamContext);
            //assertion
            bool result = repository.TeamList.ElementAt(0).Name.Equals(name) && repository.TeamList.ElementAt(0).MaxUsers == maxUsers;
            Assert.IsTrue(result);
        }*/
        [TestMethod]
        public void TestDeleteTeamCorrectly()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            List<User> members = new List<User>();
            members.Add(anAdmin);
            // handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            //bool result = handler.DeleteTeam(name, repository);
            //Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestDeleteTeamCheck()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            // handler.CreateTeam(name, description, maxUsers, new List<User>(), new List<BlackBoard>(), repository);
            // handler.DeleteTeam(name, repository);
            //assertion
            bool result = repository.TeamList.Count == 0;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestDeleteTeamIncorrectly()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            string name = "TEAM A";
            AdminHandler handler = new AdminHandler(anAdmin);
            //assertion
            // bool result = handler.DeleteTeam(name, repository);
            // Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestDeleteTeamCheckWrong()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            // handler.CreateTeam(name, description, maxUsers, new List<User>(), new List<BlackBoard>(), repository);
            //assertion
            //  bool result = handler.DeleteTeam("NotExistingTeam", repository);
            //  Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestDBAddUser()
        {
            //instance
            UserPersistance userContext = new UserPersistance();
            Initialize(userContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Collaborator("testCollaborator", "thisIsATest", "test@email", DateTime.Now, "testPassword");
            handler.CreateCollaborator(created.Name, created.LastName, created.Email, created.BirthDate, created.passwordUser, userContext);
            bool exists = userContext.Exists(created);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(userContext, teamContext);
            //assertion
            Assert.IsTrue(exists);
        }
        [TestMethod]
        public void TestDBAddSameUser()
        {
            //instance
            UserPersistance userContext = new UserPersistance();
            Initialize(userContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Collaborator("testCollaborator", "thisIsATest", "generatedEmail@email.com", DateTime.Now, "testPassword");
            ValidationReturn added = handler.CreateCollaborator(created.Name, created.LastName, created.Email, created.BirthDate, created.passwordUser, userContext);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(userContext, teamContext);
            //assertion
            Assert.IsFalse(added.Validation);
        }
        [TestMethod]
        public void TestDBDeleteUserCollaborator()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Collaborator("testCollaborator", "thisIsATest", "test@email", DateTime.Now, "testPassword");
            handler.CreateCollaborator(created.Name, created.LastName, created.Email, created.BirthDate, created.passwordUser, adminContext);
            created.ID = handler.getIdUserByEmail(created, adminContext);
            ValidationReturn deleted = handler.DeleteUser(created, adminContext);
            bool exists = adminContext.Exists(created);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            bool result = deleted.Validation && !exists;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestDBAddUserAdmin()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Admin("testAdmin", "thisIsATest", "testAdmin@email", DateTime.Now, "testPassword");
            handler.CreateAdmin(created.Name, created.LastName, created.Email, created.BirthDate, created.passwordUser, adminContext);
            bool exists = adminContext.Exists(created);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsTrue(exists);
        }
        [TestMethod]
        public void TestDBAddSameAdmin()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Admin("testCollaborator", "thisIsATest", "generatedEmail@email.com", DateTime.Now, "testPassword");
            ValidationReturn added = handler.CreateAdmin(created.Name, created.LastName, created.Email, created.BirthDate, created.passwordUser, adminContext);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsFalse(added.Validation);
        }
        [TestMethod]
        public void TestDBDeleteUserAdmin()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Admin("testAdmin", "thisIsATest", "testAdmin@email", DateTime.Now, "testPassword");
            handler.CreateAdmin(created.Name, created.LastName, created.Email, created.BirthDate, created.passwordUser, adminContext);
            bool exists = adminContext.Exists(created);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsTrue(exists);
        }
        [TestMethod]
        public void TestModifyUserCorrectly()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string modEmail = "AModifiedEmail";
            bool modified = handler.ModifyUser("generatedEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, "modifiedPassword", adminContext);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsTrue(modified);
        }
        [TestMethod]
        public void TestModifyUserCorrectlyCheck()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);

            string modEmail = "AModifiedEmail";
            handler.ModifyUser("generatedEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, "modifiedPassword", adminContext);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            User oldUser = new Admin();
            oldUser.Email = "generatedEmail@email.com";
            bool existsOld = adminContext.Exists(oldUser);
            bool result = !existsOld;
            ///assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyUserCorrectlyCheckNew()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string modEmail = "AModifiedEmail";
            handler.ModifyUser("generatedEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, "modifiedPassword", adminContext);
            User oldUser = new Admin();
            oldUser.Email = modEmail;
            bool existsNew = adminContext.Exists(oldUser);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsTrue(existsNew);
        }
        [TestMethod]
        public void TestModifyUserCorrectlyNotRegistered()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string modEmail = "AModifiedEmail";
            bool modified = handler.ModifyUser("NoEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, "modifiedPassword", adminContext);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsFalse(modified);
        }
        [TestMethod]
        public void TestModifyUserIncorrectlyCheck()
        {
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            Initialize(adminContext);
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string modEmail = "AModifiedEmail";
            handler.ModifyUser("NoEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, "modifiedPassword", adminContext);
            User oldUser = new Admin();
            oldUser.Email = modEmail;
            bool existsNew = adminContext.Exists(oldUser);
            TeamPersistance teamContext = new TeamPersistance();
            CleanDB(adminContext, teamContext);
            //assertion
            Assert.IsFalse(existsNew);
        }
    }
}
