using BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest.HandlerTests
{
    [TestClass]
    public class AdminHandlerTest
    {
        [TestMethod]
        public void TestAdminHandlerBuilder() {

            Admin admin = new Admin();
            AdminHandler handler = new AdminHandler(admin);

            bool result = admin.Equals(handler.Admin);
            Assert.IsTrue(result);
        }
    }
}
