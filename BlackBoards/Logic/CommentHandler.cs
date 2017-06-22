using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class CommentHandler
    {
        private Comment comment;
        public CommentHandler()
        {
            this.comment = new Comment();
        }
        public CommentHandler(Comment aComment)
        {
            this.comment = aComment;
        }
        public Comment Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
        public void CreateComment(User anUser, string newComment)
        {
            this.AddCommentingUser(anUser);
            this.WriteComment(newComment);
            this.AddCommentingDate(DateTime.Today);
            this.AddResolvingDate(DateTime.MaxValue);
            Admin admin = new Admin();
            this.AddResolvingUser(admin);

        }
        public bool ResolveComment(User anUser)
        {
            bool canResolveComment = !(this.WasResolved());
            if (canResolveComment)
            {
                this.AddResolvingUser(anUser);
                this.AddResolvingDate(DateTime.Today);
            }
            return canResolveComment;
        }
        private bool WasResolved()
        {
            return !(this.Comment.ResolvingDate.Equals(DateTime.MaxValue));
        }
        private void AddResolvingUser(User anUser)
        {
            this.comment.resolvingUser = anUser;
        }
        private void AddCommentingUser(User anUser)
        {
            this.comment.commentingUser = anUser;
        }
        private void AddCommentingDate(DateTime aDate)
        {
            this.comment.CommentingDate = aDate;
        }
        private void AddResolvingDate(DateTime aDate)
        {
            this.comment.ResolvingDate = aDate;
        }
        private void WriteComment(string commentToAdd)
        {
            this.comment.WrittenComment = commentToAdd;
        }

    }
}
