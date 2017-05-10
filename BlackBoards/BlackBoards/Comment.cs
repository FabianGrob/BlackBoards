using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Comment
    {
        private User commentingUser;
        private User resolvingUser;
        private DateTime commentingDate;
        private DateTime resolvingDate;
        private String writtenComment;
        public Comment()
        {

        }

        public Comment(User commentingUser, User resolvingUser, DateTime commentingDate, DateTime resolvingDate, String comment)
        {
            this.CommentingUser = commentingUser;
            this.ResolvingUser = resolvingUser;
            this.CommentingDate = commentingDate;
            this.ResolvingDate = resolvingDate;
            this.WrittenComment = writtenComment;
        }
        public User CommentingUser
        {
            get
            {
                return this.commentingUser;
            }
            set
            {
                this.commentingUser = value;
            }
        }

        public User ResolvingUser
        {
            get
            {
                return this.resolvingUser;
            }
            set
            {
                this.resolvingUser = value;
            }
        }
        public DateTime CommentingDate
        {
            get
            {
                return this.commentingDate;
            }
            set
            {
                this.commentingDate = value;
            }
        }
        public DateTime ResolvingDate
        {
            get
            {
                return this.resolvingDate;
            }
            set
            {
                this.resolvingDate = value;
            }
        }
        public String WrittenComment
        {
            get
            {
                return this.writtenComment;
            }
            set
            {
                this.writtenComment = value;
            }
        }
    }
}
