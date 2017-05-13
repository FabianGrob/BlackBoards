using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class TeamHandler
    {
        private Team team;

        public TeamHandler(Team aTeam) {
            this.team = aTeam;
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
        public bool AddBlackBoard(BlackBoard aBoard) {
            bool valid = aBoard.Dimension.Height > 3 && aBoard.Dimension.Width > 3;
            if (valid) {
                this.Team.Boards.Add(aBoard);
            }
            return valid;
        }
    }
}
