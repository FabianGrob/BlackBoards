using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class TextBoxHandler
    {
        private TextBox textBox;

        public TextBoxHandler(TextBox aTextBox) {
            this.textBox = aTextBox;
        }
        public TextBox TextBox
        {
            get
            {
                return this.textBox;
            }
            set
            {
                this.textBox = value;
            }
        }
    }
}
