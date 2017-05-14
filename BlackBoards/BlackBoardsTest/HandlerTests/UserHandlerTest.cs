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
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam,blackBoard);
            bool result = aTeam.Boards.Count == 1;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            bool result = userHandler.CreateBlackBoard(aTeam, blackBoard);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateBlackBoardUserNotInTeam()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            bool result = aTeam.Boards.Count == 1;
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestRemoveBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            userHandler.RemoveBlackBoard(aTeam, blackBoard);
            bool result = aTeam.Boards.Count == 0;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            bool ok=userHandler.CreateBlackBoard(aTeam, blackBoard);
            int a = 0;
            bool result = userHandler.RemoveBlackBoard(aTeam, blackBoard);
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
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.RemoveItemBlackBoard(blackBoard, item);
            bool result = blackBoard.ItemList.Count == 0;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveItemBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);  
            bool result = userHandler.RemoveItemBlackBoard(blackBoard, item);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveInvalidItemBlackBoard()
        {
            //instance
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
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            BlackBoard updateBlackBoard = new BlackBoard();
            updateBlackBoard.Name = "different name"; 
            bool result = userHandler.ModifyBlackBoard(aTeam, blackBoard, updateBlackBoard);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            BlackBoard updateBlackBoard = new BlackBoard();
            updateBlackBoard.Name = "different name";
            userHandler.ModifyBlackBoard(aTeam,blackBoard,updateBlackBoard);
            bool result = updateBlackBoard.Equals(aTeam.Boards.ElementAt(0));
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestModifyInvalidBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            BlackBoard updateBlackBoard = new BlackBoard();
            updateBlackBoard.Name = "different name";
            Dimension invalidDimension = new Dimension(1,1);
            updateBlackBoard.Dimension = invalidDimension;           
            bool result = userHandler.ModifyBlackBoard(aTeam, blackBoard, updateBlackBoard);
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestModifyInvalidBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            aTeam.Members.Add(u);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam, blackBoard);
            BlackBoard updateBlackBoard = new BlackBoard();
            updateBlackBoard.Name = "different name";
            Dimension invalidDimension = new Dimension(1, 1);
            updateBlackBoard.Dimension = invalidDimension;
            userHandler.ModifyBlackBoard(aTeam, blackBoard, updateBlackBoard);
            bool result = updateBlackBoard.Equals(aTeam.Boards.ElementAt(0));
            //assertion
            Assert.IsFalse(result);
        }
    }  
}
