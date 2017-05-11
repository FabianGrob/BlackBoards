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


       
        public override bool Equals(object aPicture)
        {


            if (aPicture == null)
            {
                return false;
            }
            Picture anotherPicture = aPicture as Picture;
            if ((System.Object)anotherPicture == null)
            {
                return false;
            }
            bool sameHeigthAndWidth = this.Heigth == anotherPicture.Heigth && this.Width == anotherPicture.Width;
            bool sameOrigin = this.Origin == anotherPicture.Origin;
            bool sameComments = this.Comments.Equals(anotherPicture.Comments);
            return sameHeigthAndWidth && sameComments && sameComments;
        }
    }
 }

