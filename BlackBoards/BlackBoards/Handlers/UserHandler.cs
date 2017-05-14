using BlackBoards.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class UserHandler
    {
        private User user;

        public UserHandler(User anUser)
        {
            this.user = anUser;
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
        public bool CreateBlackBoard(Team aTeam, BlackBoard aBlackBoard)
        {
            TeamHandler teamHandler = new TeamHandler(aTeam);
            bool isABlackBoardValid = teamHandler.AddBlackBoard(aBlackBoard);
            return isABlackBoardValid;
        }
        public bool RemoveBlackBoard(Team aTeam, BlackBoard aBlackBoard)
        {
            if (aBlackBoard.CreatorUser.Equals(this.user))
            {
                TeamHandler teamHandler = new TeamHandler(aTeam);
                bool isABlackBoardValid = teamHandler.RemoveBlackBoard(aBlackBoard);
                return isABlackBoardValid;
            }
            return false;
        }
        public bool AddItemToBlackBoard(BlackBoard aBlackBoard, Item aItem)
        {
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler(aBlackBoard);
            return blackBoardHandler.AddItem(aItem);
        }
    }
}