using BlackBoards;
using BlackBoards.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest.HandlerTests
{
    [TestClass]
    public class TextBoxHandlerTest
    {
        [TestMethod]
        public void TestTextBoxHandler() {
            TextBox aTbx = new TextBox();
            TextBox otherTbx = new TextBox(aTbx);
            TextBoxHandler handler = new TextBoxHandler(aTbx);
            bool result = otherTbx.Equals(handler.TextBox);
            Assert.IsTrue(result);
        }
    }
}
