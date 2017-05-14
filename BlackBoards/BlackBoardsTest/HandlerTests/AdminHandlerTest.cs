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
        public void TestAdminHandlerBuilder() {
            //instance
            Admin admin = new Admin();
            AdminHandler handler = new AdminHandler(admin);
            //assertion
            bool result = admin.Equals(handler.Admin);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateCollaboratorCorrectly() {
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string name="aNewName";
            string lastName="aLastName";
            string email="AnEmail";
            DateTime birthDate=DateTime.Today;
            string password="aPassword";
            bool result =handler.CreateCollaborator(name,lastName,email,birthDate,password);
            Assert.IsTrue(result);
        }
        public void TestCreateCollaboratorIncorrectly()
        {
            Admin anAdmin = new Admin();
            AdminHandler handler = new AdminHandler(anAdmin);
            string name = "aNewName";
            string lastName = "aLastName";
            string email = "AnEmail";
            DateTime birthDate = DateTime.Today;
            string password = "aPassword";
            handler.CreateCollaborator(name, lastName, email, birthDate, password);
            bool result = handler.CreateCollaborator(name, lastName, email, birthDate, password);
            Assert.IsFalse(result);
        }

    }
}
