using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
   public class Team
    {
        private string name;
        private string description;
        private DateTime creationDate;
        private int maxUsers;
        private List<User> members;
        private List<BlackBoard> boards;
        public Team() {
            this.name = "Default name";
            this.creationDate = new DateTime();
            this.description = "Default description";
            this.maxUsers = 10;
            this.members = new List<User>();
            this.boards = new List<BlackBoard>();

        }
        public Team(string aName,DateTime aCreationDate, string aDescription,int maximumUsers,List<User>someMembers,List<BlackBoard> someBoards) {
            this.name = aName;
            this.creationDate = aCreationDate;
            this.description = aDescription;
            this.maxUsers = maximumUsers;
            this.members = someMembers;
            this.boards = someBoards;
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
        public DateTime CreationDate
        {
            get
            {
                return this.creationDate;
            }
            set
            {
                this.creationDate = value;
            }
        }
        public int MaxUsers
        {
            get
            {
                return this.maxUsers;
            }
            set
            {
                this.maxUsers = value;
            }
        }

        public List<User> Members
        {
            get
            {
                return this.members;
            }
            set
            {
                this.members = value;
            }
        }
        public List<BlackBoard> Boards
        {
            get
            {
                return this.boards;
            }
            set
            {
                this.boards = value;
            }
        }
        
        public override bool Equals(object aTeam)
        {
            if (aTeam == null)
            {
                return false;
            }
            Team anotherTeam = aTeam as Team;
            if ((System.Object)anotherTeam == null)
            {
                return false;
            }
            return this.Name.Equals(anotherTeam.Name);
        }
    }
}
