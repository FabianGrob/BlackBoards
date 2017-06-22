using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void TestResolvedComment()
        {
            Comment aCommentTest = new Comment();
            aCommentTest.CommentingDate = DateTime.Now;
            aCommentTest.ResolvingDate = DateTime.Now;
            CommentHandler commentHandler = new CommentHandler(aCommentTest);
            Assert.IsTrue(commentHandler.WasResolved());
        }
        [TestMethod]
        public void TestUnResolvedComment()
        {
            Comment aCommentTest = new Comment();
            aCommentTest.CommentingDate = DateTime.Now;
            aCommentTest.ResolvingDate = DateTime.Now.AddDays(-1);
            CommentHandler commentHandler = new CommentHandler(aCommentTest);
            Assert.IsFalse(commentHandler.WasResolved());
        }
    }
}
