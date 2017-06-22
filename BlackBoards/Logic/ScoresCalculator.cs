using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class ScoresCalculator
    {
        private EstablishedScoreTeam establishedScore;
        private List<ScoreUserInTeam> scoreUser;
        public ScoresCalculator(EstablishedScoreTeam establishedScore, List<ScoreUserInTeam> scoreUser)
        {
            this.establishedScore = establishedScore;
            this.scoreUser = scoreUser;
        }
        public int CalculateScoreOfATeam()
        {
            int totalScoreTeam = 0;
            foreach (ScoreUserInTeam actualScoreTeam in this.scoreUser)
            {
                Score actualScore = new Domain.Score(actualScoreTeam.Score.CreateBlackBoard, actualScoreTeam.Score.DeleteBlackBoard,
                    actualScoreTeam.Score.AddItem, actualScoreTeam.Score.AddComment, actualScoreTeam.Score.SolveComment);
                totalScoreTeam = totalScoreTeam + actualScore.CalculateScore(this.establishedScore.score);
            }
            return totalScoreTeam;
        }
    }
}
