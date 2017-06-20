using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class ScoreUserInTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDScoreUserInTeam { get; set; }
        public virtual Team theTeam { get; set; }
        public virtual User theUser { get; set; }
        private Score score;
        public ScoreUserInTeam()
        {
            this.theTeam = new Team();
            this.theUser = new Admin();
            this.score = new Score();
        }
        public Team Team
        {
            get
            {
                return this.theTeam;
            }
            set
            {
                this.theTeam = value;
            }
        }
        public User User
        {
            get
            {
                return this.theUser;
            }
            set
            {
                this.theUser = value;
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
        private bool IsOfUser(User user)
        {
            return this.theUser.Equals(user);
        }
        private bool IsOfTeam(Team team)
        {
            return this.theTeam.Equals(team);
        }
        private bool IsThisScore(Score score)
        {
            return this.score.Equals(score);
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
            bool scoreEquals = this.IsThisScore(otherScoreUserInTeam.Score);
            bool teamEquals = this.IsOfTeam(otherScoreUserInTeam.Team);
            bool userEquals = this.IsOfUser(otherScoreUserInTeam.User);
            return (scoreEquals && teamEquals && userEquals);
        }
    }
}
