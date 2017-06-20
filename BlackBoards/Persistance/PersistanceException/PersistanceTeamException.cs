using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.PersistanceException
{
    public class PersistanceTeamException : Exception
    {
        public PersistanceTeamException(string message)
            : base(message)
        {
        }
    }
}
