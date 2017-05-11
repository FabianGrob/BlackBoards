using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class TextBox
    {
            private int width;
            private int heigth;
            private List<Comment>comments;
            private int[] origin;
            private string content;
            private string font;
            private int fontSize;

        public TextBox() {
            this.width = 1;
            this.heigth = 1;
            this.comments = new List<Comment>();
            this.origin = new int[2];
            this.content = "aContent";
            this.font = "aFont";
            this.fontSize = 10;
    }
        public TextBox(int aWidth, int aHeigth, List<Comment> someComments, int[] anOrigin, String aContent, string aFont, int aFontSize) {

            this.width = aWidth;
            this.heigth = aHeigth;
            this.comments = someComments;
            this.origin = anOrigin;
            this.content = aContent;
            this.font = aFont;
            this.fontSize = aFontSize;

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

            return this.heigth== anotherTextBox.heigth && this.width== anotherTextBox.width && this.origin== anotherTextBox.origin && this.content.Equals(anotherTextBox.content) && this.comments.Equals(anotherTextBox.comments) && this.fontSize== anotherTextBox.fontSize && this.font.Equals(anotherTextBox.font);
        }
    }
    
}
