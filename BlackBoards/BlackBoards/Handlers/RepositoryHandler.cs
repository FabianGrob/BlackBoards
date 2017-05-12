using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
   public class RepositoryHandler
    {
        private Repository repository;

        public RepositoryHandler(Repository theRepository) {
            this.repository = theRepository;
        }
        public Repository Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

    }
}
