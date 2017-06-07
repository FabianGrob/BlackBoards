using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackBoards
{
    public abstract class Item
    {
        private Dimension dimension;
        private List<Comment> comments;
        private Coordinate origin;

        public Dimension Dimension
        {
            get
            {
                return this.dimension;
            }
            set
            {
                this.dimension = value;
            }
        }
       
        public List<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
        public Coordinate Origin
        {
            get
            {
                return this.origin;
            }
            set
            {
                this.origin = value;
            }
        }
        public virtual bool IsPicture()
        {
            return false;
        }
        public virtual Control Print() { return null; }
        public bool AddNewComment(Comment aComment) {
            bool validComment = aComment.IsValid();
            if (validComment)
            {
                this.Comments.Add(aComment);
            }
            return validComment;
        }
        
    }

}
