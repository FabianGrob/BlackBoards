using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    namespace BlackBoards
    {
        public class ValidationReturn
        {
            private string message;
            private bool validation;
            public ValidationReturn()
            {
                this.message = "Default Message";
                this.validation = false;
            }
            public ValidationReturn(bool isValid, string aMessage)
            {
                this.validation = isValid;
                this.message = aMessage;
            }
            public bool Validation
            {
                get
                {
                    return this.validation;
                }
                set
                {
                    this.validation = value;
                }
            }
            public string Message
            {
                get
                {
                    return this.message;
                }
                set
                {
                    this.message = value;
                }
            }
            public void RedefineValues(bool isValid, string message) {
                this.Validation = isValid;
                this.Message=message;
            }
        }
    }
}
