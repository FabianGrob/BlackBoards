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
       
    }
    
}
