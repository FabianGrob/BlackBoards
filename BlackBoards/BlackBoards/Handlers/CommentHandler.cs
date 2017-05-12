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
            this.comment.CommentingUser = anUser;
            this.comment.WrittenComment = newComment;
            this.comment.CommentingDate = DateTime.Today;
        }
        public void ResolveComment(User anUser)
        {
            comment.ResolvingUser = anUser;
            comment.ResolvingDate = DateTime.Today;
        }        
    }
}
