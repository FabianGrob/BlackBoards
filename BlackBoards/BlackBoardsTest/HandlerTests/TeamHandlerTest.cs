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
    public class TeamHandlerTest
    {
        [TestMethod]
        public void TestTeamHandlerBuilder()
        {
            Team aTeam = new Team();
            TeamHandler handler = new TeamHandler(aTeam);
            bool result = aTeam.Equals(handler.Team);
            Assert.IsTrue(result);

        }
    }
}
