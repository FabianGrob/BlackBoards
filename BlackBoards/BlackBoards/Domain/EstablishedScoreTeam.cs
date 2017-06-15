using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class EstablishedScoreTeam
    {
        public int ID { get; set; }
        private Team team;
        private Score score;
        public EstablishedScoreTeam()
        {
            this.team = new Team();
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
            return this.team.Equals(team);
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
