using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.PersistanceException
{
    public class PersistanceItemException : Exception
    {
        public PersistanceItemException(string message)
            : base(message)
        {
        }
    }
}
