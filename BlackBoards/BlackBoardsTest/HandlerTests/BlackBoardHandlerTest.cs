using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackBoards;
using BlackBoards.Handlers;
using System.Threading.Tasks;
using BlackBoards.Domain;

namespace BlackBoardsTest.HandlersTests
{
    [TestClass]
    public class BlackBoardHandlerTest
    {
        [TestMethod]
        public void TestCreateBlackBoard()
        {
            Dimension dimensions = new Dimension(0,0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(aTeam,name,description,dimensions);
            BlackBoard newBlackBoard = new BlackBoard();
            newBlackBoard.Name = name;
            newBlackBoard.Team = aTeam;
            newBlackBoard.Description = description;
            newBlackBoard.Dimension = dimensions;
            bool result = newBlackBoard.Equals(blackBoardHandler.BlackBoard);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyBlackBoard()
        {
            Dimension dimensions = new Dimension(0,0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(aTeam, name, description, dimensions);
            string newName = "New BlackBoard Name";
            blackBoardHandler.Modify(aTeam, newName, description, dimensions);
            BlackBoard newBlackBoard = new BlackBoard();
            newBlackBoard.Name = newName;
            newBlackBoard.Team = aTeam;
            newBlackBoard.Description = description;
            newBlackBoard.Dimension = dimensions;
            bool result = newBlackBoard.Equals(blackBoardHandler.BlackBoard);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddItemBlackBoard()
        {
            Dimension dimensions = new Dimension(0,0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(aTeam, name, description, dimensions);
            string newName = "New BlackBoard Name";
           
            blackBoardHandler.CreateBlackBoard(aTeam, newName, description, dimensions);
            Item testItem = new TextBox();
            blackBoardHandler.AddItem(testItem);
            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = itemInBlackBoard.Equals(testItem);
            } 
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveItemBlackBoard()
        {
            Dimension dimensions = new Dimension(0, 0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(aTeam, name, description, dimensions);
            string newName = "New BlackBoard Name";

            blackBoardHandler.CreateBlackBoard(aTeam, newName, description, dimensions);
            Item testItem = new TextBox();
            blackBoardHandler.AddItem(testItem);
            blackBoardHandler.RemoveItem(testItem);

            bool result = blackBoardHandler.BlackBoard.ItemList.Count == 0;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMoveItemBlackBoard()
        {
            Dimension dimensionsBlackBoard = new Dimension(8, 8);
            Coordinate coordinate = new Coordinate(5, 4);
            Dimension dimensionsItem = new Dimension(1, 1);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(aTeam, name, description, dimensionsBlackBoard);
                     
            Item testItem = new TextBox();
            testItem.Dimension = dimensionsItem;
          

            blackBoardHandler.AddItem(testItem);

            blackBoardHandler.MoveItem(testItem,coordinate);

            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = coordinate.Equals(testItem.Origin);
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMoveItemBlackBoardOutOfBands()
        {
            Dimension dimensionsBlackBoard = new Dimension(8, 8);
            Coordinate coordinate = new Coordinate(8, 7);
            Dimension dimensionsItem = new Dimension(1, 1);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(aTeam, name, description, dimensionsBlackBoard);
            Item testItem = new TextBox();
            testItem.Dimension = dimensionsItem;
            blackBoardHandler.AddItem(testItem);
            blackBoardHandler.MoveItem(testItem, coordinate);
            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = coordinate.Equals(testItem.Origin);
            }
            Assert.IsFalse(result);
        }

    }
}
