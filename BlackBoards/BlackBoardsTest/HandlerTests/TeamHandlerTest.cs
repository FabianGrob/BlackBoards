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
        }/*
        [TestMethod]
        public void TestModifyBlackBoardItems()
        {
            //instance
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board,blackBoardContext);
            Item txtbx = new TextBox();
            User creatorUser = new Admin();
            BlackBoard newBoard = new BlackBoard("newBoard", "this is a test board", new Dimension(5, 5), new List<Item>(),creatorUser);
            board.ItemList.Add(txtbx);
            handler.ModifyBlackBoard(board, newBoard);
            //assertion
            bool hasItem = handler.Team.getSpecificBlackBoard(board).ItemList.Contains(txtbx);
            CleanDB(blackBoardContext);
            Assert.IsTrue(hasItem);
        }*/
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
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            //assertion
            bool result = handler.IsUserInTeam(admin);
            CleanDB(new BlackBoardPersistance());
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsUserInTeamFalse()
        {
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            //assertion
            bool result = handler.IsUserInTeam(admin);
            CleanDB(new BlackBoardPersistance());
            Assert.IsFalse(result);
        }
    }

}
