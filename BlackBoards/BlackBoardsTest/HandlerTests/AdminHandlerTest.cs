using BlackBoards;
using BlackBoards.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public void TestCreateCollaboratorCorrectly()
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
            //assertion
            bool result = handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateCollaboratorCheck()
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
            //assertion
           handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
            bool result = repository.UserList.Count == 1 && repository.AdministratorList.Count==0;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateCollaboratorIncorrectly()
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
            bool result = handler.CreateCollaborator(name, lastName, email, birthDate, password, repository);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCreateAdminCorrectly()
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
            //assertion
            bool result = handler.CreateAdmin(name, lastName, email, birthDate, password, repository);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateAdminCheck()
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
            //assertion
             handler.CreateAdmin(name, lastName, email, birthDate, password, repository);
            bool result = repository.UserList.Count == 1 && repository.AdministratorList.Count == 1;
            Assert.IsTrue(result);
        }
         [TestMethod]
        public void TestCreateAdminCheckTwoAdmins()
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
            //assertion
             handler.CreateAdmin(name, lastName, email, birthDate, password, repository);
            handler.CreateAdmin(name, lastName, email, birthDate, password, repository);
            bool result = repository.UserList.Count == 1 && repository.AdministratorList.Count == 1;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateAdminIncorrectly()
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
            handler.CreateAdmin(name, lastName, email, birthDate, password, repository);
            //assertion
            bool result = handler.CreateAdmin(name, lastName, email, birthDate, password, repository);
            Assert.IsFalse(result);
        }
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

        }
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
            bool result =handler.DeleteUser(email,repository);
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
        public void TestDeleteUserDoesntExists()
        {
            //instance
            Repository repository = new Repository();
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string email = "AnEmail";
            //assertion
            bool result =handler.DeleteUser(email, repository);
            Assert.IsFalse(result);

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
            string name= "TEAM A";
            string description="Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            //assertion
            bool result = handler.CreateTeam(name,description,maxUsers,members, new List<BlackBoard>(),repository);
            Assert.IsTrue(result);

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
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            bool result = repository.TeamList.ElementAt(0).Members.Count == 4;
            Assert.IsTrue(result);

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
            bool result = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            Assert.IsFalse(result);

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
            bool result = handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
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
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), repository);
            //assertion
            bool result = repository.TeamList.Count == 0;
            Assert.IsTrue(result);

        }

    }
}
