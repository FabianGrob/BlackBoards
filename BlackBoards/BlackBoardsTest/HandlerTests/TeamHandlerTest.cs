using BlackBoards;
using BlackBoards.Domain;
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
    public class TeamHandlerTest
    {
        public void CleanDB(BlackBoardPersistance blackBoardContext)
        {
            TeamPersistance teamContext = new TeamPersistance();
            UserPersistance userContext = new UserPersistance();
            blackBoardContext.Empty();
            teamContext.Empty();
            userContext.Empty();
        }
        public void setUp(Team aTeam,BlackBoardPersistance blackBoardContext)
        {
            TeamHandler handler = new TeamHandler(aTeam);
        }
        [TestMethod]
        public void TestTeamHandlerBuilder()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            //assertion
            bool result = aTeam.Equals(handler.Team);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardValid()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            handler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            ValidationReturn validationAdded = teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);

            //assertion
            bool result = blackBoardContext.Exists(board);
            CleanDB(blackBoardContext);
            Assert.IsTrue(result);
        }
        public void TestTeamHandlerAddBlackBoardInValid()
        {
            //instance
            Team aTeam = new Team();
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            board.Dimension = new Dimension(-1, -1);
            //assertion
            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validation = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
            CleanDB(blackBoardContext);
            Assert.IsFalse(validation.Validation);

        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardInvalid()
        {
            //instance
            Team aTeam = new Team();
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            board.Dimension = new Dimension(0, 0);
            //assertion
            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validation = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
            Assert.IsFalse(validation.Validation);
        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardAddedCorrectly()
        {
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            //instance
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            handler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            ValidationReturn validationAdded = teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            //assertion
            bool added = blackBoardContext.Exists(board);
            CleanDB(blackBoardContext);
            Assert.IsTrue(added);
        }
        [TestMethod]
        public void TestRemoveBlackBoard()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            handler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            UserHandler uHandler = new UserHandler(adm);
            board = blackBoardContext.GetBlackBoardByName(board.Name);
            ValidationReturn removed = uHandler.RemoveBlackBoard(creatorTeam, board);
            CleanDB(blackBoardContext);
            //assertion
            Assert.IsTrue(removed.Validation);
        }
        [TestMethod]
        public void TestRemoveBlackBoardCheck()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            AdminHandler newHandler = new AdminHandler(creatorUser as Admin);
            newHandler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            UserHandler uHandler = new UserHandler(adm);
            board = blackBoardContext.GetBlackBoardByName(board.Name);
            ValidationReturn removed = uHandler.RemoveBlackBoard(creatorTeam, board);
            Team compare = teamContext.GetTeamByName(teamHandler.Team.Name);
            CleanDB(blackBoardContext);
            //assertion
            Assert.IsTrue(compare.boards.Count == 0);
        }
        [TestMethod]
        public void TestModifyBlackBoardValid() {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            AdminHandler newHandler = new AdminHandler(creatorUser as Admin);
            newHandler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            UserHandler uHandler = new UserHandler(adm);
            board = blackBoardContext.GetBlackBoardByName(board.Name);
            UserHandler userHandler = new UserHandler(creatorUser);
            BlackBoard newBoard = new BlackBoard(board.Name,board.Description,board.Dimension,board.itemList,board.creatorUser);
            newBoard.Name = "modifiedddName";
            bool modified = userHandler.ModifyBlackBoard(teamContext.GetTeamByName(creatorTeam.Name),board, newBoard);
            //assertion

            CleanDB(blackBoardContext);
            Assert.IsTrue(modified);
        }
        [TestMethod]
        public void TestModifyBlackBoardSameName()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            AdminHandler newHandler = new AdminHandler(creatorUser as Admin);
            newHandler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            UserHandler uHandler = new UserHandler(adm);
            board = blackBoardContext.GetBlackBoardByName(board.Name);
            UserHandler userHandler = new UserHandler(creatorUser);
            BlackBoard newBoard = new BlackBoard(board.Name, board.Description, board.Dimension, board.itemList, board.creatorUser);
            newBoard.Description = "modifiedDescription";
            bool modified = userHandler.ModifyBlackBoard(teamContext.GetTeamByName(creatorTeam.Name), board, newBoard);
            //assertion
            CleanDB(blackBoardContext);
            Assert.IsTrue(modified);
        }
        [TestMethod]
        public void TestModifyBlackBoardValidCheck()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            AdminHandler newHandler = new AdminHandler(creatorUser as Admin);
            newHandler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            UserHandler uHandler = new UserHandler(adm);
            board = blackBoardContext.GetBlackBoardByName(board.Name);
            UserHandler userHandler = new UserHandler(creatorUser);
            BlackBoard newBoard = new BlackBoard(board.Name, board.Description, board.Dimension, board.itemList, board.creatorUser);
            newBoard.Name = "modifiedddName";
            userHandler.ModifyBlackBoard(teamContext.GetTeamByName(creatorTeam.Name), board, newBoard);
            bool checkModified = blackBoardContext.Exists(newBoard);
            //assertion
            CleanDB(blackBoardContext);
            Assert.IsTrue(checkModified);
        }
        [TestMethod]
        public void TestModifyBlackBoardInvalid()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            CleanDB(blackBoardContext);
            AdminPersistance adminContext = new AdminPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin adm = new Admin();
            AdminHandler handler = new AdminHandler(adm);
            BlackBoard board = new BlackBoard();
            handler.CreateAdmin("creatorUser", "creator", "creator@User.com", DateTime.Now, "123", adminContext);
            User creatorUser = adminContext.GetUserByEmail("creator@User.com");
            List<User> member = new List<User>();
            member.Add(creatorUser);
            AdminHandler newHandler = new AdminHandler(creatorUser as Admin);
            newHandler.CreateTeam("teamTest", "thisIsATest", 10, member, new List<BlackBoard>(), teamContext);
            Team creatorTeam = teamContext.GetTeamByName("teamTest");
            TeamHandler teamHandler = new TeamHandler(creatorTeam);
            teamHandler.AddBlackBoard(board, blackBoardContext, creatorUser);
            UserHandler uHandler = new UserHandler(adm);
            board = blackBoardContext.GetBlackBoardByName(board.Name);
            UserHandler userHandler = new UserHandler(creatorUser);
            BlackBoard newBoard = new BlackBoard(board.Name, board.Description, board.Dimension, board.itemList, board.creatorUser);
            newBoard.Name = "modifiedddName";
            BlackBoard notExisting = new BlackBoard("Not existing board", "", new Dimension(350, 350), new List<Item>(), creatorUser);
            bool modified = userHandler.ModifyBlackBoard(teamContext.GetTeamByName(creatorTeam.Name), notExisting, newBoard);
            //assertion
            CleanDB(blackBoardContext);
            Assert.IsFalse(modified);
        }
        [TestMethod]
        public void TestAddMemberCorrectly() {
            CleanDB(new BlackBoardPersistance());
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            //assertion
            bool result = handler.AddMember(admin);
            CleanDB(blackBoardContext);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddMemberCheckExistance()
        {
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            //assertion
            bool result = handler.Team.members.Contains(admin) && handler.Team.members.Count==1;
            CleanDB(blackBoardContext);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddMemberExists()
        {
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            //assertion
            bool result = handler.AddMember(admin);
            CleanDB(blackBoardContext);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestRemoveMemberCorrectly() {
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            //assertion
            bool result = handler.RemoveMember(admin);
            CleanDB(new BlackBoardPersistance());
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestRemoveMemberCheck()
        {
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            handler.RemoveMember(admin);
            CleanDB(new BlackBoardPersistance());
            //assertion
            bool result = handler.Team.members.Count == 0;
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestRemoveMemberDoesntExists()
        {
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
           //assertion
            bool result =  handler.RemoveMember(admin);
            CleanDB(new BlackBoardPersistance());
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestIsUserInTeamTrue() {
            TeamPersistance teammContext = new TeamPersistance();
            UserPersistance userContext = new UserPersistance();
            CleanDB(new BlackBoardPersistance());
            //instance
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            anAdmin.Email = "tadmin@tadmin";
            List<User> members = new List<User>();
            Admin anotherAdmin = new Admin();
            AdminHandler hA = new AdminHandler(anotherAdmin);
            AdminPersistance ap = new AdminPersistance();
            hA.CreateAdmin(anAdmin.Name, anAdmin.LastName, anAdmin.Email, anAdmin.BirthDate, anAdmin.passwordUser, ap);
            User containsThisUser = userContext.GetUserByEmail(anAdmin.Email);
            members.Add(containsThisUser);
            string name = "TEAM Z";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            Team aTeam = teammContext.GetTeamByName(name);
            TeamHandler teamHandler = new TeamHandler(aTeam);
            //assertion
            bool result = teamHandler.IsUserInTeam(containsThisUser);
            CleanDB(new BlackBoardPersistance());
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsUserInTeamFalse()
        {
            TeamPersistance teammContext = new TeamPersistance();
            UserPersistance userContext = new UserPersistance();
            CleanDB(new BlackBoardPersistance());
            //instance
            Admin anAdmin = new Admin();
            anAdmin.Name = "Admin";
            anAdmin.Email = "tadmin@tadmin";
            List<User> members = new List<User>();
            Admin anotherAdmin = new Admin();
            AdminHandler hA = new AdminHandler(anotherAdmin);
            AdminPersistance ap = new AdminPersistance();
            hA.CreateAdmin(anAdmin.Name, anAdmin.LastName, anAdmin.Email, anAdmin.BirthDate, anAdmin.passwordUser, ap);
            members.Add(userContext.GetUserByEmail(anAdmin.Email));
            string name = "TEAM Z";
            string description = "Default Team Description";
            int maxUsers = 4;
            AdminHandler handler = new AdminHandler(anAdmin);
            TeamPersistance teamContext = new TeamPersistance();
            handler.CreateTeam(name, description, maxUsers, members, new List<BlackBoard>(), teamContext);
            Team aTeam = teammContext.GetTeamByName(name);
            User admin = new Admin();
            TeamHandler teamHandler = new TeamHandler(aTeam);
            //assertion
            bool result = teamHandler.IsUserInTeam(admin);
            CleanDB(new BlackBoardPersistance());
            Assert.IsFalse(result);
        }
    }

}
