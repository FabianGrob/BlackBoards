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
        [TestMethod]
        public void TestAddAdmin() {
            Admin anAdmin = new Admin();
            Repository repository = new Repository();            
            RepositoryHandler handler = new RepositoryHandler(repository);
            repository.AdministratorList.Add(anAdmin);
            repository.UserList.Add(anAdmin);
            handler.AddAdmin(anAdmin);
            bool result = repository.UserList.Equals(handler.Repository.UserList) && repository.AdministratorList.Equals(handler.Repository.AdministratorList) && repository.TeamList.Equals(handler.Repository.TeamList);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddTeam() {
            Team aTeam = new Team();
            aTeam.Name = "Team A";
            Repository repository1 = new Repository();
            repository1.TeamList.Add(aTeam);
            Repository repository2 = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository2);
            handler.AddTeam(aTeam);
            bool result = repository1.TeamList.ElementAt(0).Equals(handler.Repository.TeamList.ElementAt(0));
            Assert.IsTrue(result);
            
        }
    }
   

}
