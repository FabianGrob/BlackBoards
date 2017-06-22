using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class TextBox : Item
    {
        private string content;
        private string font;
        private int fontSize;
        public TextBox()
        {
            this.Dimension = new Dimension(50, 50);
            this.comments = new List<Comment>();
            this.Origin = new Coordinate(0, 0);
            this.content = "aContent";
            this.font = "Arial";
            this.fontSize = 10;
        }
        public TextBox(TextBox aTextBox)
        {
            this.Dimension = aTextBox.Dimension;
            this.comments = aTextBox.comments;
            this.Origin = aTextBox.Origin;
            this.content = aTextBox.content;
            this.font = aTextBox.font;
            this.fontSize = aTextBox.fontSize;
        }
        public TextBox(Dimension aDimension, List<Comment> someComments, Coordinate anOrigin, String aContent, string aFont, int aFontSize)
        {
            this.Dimension = aDimension;
            this.comments = someComments;
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
            bool sameDimensions = this.Dimension.Equals(anotherTextBox.Dimension);
            bool sameOrigin = this.Origin.Equals(anotherTextBox.Origin);
            bool sameComments = this.comments.Equals(anotherTextBox.comments);
            bool sameFontAndSize = this.fontSize == anotherTextBox.fontSize && this.font.Equals(anotherTextBox.font);
            bool sameContent = this.content.Equals(anotherTextBox.content);
            return sameDimensions && sameOrigin && sameComments && sameFontAndSize && sameContent;
        }
        
        public ValidationReturn isValid()
        {
            ValidationReturn validation = new ValidationReturn(false, "Error");
            bool validContent = this.IsContentValid();
            bool validFont = this.IsFontValid();
            bool validFontSize = this.IsFontSizeValid();
            if (!validContent)
            {
                validation.Message = "El texto ingresado es vacio.";
                return validation;
            }
            if (!validFont)
            {
                validation.Message = "La fuente ingresada es invalida.";
                return validation;
            }
            if (!validFontSize)
            {
                validation.Message = "El tamaño de fuente no puede ser menor a 1.";
                return validation;
            }
            validation.Validation = true;
            validation.Message = "OK";
            return validation;
        }
        private bool IsContentValid()
        {
            bool valid = true;
            if (this.Content.Length == 0)
            {
                valid = false;
            }
            return valid;
        }
        private bool IsFontValid()
        {
            bool valid = true;
            if (this.Font.Length == 0)
            {
                valid = false;
            }
            return valid;
        }
        public bool IsFontSizeValid()
        {
            bool valid = true;
            if (this.FontSize < 1)
            {
                valid = false;
            }
            return valid;
        }
        public override string ToString()
        {
            return this.content;
        }
    }
}
