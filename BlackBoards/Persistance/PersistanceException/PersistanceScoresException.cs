using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.PersistanceException
{
    public class PersistanceScoresException : Exception
    {
        public PersistanceScoresException(string message)
            : base(message)
        {
        }
    }
}
