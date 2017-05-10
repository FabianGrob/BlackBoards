using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
   public class Team
    {
        private String name;
        private String description;
        private DateTime creationDate;
        private int maxUsers;
        public Team() {

        }
        public Team(String aName,DateTime aCreationDate,String aDescription,int maximumUsers) {
            this.name = aName;
            this.creationDate = aCreationDate;
            this.description = aDescription;
            this.maxUsers = maximumUsers;
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
    }
}
