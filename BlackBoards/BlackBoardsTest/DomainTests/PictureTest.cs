using BlackBoards;
using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BlackBoardsTest
{
    [TestClass]
    public class PictureTest
    {
        private Picture setUpPicture()
        {
            Picture aSetUpPicture = new Picture();
            List<Comment> comments = new List<Comment>();
            aSetUpPicture.Dimension = new Dimension(50, 50);
            Coordinate origin = new Coordinate();
            aSetUpPicture.Origin = origin;
            aSetUpPicture.Description = "Example Description";
            return aSetUpPicture;
        }
        [TestMethod]
        public void TestPictureBuilder()
        {
            Picture aPic = new Picture();
            List<Comment> comments = new List<Comment>();
            aPic.Dimension = new Dimension(1, 1);
            Coordinate origin = new Coordinate();
            aPic.Origin = origin;
            aPic.Comments = comments;
            string proyectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string defualtImagePath = proyectPath + "\\Images\\default.jpg";
            Picture anotherPic = new Picture(new Dimension(1, 1), comments, origin);
            bool result = aPic.Equals(anotherPic);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsPicture()
        {
            Picture aPic = new Picture();
            Assert.IsTrue(aPic.IsPicture());
        }
        [TestMethod]
        public void TestIsPictureItem()
        {
            Item aPic = new Picture();
            Assert.IsTrue(aPic.IsPicture());
        }
        [TestMethod]
        public void TestPictureNotEquals()
        {
            Picture aPic = new Picture();
            aPic.Dimension = new Dimension(1, 1);
            aPic.Comments = new List<Comment>();
            Coordinate origin = new Coordinate();
            aPic.Origin = origin;
            origin.XAxis = 10;
            Picture anotherPic = new Picture(new Dimension(1, 1), new List<Comment>(), origin);
            bool result = aPic.Equals(anotherPic);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestPictureValidationReturnFalse()
        {
            Picture aPic = setUpPicture();
            aPic.Img = null;
            ValidationReturn validationResult = aPic.IsValid();
            bool result = validationResult.Validation;
            Assert.IsFalse(result);
        }
    }
}
