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
    public class EstablishedScoreTeamTest
    {
        private EstablishedScoreTeam setUp()
        {
            EstablishedScoreTeam newEstablishedScoreTeam = new EstablishedScoreTeam(); 
            Score newScore = new Score(5, 4, 3, 1, 7);
            String name = "testName";
            DateTime creationDate = new DateTime();
            String description = "testDescription";
            int maximumUsers = 10;
            List<User> members = new List<User>();
            List<BlackBoard> boards = new List<BlackBoard>();
            Team newTeam = new Team(name, creationDate, description, maximumUsers, members, boards);
            newEstablishedScoreTeam.teamScore = newTeam;
            newEstablishedScoreTeam.score = newScore;
            return newEstablishedScoreTeam;
        }
        [TestMethod]
        public void TestBuilderEstablishedScoreTeam()
        {
            //instance
            EstablishedScoreTeam aScoreUserInTeamTest = setUp();
            EstablishedScoreTeam anotherScoreUserInTeamTest = setUp();
            bool result = aScoreUserInTeamTest.Equals(anotherScoreUserInTeamTest);
            //assertion
            Assert.IsTrue(result);
        }    
    }
}
