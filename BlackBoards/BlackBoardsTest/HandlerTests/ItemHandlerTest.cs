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
    public class ItemHandlerTest
    {
        [TestMethod]
        public void ItemHandlerBuilder() {
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            bool result = anotherItem.Equals(handler.Item);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMoveItem()
        {
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Coordinate newCoordinates = new Coordinate(2, 2);
            handler.MoveItem(newCoordinates);
            bool result = handler.Item.Equals(anotherItem);
            Assert.IsFalse(result);

        }
    }
}
