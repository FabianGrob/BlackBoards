using BlackBoards;
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


    }
    
}
