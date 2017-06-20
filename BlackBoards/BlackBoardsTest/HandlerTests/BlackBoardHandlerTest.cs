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
      /*  [TestMethod]
        public void TestCreateBlackBoard()
        {
            //instance variables
            Dimension dimensions = new Dimension(0,0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name,description,dimensions);
            BlackBoard newBlackBoard = new BlackBoard();
            newBlackBoard.Name = name;
            newBlackBoard.Description = description;
            newBlackBoard.Dimension = dimensions;
            bool result = newBlackBoard.Equals(blackBoardHandler.BlackBoard);
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyBlackBoard()
        {
            //instance variables
            Dimension dimensions = new Dimension(0,0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensions);
            string newName = "New BlackBoard Name";
            blackBoardHandler.Modify(newName, description, dimensions);
            BlackBoard newBlackBoard = new BlackBoard();
            newBlackBoard.Name = newName;
            newBlackBoard.Description = description;
            newBlackBoard.Dimension = dimensions;
            bool result = newBlackBoard.Equals(blackBoardHandler.BlackBoard);
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddItemBlackBoard()
        {
            //instance variables
            Dimension dimensionsBlackBoard = new Dimension(600,600);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensionsBlackBoard); 
            Item testItem = new TextBox();
            blackBoardHandler.AddItem(testItem);
            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = itemInBlackBoard.Equals(testItem);
            }
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddItemBlackBoardOutOfBands()
        {
            //instance variables
            Dimension dimensionsBlackBoard = new Dimension(5, 5);
            Dimension dimensionsItem = new Dimension(8, 8);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";       
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensionsBlackBoard);
            Item testItem = new TextBox();
            testItem.Dimension = dimensionsItem;
            blackBoardHandler.AddItem(testItem);
            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = itemInBlackBoard.Equals(testItem);
            }
            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRemoveItemBlackBoard()
        {
            //instance variables
            Dimension dimensions = new Dimension(0, 0);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensions);
            string newName = "New BlackBoard Name";
            blackBoardHandler.CreateBlackBoard(newName, description, dimensions);
            Item testItem = new TextBox();
            blackBoardHandler.AddItem(testItem);
            blackBoardHandler.RemoveItem(testItem);
            bool result = blackBoardHandler.BlackBoard.ItemList.Count == 0;
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMoveItemBlackBoard()
        {
            //instance variables
            Dimension dimensionsBlackBoard = new Dimension(8, 8);
            Coordinate coordinate = new Coordinate(5, 4);
            Dimension dimensionsItem = new Dimension(1, 1);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensionsBlackBoard);            
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
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMoveItemBlackBoardOutOfBands()
        {
            //instance variables
            Dimension dimensionsBlackBoard = new Dimension(8, 8);
            Coordinate coordinate = new Coordinate(8, 7);
            Dimension dimensionsItem = new Dimension(1, 1);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensionsBlackBoard);
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
            //assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestReziseItemBlackBoard()
        {
            //instance variables
            Dimension dimensionsBlackBoard = new Dimension(8, 8);
            Dimension newDimensionItem = new Dimension(2, 2);
            Dimension dimensionsItem = new Dimension(1, 1);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensionsBlackBoard);
            Item testItem = new TextBox();
            testItem.Dimension = dimensionsItem;
            blackBoardHandler.AddItem(testItem);
            blackBoardHandler.ReziseItem(testItem, newDimensionItem);
            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = newDimensionItem.Equals(testItem.Dimension);
            }
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestReziseItemBlackBoardOutOfBands()
        {
            //instance variables
            Dimension dimensionsBlackBoard = new Dimension(8, 8);
            Dimension dimensionOutOfBands = new Dimension(10, 10);
            Dimension dimensionsItem = new Dimension(1, 1);
            string name = "BlackBoard Name";
            string description = "BlackBoard Description";
            Team aTeam = new Team();
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensionsBlackBoard);
            Item testItem = new TextBox();
            testItem.Dimension = dimensionsItem;
            blackBoardHandler.AddItem(testItem);
            blackBoardHandler.ReziseItem(testItem, dimensionOutOfBands);
            bool result = false;
            if (blackBoardHandler.BlackBoard.ItemList.Count == 1)
            {
                Item itemInBlackBoard = blackBoardHandler.BlackBoard.ItemList.ElementAt(0);
                result = dimensionOutOfBands.Equals(testItem.Dimension);
            }
            //assert
            Assert.IsFalse(result);
        }*/

    }
}
