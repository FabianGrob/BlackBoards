using BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest.HandlerTests
{
    [TestClass]
    public class RepositoryHandlerTest
    {
        public int Administrator { get; private set; }

        [TestMethod]
        public void TestRepositoryHandler() {
            List<Team> teams = new List<Team>();
            List<User> users = new List<User>();
            List<Admin> admins = new List<Admin>();
            Repository repository = new Repository(admins,users,teams);
            RepositoryHandler handler = new RepositoryHandler(repository);
            bool result = repository.Equals(handler.Repository);

        }
    }
}
