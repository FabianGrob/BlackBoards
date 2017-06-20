using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.PersistanceException
{
    public class PersistanceAdminException : Exception
    {
        public PersistanceAdminException(string message)
            : base(message)
        {
        }
    }
}
