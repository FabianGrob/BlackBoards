using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class ScoreUserInTeam
    {
        private Team team;
        private User user;
        private Score score;
        public ScoreUserInTeam()
        {
            this.team = new Team();
            this.user = new Admin();
            this.score = new Score();
        }
        public Team Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
            }
        }
        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }
        public Score Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }
        public override bool Equals(object aScoreUserInTeam)
        {
            if (aScoreUserInTeam == null)
            {
                return false;
            }
            ScoreUserInTeam otherScoreUserInTeam = aScoreUserInTeam as ScoreUserInTeam;
            if ((System.Object)otherScoreUserInTeam == null)
            {
                return false;
            }
            bool scoreEquals = (this.score.Equals(otherScoreUserInTeam.Score));
            bool teamEquals = (this.team.Equals(otherScoreUserInTeam.Team));
            bool userEquals = (this.user.Equals(otherScoreUserInTeam.User));
            return (scoreEquals && teamEquals && userEquals);
        }
    }
}
