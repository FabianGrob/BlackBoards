using BlackBoards;
using BlackBoards.Domain;
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
    public class ItemHandlerTest
    {
       [TestMethod]
        public void ItemHandlerBuilder() {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            //assertion
            bool result = anotherItem.Equals(handler.Item);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ItemHandlerDifferents()
        {
            //instance
            Item anItem = new TextBox();
            anItem.IDItem = 5;
            Item anotherItem = new Picture();
            ItemHandler handler = new ItemHandler(anItem);
            //assertion
            bool result = anotherItem.Equals(handler.Item);
            Assert.IsFalse(result);
        }
    }
}
