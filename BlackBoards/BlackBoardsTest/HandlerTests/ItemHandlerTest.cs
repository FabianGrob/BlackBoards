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
        public void TestMoveItem()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Coordinate newCoordinates = new Coordinate(2, 2);
            handler.MoveItem(newCoordinates);
            //assertion
            bool result = handler.Item.Equals(anotherItem);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestMoveItemFixed()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Coordinate newCoordinates = new Coordinate(0,0);
            handler.MoveItem(newCoordinates);
            //assertion
            bool result = handler.Item.Equals(anotherItem);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestMoveItemSamePosition()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Coordinate newCoordinates = new Coordinate(4,4);
            handler.MoveItem(newCoordinates);
            handler = new ItemHandler(anotherItem);
            handler.MoveItem(new Coordinate(4,4));
            //assertion
            bool result = handler.Item.Equals(anItem);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestChangeDimension() {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Dimension newDimension = new Dimension(3,3);
            handler.ChangeDimension(newDimension);

            bool result = handler.Item.Equals(anotherItem);
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void TestChangeDimensionFixed()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Dimension newDimension = new Dimension(1,1);
            handler.ChangeDimension(newDimension);

            bool result = handler.Item.Equals(anotherItem);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestChangeDimensionSame()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox(anItem as TextBox);
            ItemHandler handler = new ItemHandler(anItem);
            Dimension newDimension = new Dimension(3, 3);
            handler.ChangeDimension(newDimension);
            handler = new ItemHandler(anotherItem);
            handler.ChangeDimension(newDimension);

            bool result = handler.Item.Equals(anItem);
            Assert.IsTrue(result);

        }
    }
}
