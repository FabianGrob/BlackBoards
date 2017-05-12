using System;
using System.Collections.Generic;
namespace BlackBoards
{
    public class Repository
    {
        private List<Admin> administratorList;
        private List<User> userList;
        private List<Team> teamList;
      

      
        public Repository()
        {
            this.administratorList = new List<Admin>();
            this.userList = new List<User>();
            this.teamList = new List<Team>();
           
        }
        public Repository(List<Admin> administratorList, List<User> userList, List<Team> teamList)
        {
            this.administratorList = administratorList;
            this.userList = userList;
            this.teamList = teamList;

        }
        public List<Admin> AdministratorList
        {
            get
            {
                return this.administratorList;
            }
            set
            {
                this.administratorList = value;
            }
        }
        public List<User> UserList
        {
            get
            {
                return this.userList;
            }
            set
            {
                this.userList = value;
            }
        }

        public List<Team> TeamList
        {
            get
            {
                return this.teamList;
            }
            set
            {
                this.teamList = value;
            }
        }


    }
}
