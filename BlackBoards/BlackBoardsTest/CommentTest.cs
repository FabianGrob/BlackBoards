using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackBoardsTest
{
    [TestClass]
    public class CommentTest
    {
        [TestMethod]
        public void TestBuilderComment()
        {
            User commentingUser = new Admin();
            User resolvingUser = new Admin();
            DateTime commentingDate = new DateTime();
            DateTime resolvingDate = new DateTime();
            
            Comment aComment = new Comment(commentingUser, resolvingUser, commentingDate, resolvingDate);

            Comment otherComment = new Comment();
            otherComment.CommentingUser = commentingUser;
            otherComment.ResolvingUser = resolvingUser;
            otherComment.CommentingDate = commentingDate;
            otherComment.ResolvingDate = resolvingDate;
      
            Assert.IsTrue(aComment.Equals(otherComment));
        }
    }
}
