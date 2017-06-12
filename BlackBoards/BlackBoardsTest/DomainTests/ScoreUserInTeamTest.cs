using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackBoardsTest
{
    [TestClass]
    public class ScoreUserInTeamTest
    {
        private ScoreUserInTeamTest setUp()
        {
            ScoreUserInTeamTest scoreUserInTeamTest = new ScoreUserInTeamTest();
            return scoreUserInTeamTest;
        }
        [TestMethod]
        public void TestBuilderScoreUserInTeamTest()
        {
            //instance
            ScoreUserInTeamTest aScoreUserInTeamTest = setUp();
            ScoreUserInTeamTest anotherScoreUserInTeamTest = setUp();
            bool result = aScoreUserInTeamTest.Equals(anotherScoreUserInTeamTest);
            //assertion
            Assert.IsTrue(result);
        }
    }
}
