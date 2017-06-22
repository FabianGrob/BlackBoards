using BlackBoards;
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
    public class ScoreUserInTeamTest
    {
        private ScoreUserInTeam setUp()
        {
            ScoreUserInTeam scoreUserInTeamTest = new ScoreUserInTeam();
            Score newScore = new Score(5,4,3,1,7);
            String name = "testName";
            DateTime creationDate = new DateTime();
            String description = "testDescription";
            int maximumUsers = 10;
            List<User> members = new List<User>();
            List<BlackBoard> boards = new List<BlackBoard>();
            Team newTeam = new Team(name, creationDate, description, maximumUsers, members, boards);
            String lastName = "testLastName";
            String email = "testEmail";
            DateTime birthDate = new DateTime();
            String password = "testPassword";
            User newUser = new Admin(name, lastName, email, birthDate, password);
            scoreUserInTeamTest.theTeam = newTeam;
            scoreUserInTeamTest.Score = newScore;
            scoreUserInTeamTest.theUser = newUser;
            return scoreUserInTeamTest;
        }
        [TestMethod]
        public void TestBuilderScoreUserInTeamTest()
        {
            //instance
            ScoreUserInTeam aScoreUserInTeamTest = setUp();
            ScoreUserInTeam anotherScoreUserInTeamTest = setUp();
            bool result = aScoreUserInTeamTest.Equals(anotherScoreUserInTeamTest);
            //assertion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEqualsScoreUserInTeamTest()
        {
            //instance
            ScoreUserInTeam aScoreUserInTeamTest = setUp();
            ScoreUserInTeam anotherScoreUserInTeamTest = new ScoreUserInTeam();
            bool result = aScoreUserInTeamTest.Equals(anotherScoreUserInTeamTest);
            //assertion
            Assert.IsFalse(result);
        }
    }
}
