using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class BlackBoard
    {
        private String name;
        private String description;
        private int heigth;
        private int width;
        private Team team;
        public BlackBoard() {
            this.name = "Default name";
            this.description = "Default description";
            this.heigth = 0;
            this.width = 0;
            this.team = new Team();
        }
        public BlackBoard(String aName, String aDescription, int aHeigth, int aWidth, Team aTeam) {
            this.name = aName;
            this.description = aDescription;
            this.heigth = aHeigth;
            this.width = aWidth;
            this.team = aTeam;
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
        public String Description
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
        public int Heigth
        {
            get
            {
                return this.heigth;
            }
            set
            {
                this.heigth = value;
            }
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
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
