using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackBoards;
using System.Threading.Tasks;
using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;

namespace BlackBoardsTest
{
    [TestClass]
    public class TextBoxTest
    {
        private TextBox setUpTextBox()
        {
            TextBox aSetUpTextBox = new TextBox();
            List<Comment> comments = new List<Comment>();
            aSetUpTextBox.Dimension = new Dimension(50, 50);
            Coordinate origin = new Coordinate();
            aSetUpTextBox.Origin = origin;
            aSetUpTextBox.Content = "TestContent";
            aSetUpTextBox.Font = "Arial";
            aSetUpTextBox.FontSize = 14;
            return aSetUpTextBox;
        }
        [TestMethod]
        public void TestTextBoxBuilder()
        {
            //instance
            TextBox aTextBox = new TextBox();
            aTextBox.Dimension = new Dimension(1, 2);
            List<Comment> comments = new List<Comment>();
            aTextBox.Comments = comments;
            Coordinate origin = new Coordinate();
            aTextBox.Origin = origin;
            aTextBox.Content = "TestContent";
            aTextBox.Font = "Arial";
            aTextBox.FontSize = 14;
            TextBox anotherTextBox = new TextBox(new Dimension(1, 2), comments, origin, "TestContent", "Arial", 14);
            //assertion
            bool result = aTextBox.Equals(anotherTextBox);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestTextBoxEquals()
        {
            Coordinate origin = new Coordinate();
            TextBox aTextBox = new TextBox(new Dimension(1, 2), new List<Comment>(), origin, "TestContent", "Arial", 14);
            TextBox anotherTextBox = new TextBox(new Dimension(1, 2), new List<Comment>(), origin, "TestContent2", "Verdana", 11);
            Assert.AreNotEqual(aTextBox, anotherTextBox);
        }
        [TestMethod]
        public void TestTextBoxValid()
        {
            //instance
            TextBox aTextBox = setUpTextBox();
            ValidationReturn validations = aTextBox.isValid();
            bool result = validations.Validation;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestTextBoxInvalidSize()
        {
            TextBox aTextBox = setUpTextBox();
            //instance
            aTextBox.FontSize = 0;
            ValidationReturn validations = aTextBox.isValid();
            bool result = validations.Validation;
            //assertion
            Assert.IsFalse(result);
        }
       
    }
}
