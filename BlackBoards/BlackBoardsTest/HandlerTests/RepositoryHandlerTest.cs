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
    public class RepositoryHandlerTest
    {
        [TestMethod]
        public void TestRepositoryHandler() {
            List<Team> teams = new List<Team>();
            List<User> users = new List<User>();
            List<Admin> admins = new List<Admin>();
            Repository repository = new Repository(admins,users,teams);
            RepositoryHandler handler = new RepositoryHandler(repository);
            bool result = repository.Equals(handler.Repository);

        }
        [TestMethod]
        public void TestAddUser() {
            User u = new Collaborator();
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddUser(u);
            repository.UserList.Add(u);
            bool result = repository.Equals(handler.Repository);
            Assert.IsTrue(result);
            
        }
        public void TestAddAdmin() {
            Admin anAdmin = new Admin();
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            repository.AdministratorList.Add(anAdmin);
            repository.UserList.Add(anAdmin);
            handler.AddAdmin(anAdmin);
            bool result = repository.Equals(handler.Repository);
            Assert.IsTrue(result);


        }
    }
   

}
