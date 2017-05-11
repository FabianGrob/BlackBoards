using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Picture:Item
    {
        

        public Picture() {
            this.Width = 1;
            this.Heigth = 1;
            this.Comments = new List<Comment>();
            this.Origin = new int[2];
        }
        public Picture(int aWidth,int aHeigth, List<Comment> someComments, int[] anOrigin)
        {
            this.Width = aWidth;
            this.Heigth = aHeigth;
            this.Comments = someComments;
            this.Origin = anOrigin;
        }


       
        public override bool Equals(object aTextBox)
        {
            
            return true;
        }
    }
}
