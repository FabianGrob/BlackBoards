﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackBoards;
using BlackBoards.Handlers;
using System.Threading.Tasks;


        
namespace BlackBoardsTest.HandlersTests
{
    [TestClass]
    public class CommentHandlerTest
    {
        [TestMethod]
        public void TestCreateComment()
        {
            User anUser = new Admin();
            string comment = "This is a test comment.";
            CommentHandler commentHandler= new CommentHandler();
            commentHandler.CreateComment(anUser, comment);
            bool userEquals = anUser.Equals(commentHandler.Comment.CommentingUser);
            bool commentEquals = comment.Equals(commentHandler.Comment.WrittenComment);
            bool dateEquals = DateTime.Today.Equals(commentHandler.Comment.CommentingDate);

            Assert.IsTrue(userEquals && commentEquals && dateEquals);         
        }
        [TestMethod]
        public void TestResolveComment()
        {
            User anUser = new Admin();
            CommentHandler commentHandler = new CommentHandler();
            commentHandler.ResolveComment(anUser);
            bool userEquals = anUser.Equals(commentHandler.Comment.ResolvingUser);
            bool dateEquals = DateTime.Today.Equals(commentHandler.Comment.ResolvingDate);
            Assert.IsTrue(userEquals && dateEquals);
        }
    }
}