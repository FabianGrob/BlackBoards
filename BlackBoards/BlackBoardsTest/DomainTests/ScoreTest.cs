using BlackBoards.Domain;
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
            Score scoreTest = new Score();
            Score anotherScoreTest = new Score(0,0,0,0,0);
            bool result = scoreTest.Equals(anotherScoreTest);
            Assert.IsTrue(result);
        }
    }
}
