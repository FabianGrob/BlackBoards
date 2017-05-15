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
            //teams instances
            Team aTeam = new Team();
            Team anotherTeam = new Team();
            //set teams names
            aTeam.Name = "Team A";            
            anotherTeam.Name = "Team A";
            //create repositories & adding items
            Repository repository1 = new Repository();
            Repository repository2 = new Repository();
            repository1.TeamList.Add(aTeam);            
            RepositoryHandler handler = new RepositoryHandler(repository2);
            handler.AddTeam(anotherTeam);
            //assertion
            bool result = repository1.TeamList.ElementAt(0).Equals(handler.Repository.TeamList.ElementAt(0));
            Assert.IsTrue(result);            
        }
        [TestMethod]
        public void TestUserAlreadyExists() {
            //instance
            User anUser = new Collaborator();
            anUser.Email = "anEmail";
            User anotherUser = new Admin();
            anotherUser.Email = "anEmail";            
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddUser(anUser);
            //assertion
            bool result = handler.UserAlreadyExists(anotherUser);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestNotUserAlreadyExists()
        {
            //instance
            User anUser = new Collaborator();
            anUser.Email = "anEmail";
            User anotherUser = new Admin();
            anotherUser.Email = "otherEmail";
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddUser(anUser);
            //assertion
            bool result = handler.UserAlreadyExists(anotherUser);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestTeamAlreadyExists()
        {
            //instance
            Team aTeam = new Team();
            aTeam.Name = "aName";
            Team anotherTeam = new Team();
            anotherTeam.Name = "aName";
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddTeam(aTeam);
            //assertion
            bool result = handler.TeamAlreadyExists(anotherTeam);
            Assert.IsTrue(result);


        }
        [TestMethod]
        public void TestNotTeamAlreadyExists()
        {
            //instance
            Team aTeam = new Team();
            aTeam.Name = "aName";
            Team anotherTeam = new Team();
            anotherTeam.Name = "anotherName";
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddTeam(aTeam);
            //assertion
            bool result = handler.TeamAlreadyExists(anotherTeam);
            Assert.IsFalse(result);


        }
        [TestMethod]
        public void TestgetNoneUserTeams()
        {
            //instance
            User anUser = new Collaborator();
            anUser.Email = "anEmail";
            Team aTeam = new Team();
            aTeam.Name = "aName";
            List<Team> teams = new List<Team>();
            teams.Add(aTeam);
            List<User> users = new List<User>();
            users.Add(anUser);
            List<Admin> admins = new List<Admin>();
            Repository repository = new Repository(admins, users, teams);
            RepositoryHandler handler = new RepositoryHandler(repository);
            List<Team> teamsWhereUserIs = handler.getUserTeams(anUser);
            //assertion
            bool result = teamsWhereUserIs.Count == 0;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestgetUserTeams()
        {
            //instance
            User anUser = new Collaborator();
            anUser.Email = "anEmail";
            Team aTeam = new Team();
            aTeam.Name = "aName";
            aTeam.Members.Add(anUser);
            Team anotherTeam = new Team();
            aTeam.Name = "anotherName";
            List<Team> teams = new List<Team>();
            teams.Add(aTeam);
            List<User> users = new List<User>();
            users.Add(anUser);
            List<Admin> admins = new List<Admin>();
            Repository repository = new Repository(admins, users, teams);
            RepositoryHandler handler = new RepositoryHandler(repository);
            List<Team> teamsWhereUserIs = handler.getUserTeams(anUser);          
            //assertion
            bool result = teamsWhereUserIs.Count == 1;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCheckPasswordUser()
        {
            User u = new Collaborator();
            u.Email = "email@test.com";
            u.Password = "passwordTest";
            User anotherUser = new Admin();
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddUser(u);
            handler.AddUser(anotherUser);
            repository.UserList.Add(u);
            bool result = handler.CheckPassword("email@test.com", "passwordTest");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCheckWrongPasswordUser()
        {
            User u = new Collaborator();
            u.Email = "email@test.com";
            u.Password = "passwordTest";
            User anotherUser = new Admin();
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddUser(u);
            handler.AddUser(anotherUser);
            repository.UserList.Add(u);
            bool result = handler.CheckPassword("email@test.com", "password");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckNonExistentUser()
        {
            User u = new Collaborator();
            u.Email = "email@test.com";
            u.Password = "passwordTest";
            User anotherUser = new Admin();
            Repository repository = new Repository();
            RepositoryHandler handler = new RepositoryHandler(repository);
            handler.AddUser(u);
            handler.AddUser(anotherUser);
            repository.UserList.Add(u);
            bool result = handler.CheckPassword("NonExistentEmail@test.com", "passwordTest");
            Assert.IsFalse(result);
        }
    }
}
