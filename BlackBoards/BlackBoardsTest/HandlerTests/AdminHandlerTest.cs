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
            string name = "aNewName";
            string lastName = "aLastName";
            string email = "AnEmail";
            DateTime birthDate = DateTime.Today;
            string password = "aPassword";
            handler.DeleteUser(email, repository);
            bool result = repository.UserList.Count == 0;
            Assert.IsFalse(result);

        }
    }
}
