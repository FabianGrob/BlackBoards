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
            List<Comment> comments =new List<Comment>();
            aPic.Heigth = 1;
            aPic.Width = 1;
            int[] origin = new int[2];
            origin[0] = 1;
            origin[1] = 1;

            aPic.Origin = origin;
            aPic.Comments = comments;
            Picture anotherPic = new Picture(1, 1, comments, origin);
            bool result = aPic.Equals(anotherPic);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestPictureNotEquals() {
            Picture aPic = new Picture();

            aPic.Heigth = 1;
            aPic.Width = 1;
            aPic.Comments = new List<Comment>();
            int[] origin = new int[2];
            origin[0] = 1;
            origin[1] = 1;
            aPic.Origin = origin;

            origin[1] = 10;
            Picture anotherPic = new Picture(1, 1, new List<Comment>(), origin);
            bool result = aPic.Equals(anotherPic);
            Assert.IsFalse(result);

        }
    }
    
}
