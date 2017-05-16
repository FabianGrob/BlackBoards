using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Picture:Item
    {
        private Image img;
        private string description;
        public Picture() {
            this.Dimension= new Dimension(50,50);
            this.Comments = new List<Comment>();
            this.Origin = new Coordinate();
            this.description = "default description";
        }
        public override bool IsPicture()
        {
            return true;
        }
        public Image Img
        {
            get
            {
                return this.img;
            }
            set
            {
                this.img = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public Picture(Dimension aDimension, List<Comment> someComments, Coordinate anOrigin)
        {
            this.Dimension = aDimension;
            this.Comments = someComments;
            this.Origin = anOrigin;         
        }

        private string getDefaultPicturePath()
        {
            string proyectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string defualtImagePath = proyectPath + "\\Images\\default.jpg";
            return defualtImagePath;
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
            bool sameDimensions = this.Dimension.Equals(anotherPicture.Dimension);
            bool sameOrigin = this.Origin == anotherPicture.Origin;
            bool sameComments = this.Comments.Equals(anotherPicture.Comments);
            return sameDimensions && sameComments && sameComments;
        }
        public override string ToString()
        {
            return this.description;
        }
    }
 }

