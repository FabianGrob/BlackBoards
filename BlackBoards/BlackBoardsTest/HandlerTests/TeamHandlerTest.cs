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
            blackBoardContext.Empty();
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
            Team aTeam = new Team();
            this.setUp(aTeam,blackBoardContext);
            BlackBoard board = new BlackBoard();
            TeamHandler handler = new TeamHandler(aTeam);
            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validation = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
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
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validationAdded = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
          
            //assertion
            bool added = validationAdded.Validation && blackBoardContext.Exists(board);
            CleanDB(blackBoardContext);
            Assert.IsTrue(added);

        }
        [TestMethod]
        public void TestRemoveBlackBoard()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validation = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
            //assertion
            ValidationReturn removed = handler.RemoveBlackBoard(board,blackBoardContext);
            CleanDB(blackBoardContext);
            Assert.IsTrue(removed.Validation && handler.Team.Boards.Count == 0);
        }
        [TestMethod]
        public void TestModifyBlackBoardValid() {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();

            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validation = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
            BlackBoard newBoard = new BlackBoard("newBoard","this is a test board",new Dimension(60,60) , new List < Item > (),creatorUser);
            //assertion
            bool modified = handler.ModifyBlackBoard(board, newBoard);
            CleanDB(blackBoardContext);
            Assert.IsTrue(modified);
        }/*
        [TestMethod]
        public void TestModifyBlackBoardInvalid()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            User creatorUser = new Admin();
            creatorUser.ID = 10000;
            ValidationReturn validation = handler.AddBlackBoard(board, blackBoardContext, creatorUser);
            handler.AddBlackBoard(board,blackBoardContext);
          
            BlackBoard newBoard = new BlackBoard("newBoard", "this is a test board", new Dimension(2,2), new List<Item>(),creatorUser);
            //assertion
            bool modified = handler.ModifyBlackBoard(board, newBoard);
            CleanDB(blackBoardContext);
            Assert.IsFalse(modified);
        }
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
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            //assertion
            bool result = handler.AddMember(admin);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddMemberCheckExistance()
        {
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            //assertion
            bool result = handler.Team.Members.Contains(admin) && handler.Team.Members.Count==1;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddMemberExists()
        {
            //instance
            Team aTeam = new Team();
            User admin = new Admin();
            TeamHandler handler = new TeamHandler(aTeam);
            handler.AddMember(admin);
            //assertion
            bool result = handler.AddMember(admin); ;
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
            //assertion
            bool result = handler.Team.Members.Count == 0;
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
            Assert.IsFalse(result);
        }
    }

}
