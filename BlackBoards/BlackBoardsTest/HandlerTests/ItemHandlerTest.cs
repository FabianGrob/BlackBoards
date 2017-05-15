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
            //assertion
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
            anotherItem.Dimension = newDimension;
            handler.ChangeDimension(newDimension);
           
            //assertion
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
            //assertion
            bool result = handler.Item.Equals(anItem);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestAddComment()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox();
            ItemHandler handler = new ItemHandler(anotherItem);
            Comment aComment = new Comment();
            handler.AddComment(aComment);
            //assertion
            bool result = anItem.Comments.Count==handler.Item.Comments.Count;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddCommentDifferents()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox();
            ItemHandler handler = new ItemHandler(anItem);
            Comment aComment = new Comment();
            handler.AddComment(aComment);
            handler = new ItemHandler(anotherItem);
            aComment.WrittenComment = "another Comment";
            handler.AddComment(aComment);
            //assertion
            bool result = true;
            if (handler.Item.Comments.Count > 0 && handler.Item.Comments.Count == anItem.Comments.Count)
            {
                result = result && !anItem.Comments.ElementAt(0).Equals(handler.Item.Comments.ElementAt(0));
            }
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddCommentSame()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox();
            ItemHandler handler = new ItemHandler(anItem);
            Comment aComment = new Comment();
            handler.AddComment(aComment);
            handler = new ItemHandler(anotherItem);
            handler.AddComment(aComment);
            //assertion
            bool result = true;
            if (handler.Item.Comments.Count > 0 && handler.Item.Comments.Count == anItem.Comments.Count)
            {
                result = result && anItem.Comments.ElementAt(0).Equals(handler.Item.Comments.ElementAt(0));
            }
            
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddCommentInvalid()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox();
            ItemHandler handler = new ItemHandler(anItem);
            Comment aComment = new Comment();
            aComment.WrittenComment = "";
            //assertion
            bool result = handler.AddComment(aComment);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddCommentValid()
        {
            //instance
            Item anItem = new TextBox();
            Item anotherItem = new TextBox();
            ItemHandler handler = new ItemHandler(anItem);
            Comment aComment = new Comment();
            aComment.WrittenComment = "aValidComment";
            //assertion
            bool result = handler.AddComment(aComment);
            Assert.IsTrue(result);
        }




    }
}
