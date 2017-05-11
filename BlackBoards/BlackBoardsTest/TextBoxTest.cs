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
            TextBox aTextBox = new TextBox();
            aTextBox.Width = 1;
            aTextBox.Heigth = 2;
            List<Comment> comments = new List<Comment>();
            aTextBox.Comments=comments ;
            int[] origin = new int[2];
            origin[0] = 1;
            origin[1] = 1;
            aTextBox.Origin = origin;
            aTextBox.Content = "TestContent";
            aTextBox.Font = "Arial";
            aTextBox.FontSize = 14;
            TextBox anotherTextBox = new TextBox(1, 2,comments,origin,"TestContent","Arial",14);
            bool result = aTextBox.Equals(anotherTextBox);
            Assert.IsTrue(result);

        }
        //tiene un ancho, una altura, una lista de comentarios y un punto de origen
        //Cuadro de texto: tiene un contenido, el cual puede tener distinto tamaño y tipo de letra.


    }
}
