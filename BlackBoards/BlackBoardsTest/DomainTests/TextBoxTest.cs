using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackBoards;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
   public class TextBoxTest
    {
        [TestMethod]
        public void TestTextBoxBuilder() {
            //instance
            TextBox aTextBox = new TextBox();
            aTextBox.Width = 1;
            aTextBox.Heigth = 2;
            List<Comment> comments = new List<Comment>();
            aTextBox.Comments=comments ;
            Coordinate origin = new Coordinate();
            aTextBox.Origin = origin;
            aTextBox.Content = "TestContent";
            aTextBox.Font = "Arial";
            aTextBox.FontSize = 14;
            TextBox anotherTextBox = new TextBox(1, 2,comments,origin,"TestContent","Arial",14);
            //assertion
            bool result = aTextBox.Equals(anotherTextBox);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void TestTextBoxEquals() {
            Coordinate origin = new Coordinate();
            TextBox aTextBox = new TextBox(1, 2, new List<Comment>(), origin, "TestContent", "Arial", 14);
            TextBox anotherTextBox = new TextBox(1, 2, new List<Comment>(), origin, "TestContent2", "Verdana", 11);
            Assert.AreNotEqual(aTextBox, anotherTextBox);
        }
    
    }
}
