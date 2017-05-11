using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Picture
    {
        private int width;
        private int heigth;
        private List<Comment> comments;
        private int[] origin;

        public Picture() {
            this.width = 1;
            this.heigth = 1;
            this.comments = new List<Comment>();
            this.origin = new int[2];
        }
        public Picture(int aWidth,int aHeigth, List<Comment> someComments, int[] anOrigin)
        {
            this.width = aWidth;
            this.heigth = aHeigth;
            this.comments = someComments;
            this.origin = anOrigin;
        }


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
        public override bool Equals(object aTextBox)
        {
            
            return true;
        }
    }
}
