
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

namespace BlackBoardsTest
{
    [TestClass]
    public class UserHandlerTest
    {
        public void Initialize()
        {
            CleanDB(new UserPersistance());
            AdminPersistance adminContext = new AdminPersistance();
            BlackBoardPersistance bBContext = new BlackBoardPersistance();
            ItemPersistance itemContext = new ItemPersistance();
            TeamPersistance teamContext = new TeamPersistance();
            Admin u = new Admin();
            AdminHandler handler = new AdminHandler(u);
            handler.CreateAdmin("generatedName", "generatedLastName", "generatedEmail@email.com", DateTime.Now, "generatedPassword", adminContext);
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            BlackBoard board = new BlackBoard("generatedBoard", "thisIsAGeneratedBoard", new Dimension(350, 350), new List<Item>(), u);
            List<User> member = new List<User>();
            member.Add(generatedUser);
            Team aTeam = new Team("generatedTeam", DateTime.Now, "thisIsATestTeam", 10, member, new List<BlackBoard>());
            teamContext.AddTeam(aTeam);
            Team generatedTeam = teamContext.GetTeamByName("generatedTeam");
            UserHandler userHandler = new UserHandler(generatedUser);
            userHandler.CreateBlackBoard(generatedTeam, board);
        }
        public void CleanDB(UserPersistance userContext)
        {
            BlackBoardPersistance bBContext = new BlackBoardPersistance();
            ItemPersistance itemContext = new ItemPersistance();
            TeamPersistance teamCOntext = new TeamPersistance();
            CommentPersistance commentContext = new CommentPersistance();
            commentContext.Empty();
            itemContext.Empty();
            bBContext.Empty();
            teamCOntext.Empty();
            userContext.Empty();
        }
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
        public void TestAddTextBox()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            ValidationReturn result = handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(result.Validation);
        }
        [TestMethod]
        public void TestAddGigantItemToBlackBoard()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            Dimension gigantDimension = new Dimension(99999, 99999);
            textBox.Dimension = gigantDimension;
            ValidationReturn result = handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsFalse(result.Validation);
        }
        [TestMethod]
        public void testAddPicture()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            Picture pic = new Picture();
            pic.blackBoardBelongs = generatedBlackBoard;
            pic.ImgPath = "test/path";
            pic.Description = "testPic";
            ValidationReturn result = handler.AddItemToBlackBoard(generatedBlackBoard, pic);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(result.Validation);
        }
        [TestMethod]
        public void TestAddOutOfBandsItemToBlackBoard()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            Picture pic = new Picture();
            pic.blackBoardBelongs = generatedBlackBoard;
            pic.ImgPath = "test/path";
            pic.Description = "testPic";
            Coordinate outOfBandsCoordinates = new Coordinate(99999, 99999);
            pic.Origin = outOfBandsCoordinates;
            ValidationReturn result = handler.AddItemToBlackBoard(generatedBlackBoard, pic);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsFalse(result.Validation);
        }
        [TestMethod]
        public void TestResizeItem()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            Dimension aDimension = new Dimension(75, 50);
            handler.ResizeItemBlackBoard(generatedBlackBoard, theItem, aDimension);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(aDimension.Equals(theItem.Dimension));
        }
        [TestMethod]
        public void TestResizeItemInvalid()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            Dimension aDimension = new Dimension(9775, 50);
            handler.ResizeItemBlackBoard(generatedBlackBoard, theItem, aDimension);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsFalse(aDimension.Equals(theItem.Dimension));
        }
        [TestMethod]
        public void TestMoveItem()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            Coordinate aCoordinate = new Coordinate(20, 50);
            handler.MoveItemBlackBoard(generatedBlackBoard, theItem, aCoordinate);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(aCoordinate.Equals(theItem.Origin));
        }
        [TestMethod]
        public void TestMoveItemInvalid()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            Coordinate aCoordinate = new Coordinate(9999, 50);
            handler.MoveItemBlackBoard(generatedBlackBoard, theItem, aCoordinate);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsFalse(aCoordinate.Equals(theItem.Origin));
        }
        [TestMethod]
        public void TestCreateComment()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Font = "Arial";
            textBox.FontSize = 12;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            ValidationReturn result = handler.CreateNewComment(theItem, "testComment");
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(result.Validation);
        }
        [TestMethod]
        public void TestResolveComment()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            handler.CreateNewComment(theItem, "testComment");
            ItemPersistance itemContext = new ItemPersistance();
            TextBox fullItem = itemContext.GetItem(theItem.IDItem) as TextBox;
            Comment theComment = fullItem.comments.ElementAt(0);
            ValidationReturn result = handler.ResolveComment(theComment);
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(result.Validation);
        }
        [TestMethod]
        public void TestResolveCommentDate()
        {
            //instance
            Initialize();
            AdminPersistance adminContext = new AdminPersistance();
            User generatedUser = adminContext.GetUserByEmail("generatedEmail@email.com");
            UserHandler handler = new UserHandler(generatedUser);
            BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
            BlackBoard generatedBlackBoard = blackBoardContext.GetBlackBoardByName("generatedBoard");
            TextBox textBox = new TextBox();
            textBox.blackBoardBelongs = generatedBlackBoard;
            textBox.Content = "ThisIsATest";
            handler.AddItemToBlackBoard(generatedBlackBoard, textBox);
            TextBox theItem = generatedBlackBoard.itemList.ElementAt(0) as TextBox;
            handler.CreateNewComment(theItem, "testComment");
            ItemPersistance itemContext = new ItemPersistance();
            TextBox fullItem = itemContext.GetItem(theItem.IDItem) as TextBox;
            Comment theComment = fullItem.comments.ElementAt(0);
            ValidationReturn result = handler.ResolveComment(theComment);
            CommentHandler handlerComment = new CommentHandler(theComment);
            bool validation = handlerComment.WasResolved();
            CleanDB(new UserPersistance());
            //assertion
            Assert.IsTrue(validation);
        }
    }
}
