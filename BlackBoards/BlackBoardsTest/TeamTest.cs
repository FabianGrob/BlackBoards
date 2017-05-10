using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void teamTest(){
            String name = "testName";
            DateTime creationDate = new DateTime();
            String description = "testDescription";
            int maximumUsers = 10;

            Team aTeam = new Team(name,creationDate,description,maximumUsers);
            Team otherTeam = new Team();
            otherTeam.Name = name;
            otherTeam.CreationDate = creationDate;
            otherTeam.Description = description;
            otherTeam.MaxUsers = maximumUsers;
            Assert.Equals(aTeam,otherTeam);


            
            }
    }
}
