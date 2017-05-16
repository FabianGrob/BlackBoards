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
        private string writtenComment;
        public Comment()
        {
            this.CommentingUser = new Admin();
            this.ResolvingUser = new Admin();
            this.CommentingDate = new DateTime();
            this.ResolvingDate = DateTime.MaxValue;
            this.WrittenComment = "Default written comment";
        }

        public Comment(User commentingUser, User resolvingUser, DateTime commentingDate, DateTime resolvingDate, string writtenComment)
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
        public string WrittenComment
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
        public bool IsValid() {
            return this.WrittenComment.Length > 0;
        }
        public override bool Equals(object aComment)
        {
            if (aComment == null)
            {
                return false;
            }
            Comment anotherComment = aComment as Comment;
            if ((System.Object)anotherComment == null)
            {
                return false;
            }

            bool dateEquals = this.ResolvingDate.Equals(anotherComment.ResolvingDate) && this.CommentingDate.Equals(anotherComment.CommentingDate);
            bool userEquals = this.ResolvingUser.Equals(anotherComment.ResolvingUser) && this.CommentingUser.Equals(anotherComment.CommentingUser);
            bool writtenCommentEquals = this.WrittenComment.Equals(anotherComment.WrittenComment);

            return (dateEquals && userEquals&& writtenCommentEquals);
        }
        public override string ToString()
        {
            bool resolved = !this.resolvingUser.Email.Equals("Default email");
            string res = " no resuelto";
            if (resolved)
            {
                res = "resuelto";
            }
            return this.writtenComment + "| Por: "+ this.commentingUser+ " " + res;
        }
    }
}
