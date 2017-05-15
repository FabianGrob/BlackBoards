using BlackBoards.Domain;
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
            this.Dimension = new Dimension(1,1);
            this.Comments = new List<Comment>();
            this.Origin = new Coordinate();
            this.content = "aContent";
            this.font = "Arial";
            this.fontSize = 10;
    }
        public TextBox(TextBox aTextBox)
        {
            this.Dimension=aTextBox.Dimension;
            this.Comments = aTextBox.Comments;
            this.Origin = aTextBox.Origin;
            this.content = aTextBox.content;
            this.font = aTextBox.font;
            this.fontSize = aTextBox.fontSize;
        }
        public TextBox(Dimension aDimension, List<Comment> someComments, Coordinate anOrigin, String aContent, string aFont, int aFontSize) {

            this.Dimension = aDimension;
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
        
        public override bool IsPicture()
        {
            return false;
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
            bool sameDimensions=this.Dimension.Equals(anotherTextBox.Dimension);
            bool sameOrigin=this.Origin.Equals(anotherTextBox.Origin);
            bool sameComments= this.Comments.Equals(anotherTextBox.Comments);
            bool sameFontAndSize=this.fontSize== anotherTextBox.fontSize && this.font.Equals(anotherTextBox.font);
            bool sameContent=this.content.Equals(anotherTextBox.content);
            return sameDimensions && sameOrigin && sameComments && sameFontAndSize && sameContent;
        }
    }
    
}
