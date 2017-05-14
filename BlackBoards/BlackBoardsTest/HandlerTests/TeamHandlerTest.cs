using BlackBoards;
using BlackBoards.Domain;
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
    public class TeamHandlerTest
    {
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
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            //assertion
            bool result = handler.AddBlackBoard(board);
            Assert.IsTrue(result);

        }
        public void TestTeamHandlerAddBlackBoardInValid()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            board.Dimension = new Dimension(-1, -1);
            //assertion
            bool result = handler.AddBlackBoard(board);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardInValid0()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            board.Dimension = new Dimension(0, 0);
            //assertion
            bool result = handler.AddBlackBoard(board);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardAddedCorrectly()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            bool added = handler.AddBlackBoard(board);
            //assertion
            added = added && handler.Team.Boards.Contains(board);
            Assert.IsTrue(added);

        }
        [TestMethod]
        public void TestRemoveBlackBoard()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board);
            //assertion
            bool removed =handler.RemoveBlackBoard(board);
            Assert.IsTrue(removed && handler.Team.Boards.Count == 0);

        }
        [TestMethod]
        public void TestModifyBlackBoardValid() {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board);
            User creatorUser = new Admin();
            BlackBoard newBoard = new BlackBoard("newBoard","this is a test board",new Dimension(5,5) , new List < Item > (),creatorUser);
            //assertion
            bool modified = handler.ModifyBlackBoard(board, newBoard);
            Assert.IsTrue(modified);
        }
        [TestMethod]
        public void TestModifyBlackBoardInvalid()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board);
            User creatorUser = new Admin();
            BlackBoard newBoard = new BlackBoard("newBoard", "this is a test board", new Dimension(2,2), new List<Item>(),creatorUser);
            //assertion
            bool modified = handler.ModifyBlackBoard(board, newBoard);
            Assert.IsFalse(modified);
        }
        [TestMethod]
        public void TestModifyBlackBoardItems()
        {
            //instance
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board);
            Item txtbx = new TextBox();
            User creatorUser = new Admin();
            BlackBoard newBoard = new BlackBoard("newBoard", "this is a test board", new Dimension(5, 5), new List<Item>(),creatorUser);
            board.ItemList.Add(txtbx);
            handler.ModifyBlackBoard(board, newBoard);
            //assertion
            bool hasItem = handler.Team.getSpecificBlackBoard(board).ItemList.Contains(txtbx);
            Assert.IsTrue(hasItem);
        }
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
