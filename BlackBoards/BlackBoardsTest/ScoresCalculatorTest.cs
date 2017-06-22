using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackBoards.Handlers;
using BlackBoards.Domain;

namespace BlackBoardsTest
{
    [TestClass]
    public class ScoresCalculatorTest
    {

        [TestMethod]
        public void CalculeScoreNull()
        {
            ScoresCalculator calculator = new ScoresCalculator(new EstablishedScoreTeam(), new List<ScoreUserInTeam>());
            int totalScore = calculator.CalculateScoreOfATeam();
            Assert.IsTrue(totalScore == 0);
        }
        [TestMethod]
        public void CalculeScoreOne()
        {
            Score aScore = new Score(2, 2, 2, 2, 2);
            EstablishedScoreTeam score = new EstablishedScoreTeam(new BlackBoards.Team());
            score.score = aScore;
            List<ScoreUserInTeam> scores = new List<ScoreUserInTeam>();
            ScoreUserInTeam newScore = new ScoreUserInTeam();
            newScore.Score = aScore;
            newScore.theTeam = new BlackBoards.Team();
            newScore.theUser = new BlackBoards.Admin();
            scores.Add(newScore);
            ScoresCalculator calculator = new ScoresCalculator(score, scores);
            int totalScore = calculator.CalculateScoreOfATeam();
            Assert.IsTrue(totalScore == 20);
        }
        [TestMethod]
        public void CalculeScoreTwo()
        {
            Score aScore = new Score(2, 2, 2, 2, 2);
            Score anotherScore = new Score(1, 2, 1, 2, 1);
            Score anotherOneScore = new Score(2, 1, 2, 1, 2);
            EstablishedScoreTeam score = new EstablishedScoreTeam(new BlackBoards.Team());
            score.score = aScore;
            List<ScoreUserInTeam> scores = new List<ScoreUserInTeam>();
            ScoreUserInTeam newScore = new ScoreUserInTeam();
            ScoreUserInTeam newScore2 = new ScoreUserInTeam();
            ScoreUserInTeam newScore3 = new ScoreUserInTeam();
            newScore.Score = aScore;
            newScore.theTeam = new BlackBoards.Team();
            newScore.theUser = new BlackBoards.Admin();
            newScore2.Score = anotherScore;
            newScore2.theTeam = new BlackBoards.Team();
            newScore2.theUser = new BlackBoards.Admin();
            newScore3.Score = anotherOneScore;
            newScore3.theTeam = new BlackBoards.Team();
            newScore3.theUser = new BlackBoards.Admin();
            scores.Add(newScore);
            scores.Add(newScore2);
            scores.Add(newScore3);
            ScoresCalculator calculator = new ScoresCalculator(score, scores);
            int totalScore = calculator.CalculateScoreOfATeam();
            Assert.IsTrue(totalScore == 50);
        }
    }
}
