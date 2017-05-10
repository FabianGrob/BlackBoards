using BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
    class BlackBoardTest
    {
        [TestMethod]
        public void TestBlackBoardBuilder() {
            String name = "testBoard1";
            String description = "this is a board";
            int heigth = 5;
            int width = 5;
            Team team = new Team();
            team.Name = "testTeam";
            BlackBoard aBoard = new BlackBoard(name,description,heigth,width,team);
            BlackBoard anotherBoard = new BlackBoard();
            anotherBoard.Name = name;
            anotherBoard.Description = description;
            anotherBoard.Heigth = heigth;
            anotherBoard.Width = width;
            anotherBoard.Team = team;
            Assert.IsTrue(aBoard.Equals(anotherBoard));


        }
    }
}
