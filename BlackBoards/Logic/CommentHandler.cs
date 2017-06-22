using BlackBoards.Domain.BlackBoards;
using Persistance;
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
        public ValidationReturn ResolveComment(User anUser)
        {
            ValidationReturn canResolveComment = new ValidationReturn(false, "El comentario ya esta resuelto.");
            canResolveComment.Validation = !(this.WasResolved());
            if (canResolveComment.Validation)
            {
                CommentPersistance commentContext = new CommentPersistance();
                if (commentContext.Exists(this.comment))
                {
                    this.comment.resolvingUser = anUser;
                    this.comment.ResolvingDate = DateTime.Now;
                    commentContext.ResolveComment(this.comment);
                }
            }
            return canResolveComment;
        }
        public bool WasResolved()
        {
            return !(this.Comment.ResolvingDate.CompareTo(this.Comment.CommentingDate) < 0);
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
