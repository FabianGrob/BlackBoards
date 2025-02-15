﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using BlackBoards;

namespace BlackBoardsTest
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void TestTeamBuilder()
        {
            String name = "testName";
            DateTime creationDate = new DateTime();
            String description = "testDescription";
            int maximumUsers = 10;
            List<User> members = new List<User>();
            List<BlackBoard> boards = new List<BlackBoard>();
            Team aTeam = new Team(name, creationDate, description, maximumUsers, members, boards);
            Team otherTeam = new Team();
            otherTeam.Name = name;
            otherTeam.CreationDate = creationDate;
            otherTeam.Description = description;
            otherTeam.MaxUsers = maximumUsers;
            otherTeam.members = members;
            otherTeam.boards = boards;
            Assert.IsTrue(aTeam.Equals(otherTeam));
        }
        [TestMethod]
        public void TestNotEqualsTeam()
        {
            Team testTeamOne = new Team();
            Team testTeamTwo = new Team();
            testTeamOne.Name = "Team One";
            testTeamTwo.Name = "Team Two";
            Boolean result = testTeamOne.Equals(testTeamTwo);
            Assert.IsFalse(result);
        }
    }
}
