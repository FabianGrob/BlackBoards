using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void TestBuilderScore()
        {
            //instance
            Score scoreTest = new Score();
            Score anotherScoreTest = new Score(0,0,0,0,0);
            bool result = scoreTest.Equals(anotherScoreTest);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestValidScore()
        {
            //instance
            Score scoreTest = new Score(0, 0, 0, 0, 0);
            ValidationReturn validation = scoreTest.IsValid();
            bool result = validation.Validation;
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestInvalidScore()
        {
            Score scoreTest = new Score(-1, 0, 0, 0, 0);
            ValidationReturn validation = scoreTest.IsValid();
            bool result = validation.Validation;
            Assert.IsFalse(result);
        }
    }
}
