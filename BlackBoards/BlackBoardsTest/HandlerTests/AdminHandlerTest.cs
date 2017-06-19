﻿using BlackBoards;
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
            User u = new Admin();
            u.ID = 1;
            u.Email = "generatedEmail@email.com";
            userContext.AddUser(u);
        }
        public void CleanDB(UserPersistance userContext)
        {
            userContext.Empty();
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
            //assertion
            // bool result = handler.ModifyUser(email, name, lastName, modEmail, birthDate, password, repository);
            // Assert.IsFalse(result);

        }
        /* [TestMethod]
         public void TestModifyUserAlreadyExistsEmail()
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
             handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
             handler.CreateCollaborator(name, lastName, modEmail, birthDate, password, repository);
             //assertion
             bool result = handler.ModifyUser(email, name, lastName, modEmail, birthDate, password, repository);
             Assert.IsFalse(result);

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
             string email = "AnEmail";
             DateTime birthDate = DateTime.Today;
             string password = "aPassword";
             handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
             //assertion
             bool result = handler.DeleteUser(email, repository);
             Assert.IsTrue(result);

         }
         [TestMethod]
         public void TestDeleteUserCheck()
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
             handler.DeleteUser(email, repository);
             //assertion
             bool result = repository.UserList.Count == 0;
             Assert.IsTrue(result);

         }

         [TestMethod]
         public void TestDeleteUserAndCleanInvalidTeamCheck()
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
             User userToDelete = new Collaborator(name, lastName, email, birthDate, password);
             handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
             string aName = "testName";
             string description = "testDescription";
             int maximumUsers = 10;
             List<User> members = new List<User>();
             members.Add(userToDelete);
             List<BlackBoard> boards = new List<BlackBoard>();
             Team aTeam = new Team(name, new DateTime(), description, maximumUsers, members, boards);
             TeamHandler teamHandler = new TeamHandler(aTeam);
             handler.CreateTeam(aName, description, maximumUsers, members, boards, repository);
             handler.DeleteUser(email, repository);
             //assertion
             bool result = repository.TeamList.Count == 0;
             Assert.IsTrue(result);
         }
         [TestMethod]
         public void TestDeleteUserAndNoCleanTeamCheck()
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
             User userToDelete = new Collaborator(name, lastName, email, birthDate, password);
             User anotherUser = new Collaborator(name, lastName, email + "Diferrent", birthDate, password);
             handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
             handler.CreateCollaborator(name, lastName, email + "Diferrent", birthDate, password, repository);
             string aName = "testName";
             string description = "testDescription";
             int maximumUsers = 10;
             List<User> members = new List<User>();
             members.Add(userToDelete);
             List<BlackBoard> boards = new List<BlackBoard>();
             Team aTeam = new Team(name, new DateTime(), description, maximumUsers, members, boards);
             TeamHandler teamHandler = new TeamHandler(aTeam);
             teamHandler.AddMember(anotherUser);
             handler.CreateTeam(aName, description, maximumUsers, members, boards, repository);
             handler.DeleteUser(email, repository);
             //assertion
             bool result = repository.TeamList.Count == 0;
             Assert.IsFalse(result);
         }*/
        [TestMethod]
        public void TestDeleteUserDoesntExists()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string email = "AnEmail";
            //assertion
            //  bool result = handler.DeleteUser(email, repository);
            //Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestCreateTeamCorrectly()
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
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            //assertion
            // ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            // bool result = validation.Validation;
            // Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestCreateTeamCheck()
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
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            // handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            //  bool result = repository.TeamList.ElementAt(0).Members.Count == 4;
            //  Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestCreateTeamSameName()
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
            //  ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, new List<User>(), new List<BlackBoard>(), repository);
            // bool result = validation.Validation;
            // result = result && repository.TeamList.Count == 1;
            // Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestCreateTeamIncorrectlyMax0()
        {
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
            members.Add(col1);
            members.Add(col2);
            members.Add(col3);
            members.Add(anAdmin);
            string name = "TEAM A";
            string description = "Default Team Description";
            int maxUsers = 0;
            AdminHandler handler = new AdminHandler(anAdmin);
            //assertion
            //ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            //  bool result = validation.Validation;
            //  Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestCreateTeamIncorrectlyOverSized()
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
            //assertion
            // ValidationReturn validation = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            // bool result = validation.Validation;
            // Assert.IsFalse(result);

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
            // handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            string newName = "TEAMB";
            int newMaxUsers = 5;
            // handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            bool result = repository.TeamList.ElementAt(0).MaxUsers == 5 && repository.TeamList.ElementAt(0).Name.Equals(newName);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestModifyTeamIncorrectly()
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
            int newMaxUsers = 1;
            //assertion
            // bool result = handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), repository);
            // Assert.IsFalse(result);

        }
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
            // handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            string newName = "";
            int newMaxUsers = 5;
            //  handler.ModifyTeam(name, newName, description, newMaxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            bool result = repository.TeamList.ElementAt(0).Name.Equals(name) && repository.TeamList.ElementAt(0).MaxUsers == maxUsers;
            Assert.IsTrue(result);

        }
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
            handler.CreateCollaborator(created.Name, created.LastName, created.Email, created.BirthDate, created.password, userContext);
            bool exists = userContext.Exists(created);
            CleanDB(userContext);
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
            ValidationReturn added = handler.CreateCollaborator(created.Name, created.LastName, created.Email, created.BirthDate, created.password, userContext);
            CleanDB(userContext);
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
            handler.CreateCollaborator(created.Name, created.LastName, created.Email, created.BirthDate, created.password, adminContext);
            created.ID = handler.getIdUserByEmail(created, adminContext);
            ValidationReturn deleted = handler.DeleteUser(created, adminContext);
            bool exists = adminContext.Exists(created);
            CleanDB(adminContext);
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
            handler.CreateAdmin(created.Name, created.LastName, created.Email, created.BirthDate, created.password, adminContext);
            bool exists = adminContext.Exists(created);
            CleanDB(adminContext);
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
            ValidationReturn added = handler.CreateAdmin(created.Name, created.LastName, created.Email, created.BirthDate, created.password, adminContext);
            CleanDB(adminContext);
            //assertion
            Assert.IsFalse(added.Validation);
        }
        [TestMethod]
        public void TestDBDeleteUserAdmin()
        {
            //instance
            AdminPersistance userContext = new AdminPersistance();
            Initialize(userContext);
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            User created = new Admin("testAdmin", "thisIsATest", "testAdmin@email", DateTime.Now, "testPassword");
            handler.CreateAdmin(created.Name, created.LastName, created.Email, created.BirthDate, created.password, userContext);
            created.ID = handler.getIdUserByEmail(created, userContext);
            ValidationReturn deleted = handler.DeleteUser(created, userContext);
            bool existsUser = userContext.Exists(created);
            bool existsAdmin = userContext.ExistsAdmin(created);
            bool exists = existsUser || existsAdmin;
            CleanDB(userContext);
            bool result = deleted.Validation && !exists;
            //assertion
            Assert.IsTrue(result);
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
            bool modified = handler.ModifyUser("generatedEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, adminContext);
            CleanDB(adminContext);

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
            handler.ModifyUser("generatedEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, adminContext);
            CleanDB(adminContext);
            User oldUser = new Admin();
            oldUser.Email = "generatedEmail@email.com";
            bool existsOld = adminContext.Exists(oldUser);
            bool result = !existsOld;
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
            handler.ModifyUser("generatedEmail@email.com", "nameMoified", "lastNameMoified", modEmail, DateTime.Now, adminContext);
            CleanDB(adminContext);
            User oldUser = new Admin();
            oldUser.Email = modEmail;
            bool existsNew = adminContext.Exists(oldUser);
            Assert.IsTrue(existsNew);

        }

    }
}
