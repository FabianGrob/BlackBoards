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
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            bool result = handler.AddBlackBoard(board);
            Assert.IsTrue(result);

        }
        public void TestTeamHandlerAddBlackBoardInValid()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            board.Dimension = new Dimension(-1, -1);
            bool result = handler.AddBlackBoard(board);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardInValid0()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            board.Dimension = new Dimension(0, 0);
            bool result = handler.AddBlackBoard(board);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestTeamHandlerAddBlackBoardAddedCorrectly()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            bool added = handler.AddBlackBoard(board);
            added = added && handler.Team.Boards.Contains(board);
            Assert.IsTrue(added);

        }
        [TestMethod]
        public void TestRemoveBlackBoard()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board);
            bool removed =handler.RemoveBlackBoard(board);
            Assert.IsTrue(removed && handler.Team.Boards.Count == 0);

        }
        public void TestModifyBlackBoardValid() {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            BlackBoard newBoard = new BlackBoard("newBoard","this is a test board",new Dimension(5,5) , aTeam, new List < Item > ());
            bool modified = ModifyBlackBoard(board, newBoard);
            Assert.IsTrue(modified);
        }
        public void TestModifyBlackBoardInvalid()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            BlackBoard newBoard = new BlackBoard("newBoard", "this is a test board", new Dimension(2,2), aTeam, new List<Item>());
            bool modified = ModifyBlackBoard(board, newBoard);
            Assert.IsFalse(modified);
        }
        public void TestModifyBlackBoardItems()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            BlackBoard board = new BlackBoard();
            handler.AddBlackBoard(board);
            Item txtbx = new TextBox();
            BlackBoard newBoard = new BlackBoard("newBoard", "this is a test board", new Dimension(2, 2), aTeam, new List<Item>());
            newBoard.ItemList.Add(txtbx);
            ModifyBlackBoard(board, newBoard);
            bool hasNewBoard = handler.Team.Boards.Contains(newBoard);
            bool hasNewItem = handler.Team.getSpecificBoard(newBoard).ItemList.contains(txtbx);
            Assert.IsTrue(hasNewBoard&& hasNewItem);
        }
    }
}
