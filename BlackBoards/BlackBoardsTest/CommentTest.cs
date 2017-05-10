﻿using System;
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
            String comment = "";

            Comment aComment = new Comment(commentingUser, resolvingUser, commentingDate, resolvingDate, comment);

            Comment otherComment = new Comment();
            otherComment.CommentingUser = commentingUser;
            otherComment.ResolvingUser = resolvingUser;
            otherComment.CommentingDate = commentingDate;
            otherComment.ResolvingDate = resolvingDate;
            otherComment.Comment = comment;
      
            Assert.IsTrue(aComment.Equals(otherComment));
        }

        [TestMethod]
        public void TestEqualsComment()
        {
            Admin resolvingUser = Admin("nameResolvingTest", "lastNameResolvingTest", "emailResolvingTest", new DateTime(), "passwordResolvingTest");
            Admin commentingUser = Admin("nameCommentingTest", "lastNameCommentingTest", "emailCommentingTest", new DateTime(), "passwordCommentingTest");
            Comment aComment = new Comment();
            aComment.CommentingUser = commentingUser;
            aComment.ResolvingUser = resolvingUser;
            aComment.CommentingDate = DateTime.MinValue; 
            aComment.ResolvingDate = DateTime.MinValue;
            aComment.Comment = "CommentTest";
            Comment otherComment = new Comment();
            otherComment.CommentingUser = commentingUser;
            otherComment.ResolvingUser = resolvingUser;
            otherComment.CommentingDate = DateTime.MaxValue; 
            otherComment.ResolvingDate = DateTime.MaxValue;
            otherComment.Comment = "CommentTest";

            Assert.IsFalse(aComment.Equals(otherComment));
        }
    }
}
