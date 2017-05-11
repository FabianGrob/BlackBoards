using System;
using System.Collections.Generic;
namespace BlackBoards
{
    public class Repository
    {
        private List<Admin> administratorList;
        private List<User> userList;
        private List<BlackBoard> blackBoardList;

        // [Obsolete("constructor only usable by EntityFramework", true)]
        public Repository()
        {
            this.administratorList = new List<Admin>();
            this.userList = new List<User>();
            this.blackBoardList = new List<BlackBoard>();
        }
        public Repository(List<Admin> administratorList, List<User> userList, List<BlackBoard> blackBoardList)
        {
            this.administratorList = administratorList;
            this.userList = userList;
            this.blackBoardList = blackBoardList;
        }

        public List<Admin> AdministradorList
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

        public List<BlackBoard> BlackBoardList
        {
            get
            {
                return this.blackBoardList;
            }
            set
            {
                this.blackBoardList = value;
            }
        }
    }
}
