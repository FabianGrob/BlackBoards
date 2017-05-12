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
        }
        public void ResolveComment(User anUser)
        {
            this.AddResolvingUser(anUser);
            this.AddResolvingDate(DateTime.Today);
        }
        private void AddResolvingUser(User anUser)
        {
            this.comment.ResolvingUser = anUser;
        }
        private void AddCommentingUser(User anUser)
        {
            this.comment.CommentingUser = anUser;
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
