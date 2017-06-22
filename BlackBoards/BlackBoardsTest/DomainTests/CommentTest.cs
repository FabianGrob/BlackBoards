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
            Admin resolvingUser = new Admin("nameResolvingTest", "lastNameResolvingTest", "emailResolvingTest", new DateTime(), "passwordResolvingTest");
            Admin commentingUser = new Admin("nameCommentingTest", "lastNameCommentingTest", "emailCommentingTest", new DateTime(), "passwordCommentingTest");
            DateTime commentingDate = new DateTime();
            DateTime resolvingDate = new DateTime();
            String comment = "testComment";

            Comment aComment = new Comment(commentingUser, resolvingUser, commentingDate, resolvingDate, comment);

            Comment otherComment = new Comment();
            otherComment.commentingUser = commentingUser;
            otherComment.resolvingUser = resolvingUser;
            otherComment.CommentingDate = commentingDate;
            otherComment.ResolvingDate = resolvingDate;
            otherComment.WrittenComment = comment;
      
            Assert.IsTrue(aComment.Equals(otherComment));
        }

        [TestMethod]
        public void TestEqualsComment()
        {
            Admin resolvingUser = new Admin("nameResolvingTest", "lastNameResolvingTest", "emailResolvingTest", new DateTime(), "passwordResolvingTest");
            Admin commentingUser = new Admin("nameCommentingTest", "lastNameCommentingTest", "emailCommentingTest", new DateTime(), "passwordCommentingTest");
            Comment aComment = new Comment();
            aComment.commentingUser = commentingUser;
            aComment.resolvingUser = resolvingUser;
            aComment.CommentingDate = DateTime.MinValue; 
            aComment.ResolvingDate = DateTime.MinValue;
            aComment.WrittenComment = "CommentTest";
            Comment otherComment = new Comment();
            otherComment.commentingUser = commentingUser;
            otherComment.resolvingUser = resolvingUser;
            otherComment.CommentingDate = DateTime.MaxValue; 
            otherComment.ResolvingDate = DateTime.MaxValue;
            otherComment.WrittenComment = "CommentTest";

            Assert.IsFalse(aComment.Equals(otherComment));
        }
    }
}
