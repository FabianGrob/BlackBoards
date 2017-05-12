using System;
using System.Collections.Generic;
namespace BlackBoards
{
    public class Repository
    {
        private List<Admin> administratorList;
        private List<User> userList;
      

      
        public Repository()
        {
            this.administratorList = new List<Admin>();
            this.userList = new List<User>();
           
        }
        public Repository(List<Admin> administratorList, List<User> userList)
        {
            this.administratorList = administratorList;
            this.userList = userList;

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

        
    }
}
