using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class TextBox:Item
    {
            private string content;
            private string font;
            private int fontSize;

        public TextBox() {
            this.Width = 1;
            this.Heigth = 1;
            this.Comments = new List<Comment>();
            this.Origin = new Coordinate();
            this.content = "aContent";
            this.font = "aFont";
            this.fontSize = 10;
    }
        public TextBox(int aWidth, int aHeigth, List<Comment> someComments, Coordinate anOrigin, String aContent, string aFont, int aFontSize) {

            this.Width = aWidth;
            this.Heigth = aHeigth;
            this.Comments = someComments;
            this.Origin = anOrigin;
            this.content = aContent;
            this.font = aFont;
            this.fontSize = aFontSize;

        }
      
        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }
        public string Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }
        public int FontSize
        {
            get
            {
                return this.fontSize;
            }
            set
            {
                this.fontSize = value;
            }
        }
        public override bool Equals(object aTextBox)
        {
            if (aTextBox == null)
            {
                return false;
            }
            TextBox anotherTextBox = aTextBox as TextBox;
            if ((System.Object)anotherTextBox == null)
            {
                return false;
            }
            bool sameHeigthAndWidth=this.Heigth== anotherTextBox.Heigth && this.Width== anotherTextBox.Width;
            bool sameOrigin=this.Origin== anotherTextBox.Origin;
            bool sameComments= this.Comments.Equals(anotherTextBox.Comments);
            bool sameFontAndSize=this.fontSize== anotherTextBox.fontSize && this.font.Equals(anotherTextBox.font);
            bool sameContent=this.content.Equals(anotherTextBox.content);
            return sameHeigthAndWidth && sameOrigin && sameComments && sameFontAndSize && sameContent;
        }
    }
    
}
