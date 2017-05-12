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

        public UserHandler(User anUser) {
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
    }
}
