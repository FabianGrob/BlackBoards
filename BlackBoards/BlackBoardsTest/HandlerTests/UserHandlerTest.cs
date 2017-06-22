
using BlackBoards;
using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
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
            User generatedUser=adminContext.GetUserByEmail("generatedEmail@email.com");
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
        public void TestModifyItem()
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
        public void TestModifyItem()
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
            Assert.IsTrue(aDimension.Equals(theItem.Dimension));
        }

        /* 

         */
        /*
         [TestMethod]
         public void TestUserHandlerBuilder()
=======
        /*
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
             Repository repository = new Repository();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             userHandler.RemoveBlackBoard(aTeam, blackBoard,repository);
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
             Repository repository = new Repository();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             bool result = userHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
         public void TestRemoveNoCreatorUserBlackBoard()
         {
             //instance
             User u = new Collaborator();
             u.Email = "userCreator@gmail.com";
             User anotherUser = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             UserHandler anotherUserHandler = new UserHandler(anotherUser);
             Team aTeam = new Team();
             aTeam.Members.Add(u);
             aTeam.Members.Add(anotherUser);
             BlackBoard blackBoard = new BlackBoard();
             Repository repository = new Repository();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             bool result = anotherUserHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
             //assertion
             Assert.IsFalse(result);
         }
         [TestMethod]
         public void TestRemoveNoCreatorAdminUserBlackBoard()
         {
             //instance
             User u = new Collaborator();
             u.Email = "userCreator@gmail.com";
             Admin anotherUser = new Admin();
             string adminName = "FirstName";
             string adminLastName = "LastName";
             string adminEmail = "admin@test.com";
             DateTime adminDate = new DateTime();
             string adminPassword = "password";
             anotherUser.Name = adminName;
             anotherUser.LastName = adminLastName;
             anotherUser.Email = adminEmail;
             anotherUser.BirthDate = adminDate;
             anotherUser.Password = adminPassword;
             Repository repository = new Repository();
             AdminHandler adminHandler = new AdminHandler(anotherUser);
            // adminHandler.CreateAdmin(adminName,adminLastName,adminEmail,adminDate,adminPassword, repository);
             UserHandler userHandler = new UserHandler(u);
             UserHandler anotherUserHandler = new UserHandler(anotherUser);
             Team aTeam = new Team();
             aTeam.Members.Add(u);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             bool result = anotherUserHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
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
             aTeam.Members.Add(u);
             BlackBoard blackBoard = new BlackBoard();
             Repository repository = new Repository();
             bool result = userHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
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
             Dimension invalidDimension = new Dimension(600,7);
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
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
<<<<<<< HEAD
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
             Repository repository = new Repository();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             userHandler.RemoveBlackBoard(aTeam, blackBoard,repository);
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
             Repository repository = new Repository();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             bool result = userHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
         public void TestRemoveNoCreatorUserBlackBoard()
         {
             //instance
             User u = new Collaborator();
             u.Email = "userCreator@gmail.com";
             User anotherUser = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             UserHandler anotherUserHandler = new UserHandler(anotherUser);
             Team aTeam = new Team();
             aTeam.Members.Add(u);
             aTeam.Members.Add(anotherUser);
             BlackBoard blackBoard = new BlackBoard();
             Repository repository = new Repository();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             bool result = anotherUserHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
             //assertion
             Assert.IsFalse(result);
         }
         [TestMethod]
         public void TestRemoveNoCreatorAdminUserBlackBoard()
         {
             //instance
             User u = new Collaborator();
             u.Email = "userCreator@gmail.com";
             Admin anotherUser = new Admin();
             string adminName = "FirstName";
             string adminLastName = "LastName";
             string adminEmail = "admin@test.com";
             DateTime adminDate = new DateTime();
             string adminPassword = "password";
             anotherUser.Name = adminName;
             anotherUser.LastName = adminLastName;
             anotherUser.Email = adminEmail;
             anotherUser.BirthDate = adminDate;
             anotherUser.Password = adminPassword;
             Repository repository = new Repository();
             AdminHandler adminHandler = new AdminHandler(anotherUser);
            // adminHandler.CreateAdmin(adminName,adminLastName,adminEmail,adminDate,adminPassword, repository);
             UserHandler userHandler = new UserHandler(u);
             UserHandler anotherUserHandler = new UserHandler(anotherUser);
             Team aTeam = new Team();
             aTeam.Members.Add(u);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.CreateBlackBoard(aTeam, blackBoard);
             bool result = anotherUserHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
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
             aTeam.Members.Add(u);
             BlackBoard blackBoard = new BlackBoard();
             Repository repository = new Repository();
             bool result = userHandler.RemoveBlackBoard(aTeam, blackBoard, repository);
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
             Dimension invalidDimension = new Dimension(600,7);
             item.Dimension = invalidDimension;
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             bool result = blackBoard.ItemList.Count == 1;
=======
             Item item = new TextBox();
             Dimension newDimension = new Dimension(999, 9);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);

             bool result = blackBoard.ItemList.Count == 1;
             if (result)
             {
                 result = blackBoard.ItemList.ElementAt(0).Dimension == newDimension;
             }
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
             //assertion
             Assert.IsFalse(result);
         }
         [TestMethod]
<<<<<<< HEAD
         public void TestRemoveItemBlackBoard()
=======
         public void TestResizeItemBlackBoardBool()
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
<<<<<<< HEAD
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.RemoveItemBlackBoard(blackBoard, item);
             bool result = blackBoard.ItemList.Count == 0;
=======
             Dimension newDimension = new Dimension(3, 3);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             bool result = userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
<<<<<<< HEAD
         public void TestRemoveItemBlackBoardBool()
=======
         public void TestInvalidResizeItemBlackBoardBool()
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
<<<<<<< HEAD
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
=======
             Dimension newDimension = new Dimension(999, 9);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             bool result = userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
             //assertion
             Assert.IsFalse(result);
         }
         [TestMethod]
<<<<<<< HEAD
         public void TestResizeItemBlackBoard()
=======
         public void TestMoveItemBlackBoard()
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
<<<<<<< HEAD
             Dimension newDimension = new Dimension(2, 2);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);
=======
             Coordinate newCoordinate = new Coordinate(2, 2);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);
>>>>>>> feature/FuncionalidadesHandlerAdminConBD

             bool result = blackBoard.ItemList.Count == 1;
             if (result)
             {
<<<<<<< HEAD
                 result = blackBoard.ItemList.ElementAt(0).Dimension == newDimension;
=======
                 result = blackBoard.ItemList.ElementAt(0).Origin == newCoordinate;
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
             }
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
<<<<<<< HEAD
         public void TestInvalidResizeItemBlackBoard()
=======
         public void TestMoveItemBlackBoardBool()
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
<<<<<<< HEAD
             Dimension newDimension = new Dimension(999, 9);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.ResizeItemBlackBoard(blackBoard, item, newDimension);
=======
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
             Coordinate newCoordinate = new Coordinate(9999, 9);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);
>>>>>>> feature/FuncionalidadesHandlerAdminConBD

             bool result = blackBoard.ItemList.Count == 1;
             if (result)
             {
<<<<<<< HEAD
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
             Dimension newDimension = new Dimension(999, 9);
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
             Coordinate newCoordinate = new Coordinate(9999, 9);
             BlackBoard blackBoard = new BlackBoard();
             userHandler.AddItemToBlackBoard(blackBoard, item);
             userHandler.MoveItemBlackBoard(blackBoard, item, newCoordinate);

             bool result = blackBoard.ItemList.Count == 1;
             if (result)
             {
=======
>>>>>>> feature/FuncionalidadesHandlerAdminConBD
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
             Coordinate newCoordinate = new Coordinate(9999, 9);
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
         [TestMethod]
         public void TestResolveComment()
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
             Coordinate newCoordinate = new Coordinate(2, 2);
             userHandler.CreateNewComment(item, "New Comment");
             User resolvingUser = new Admin();
             resolvingUser.Email = "resolvingUser@test.com";
             UserHandler resolvingUserHandler = new UserHandler(resolvingUser);
             bool result = item.Comments.Count == 1;
             if (result)
             {
                 resolvingUserHandler.ResolveComment(item.Comments.ElementAt(0));
                 result = item.Comments.ElementAt(0).ResolvingUser.Equals(resolvingUser);
             }
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
         public void TestResolveCommentBool()
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
             Coordinate newCoordinate = new Coordinate(2, 2);
             userHandler.CreateNewComment(item, "New Comment");
             User resolvingUser = new Admin();
             resolvingUser.Email = "resolvingUser@test.com";
             UserHandler resolvingUserHandler = new UserHandler(resolvingUser);
             bool result = item.Comments.Count == 1;
             if (result)
             {
                 result = resolvingUserHandler.ResolveComment(item.Comments.ElementAt(0));
             }
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
         public void TestResolveResolvedComment()
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
             Coordinate newCoordinate = new Coordinate(2, 2);
             userHandler.CreateNewComment(item, "New Comment");
             User resolvingUser = new Admin();
             resolvingUser.Email= "noresolvingUser@test.com"; 
             u.Email = "resolvingUser@test.com";
             UserHandler resolvingUserHandler = new UserHandler(resolvingUser);
             bool result = item.Comments.Count == 1;           
             if (result)
             {
                 userHandler.ResolveComment(item.Comments.ElementAt(0));
                 resolvingUserHandler.ResolveComment(item.Comments.ElementAt(0));
                 result = item.Comments.ElementAt(0).ResolvingUser.Equals(u);
             }
             //assertion
             Assert.IsTrue(result);
         }
         [TestMethod]
         public void TestResolveResolvedCommentBool()
         {
             //instance
             User u = new Collaborator();
             UserHandler userHandler = new UserHandler(u);
             Item item = new TextBox();
             Coordinate newCoordinate = new Coordinate(2, 2);
             userHandler.CreateNewComment(item, "New Comment");
             User resolvingUser = new Admin();
             u.Email = "resolvingUser@test.com";
             UserHandler resolvingUserHandler = new UserHandler(resolvingUser);
             bool result = item.Comments.Count == 1;
             if (result)
             {
                 userHandler.ResolveComment(item.Comments.ElementAt(0));   
                 result = resolvingUserHandler.ResolveComment(item.Comments.ElementAt(0));
             }
             //assertion
             Assert.IsFalse(result);
         }
         */
    }  
}
