using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public abstract class Item
    {
        private int width;
        private int heigth;
        private List<Comment> comments;
        private int[] origin;

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        public int Heigth
        {
            get
            {
                return this.heigth;
            }
            set
            {
                this.heigth = value;
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
        public int[] Origin
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
    }

}
