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
        [TestMethod]
        public void TestResizeItemBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Dimension newDimension = new Dimension(2, 2);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);

            bool result = blackBoard.ItemList.Count == 1;
            if (result)
            {
                result = blackBoard.ItemList.ElementAt(0).Dimension == newDimension;
            }
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestInvalidResizeItemBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Dimension newDimension = new Dimension(9, 9);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);

            bool result = blackBoard.ItemList.Count == 1;
            if (result)
            {
                result = blackBoard.ItemList.ElementAt(0).Dimension == newDimension;
            }
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestResizeItemBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Dimension newDimension = new Dimension(3, 3);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            bool result = userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestInvalidResizeItemBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Dimension newDimension = new Dimension(9, 9);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            bool result = userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMoveItemBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Coordinate newCoordinate = new Coordinate(2, 2);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);

            bool result = blackBoard.ItemList.Count == 1;
            if (result)
            {
                result = blackBoard.ItemList.ElementAt(0).Origin == newCoordinate;
            }
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMoveItemBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Coordinate newCoordinate = new Coordinate(3, 3);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            bool result = userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestInvalidMoveItemBlackBoard()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Coordinate newCoordinate = new Coordinate(9, 9);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);

            bool result = blackBoard.ItemList.Count == 1;
            if (result)
            {
                result = blackBoard.ItemList.ElementAt(0).Origin == newCoordinate;
            }
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestInvalidMoveItemBlackBoardBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Coordinate newCoordinate = new Coordinate(9, 9);
            BlackBoard blackBoard = new BlackBoard();
            userHandler.AddItemToBlackBoard(blackBoard, item);
            bool result = userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);
            //assertion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCreateNewCommentUser()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            userHandler.CreateNewComment(item, "New Comment");
            bool result = item.Comments.Count == 1;
            if (result)
            {
                result = item.Comments.ElementAt(0).CommentingUser.Equals(u);
            }
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateNewCommentWrite()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            userHandler.CreateNewComment(item, "New Comment");
            bool result = item.Comments.Count == 1;
            if (result)
            {
                result = item.Comments.ElementAt(0).WrittenComment.Equals("New Comment");
            }
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateNewCommentDate()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            userHandler.CreateNewComment(item, "New Comment");
            bool result = item.Comments.Count == 1;
            if (result)
            {
                result = item.Comments.ElementAt(0).CommentingDate.Equals(DateTime.Today);
            }
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCreateNewCommentBool()
        {
            //instance
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Item item = new TextBox();
            Coordinate newCoordinate = new Coordinate(2, 2);
            bool result = userHandler.CreateNewComment(item, "New Comment");  
            //assertion
            Assert.IsTrue(result);
        }   
    }  
}
