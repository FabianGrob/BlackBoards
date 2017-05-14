using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class BlackBoard
    {
        private List<Item> itemList;
        private string name;
        private string description;
        private Dimension dimension;
        private Team team;
        private User creatorUser;

        public BlackBoard() {
            this.name = "Default name";
            this.description = "Default description";
            this.dimension = new Dimension(5,5);
            this.team = new Team();
            this.itemList = new List<Item>();
            this.creatorUser = new Admin();
        }
        public BlackBoard(string aName, string aDescription, Dimension aDimension, Team aTeam, List<Item> itemList, User anUser) {
            this.name = aName;
            this.description = aDescription;
            this.dimension = aDimension;
            this.team = aTeam;
            this.itemList = itemList;
            this.creatorUser = anUser;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public Dimension Dimension
        {
            get
            {
                return this.dimension;
            }
            set
            {
                this.dimension = value;
            }
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
        public List<Item> ItemList
        {
            get
            {
                return this.itemList;
            }
            set
            {
                this.itemList = value;
            }
        }
        public User CreatorUser
        {
            get
            {
                return this.creatorUser;
            }
            set
            {
                this.creatorUser = value;
            }
        }
        public bool isValid() {
            return this.Dimension.Height > 3 && this.Dimension.Width > 3; 
        }
        public override bool Equals(object aBlackBoard)
        {
            if (aBlackBoard == null)
            {
                return false;
            }
            BlackBoard anotherBlackBoard = aBlackBoard as BlackBoard;
            if ((System.Object)anotherBlackBoard == null)
            {
                return false;
            }
            return this.Name.Equals(anotherBlackBoard.Name);
        }
    
    }
}
