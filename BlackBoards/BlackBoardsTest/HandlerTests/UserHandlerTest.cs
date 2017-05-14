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
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            bool result = u.Equals(userHandler.User);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestCreateBlackBoard()
        {
            User u = new Collaborator();
            UserHandler userHandler = new UserHandler(u);
            Team aTeam = new Team();
            BlackBoard blackBoard = new BlackBoard();
            userHandler.CreateBlackBoard(aTeam,blackBoard);
            bool result = aTeam.Boards.Count == 1;
            Assert.IsTrue(result);
        }
        

    }
    
}
