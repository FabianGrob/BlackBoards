using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.PersistanceException
{
    public class PersistanceCommentException : Exception
    {
        public PersistanceCommentException(string message)
            : base(message)
        {
        }
    }
}
