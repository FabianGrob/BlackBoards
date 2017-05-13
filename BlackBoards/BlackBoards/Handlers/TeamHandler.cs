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
            return this.Team.AddNewBlackBoard(aBoard);
        }
        public bool RemoveBlackBoard(BlackBoard aBoard) {
            bool exists = this.Team.Boards.Contains(aBoard);
            if (exists)
            {
                this.Team.Boards.Remove(aBoard);
            }
            return exists;
            
        }
        
    }
}
