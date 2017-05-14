using BlackBoards;
using BlackBoards.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
    public class UserHandlerTest
    {
        [TestMethod]
        public void TestUserHandlerBuilder()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            bool result = u.Equals(userHandler.User);
            //assertion
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestCreateBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam,blackBoard);
            bool result = aTeam.Boards.Count == 1;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            userHandler.RemoveBlackBoard(aTeam, blackBoard);
            bool result = aTeam.Boards.Count == 0;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveInvalidBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            BlackBoard blackBoard = new BlackBoard();
            bool result=userHandler.RemoveBlackBoard(aTeam, blackBoard);
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddItemToBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            bool result = blackBoard.ItemList.Count == 1;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddInvalidItemToBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Dimension invalidDimension = new Dimension(5,7);
            item.Dimension = invalidDimension;
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            bool result = blackBoard.ItemList.Count == 1;
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestRemoveItemBlackBoard()
        {
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.RemoveItemBlackBoard(blackBoard, item);
            bool result = blackBoard.ItemList.Count == 0;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveItemBlackBoardBool()
        {
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);  
            bool result = userHandler.RemoveItemBlackBoard(blackBoard, item);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveInvalidItemBlackBoard()
        {

            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Item anotherItem = new TextBox();
            Dimension newDimension = new Dimension(2, 2);
            item.Dimension = newDimension;
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.RemoveItemBlackBoard(blackBoard, anotherItem);
            bool result = blackBoard.ItemList.Count == 1;

            Assert.IsTrue(result);
        }
        

    }
    
}
