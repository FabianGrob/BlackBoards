using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public abstract class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDItem { get; set; }
        private Dimension dimension;
        public virtual BlackBoard blackBoardBelongs { get; set; }
        public virtual List<Comment> comments { get; set; }
        private Coordinate origin;
        public virtual Connection connect { get; set; }

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
        public bool AddNewComment(Comment aComment)
        {
            bool validComment = aComment.IsValid();
            if (validComment)
            {
                this.comments.Add(aComment);
            }
            return validComment;
        }
    }
}
