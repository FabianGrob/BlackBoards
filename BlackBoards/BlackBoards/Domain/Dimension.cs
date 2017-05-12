using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class Dimension
    {
        private int width;
        private int heigth;
        public Dimension(int aWidth, int aHeigth)
        {
            this.width = aWidth;
            this.heigth = aHeigth;
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
        public int Height
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
        public override bool Equals(object someDimensions)
        {
            if (someDimensions == null)
            {
                return false;
            }
            Dimension otherDimensions = someDimensions as Dimension;
            if ((System.Object)otherDimensions == null)
            {
                return false;
            }

                      
            return (this.width == otherDimensions.Width) && (this.heigth == otherDimensions.Height);
        }
    }

}
