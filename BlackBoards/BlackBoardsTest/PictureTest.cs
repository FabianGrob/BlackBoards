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
    public class PictureTest
    {
        [TestMethod]
        public void TestPictureBuilder() {
            Picture aPic = new Picture();
            // Un elemento tiene un ancho, una altura, una lista de comentarios y un punto de origen
            aPic.Heigth = 1;
            aPic.Width = 1;
            aPic.Comments = new List<Comment>();
            aPic.Origin = { 1, 1};
            
            Picture anotherPic = new Picture(1, 1, new List<Comment>(),{1,1});
            Assert.Equals(aPic,anotherPic);
        }
    }
}
