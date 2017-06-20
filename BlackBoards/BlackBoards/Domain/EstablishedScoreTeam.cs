using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class EstablishedScoreTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public virtual Team teamScore { get; set; }
        private Score score;
        public EstablishedScoreTeam()
        {
            this.teamScore = new Team();
            this.score = new Score();
        }
        public Team Team
        {
            get
            {
                return this.teamScore;
            }
            set
            {
                this.teamScore = value;
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
        private bool IsOfTeam(Team team)
        {
            return this.teamScore.Equals(team);
        }
        public override bool Equals(object aEstablishedScoreTeam)
        {
            if (aEstablishedScoreTeam == null)
            {
                return false;
            }
            EstablishedScoreTeam anotherEstablishedScoreTeam = aEstablishedScoreTeam as EstablishedScoreTeam;
            if ((System.Object)anotherEstablishedScoreTeam == null)
            {
                return false;
            }
            return this.IsOfTeam(anotherEstablishedScoreTeam.Team);
        }
    }
}
