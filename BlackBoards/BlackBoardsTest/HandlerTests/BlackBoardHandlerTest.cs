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
        public void TestCreateAnotherBlackBoard()
        {
            //instance variables
            Dimension dimensions = new Dimension(5, 3);
            string name = "BlackBoard anotherName";
            string description = "BlackBoard anotherDescription";
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler();
            blackBoardHandler.CreateBlackBoard(name, description, dimensions);
            BlackBoard newBlackBoard = new BlackBoard();
            newBlackBoard.Name = name;
            newBlackBoard.Description = description;
            newBlackBoard.Dimension = dimensions;
            bool result = newBlackBoard.Equals(blackBoardHandler.BlackBoard);
            //assert
            Assert.IsTrue(result);
        }
    }
}
