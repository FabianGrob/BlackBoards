using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDComment { get; set; }
        public virtual User commentingUser { get; set; }
        public virtual User resolvingUser { get; set; }
        private DateTime commentingDate;
        private DateTime resolvingDate;
        private string writtenComment;
        public virtual Item itemBelong { get; set; }
        public Comment()
        {
            this.commentingUser = new Admin();
            this.resolvingUser = new Admin();
            this.CommentingDate = DateTime.Now;
            this.ResolvingDate = DateTime.MaxValue;
            this.WrittenComment = "Default written comment";
        }
        public Comment(User commentingUser, User resolvingUser, DateTime commentingDate, DateTime resolvingDate, string writtenComment)
        {
            this.commentingUser = commentingUser;
            this.resolvingUser = resolvingUser;
            this.CommentingDate = commentingDate;
            this.ResolvingDate = resolvingDate;
            this.WrittenComment = writtenComment;
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
        public bool IsValid()
        {
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
           
            return this.IDComment.Equals(anotherComment.IDComment);
        }
        public override string ToString()
        {
            bool resolved = !this.resolvingUser.Email.Equals("Default email");
            string res = " no resuelto";
            if (resolved)
            {
                res = "resuelto";
            }
            return this.writtenComment + "| Por: " + this.commentingUser + " " + res;
        }
    }
}
