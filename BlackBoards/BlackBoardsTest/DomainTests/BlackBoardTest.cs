using BlackBoards;
using BlackBoards.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
    public class BlackBoardTest
    {
        [TestMethod]
        public void TestBlackBoardBuilder() {
            //variables instance
            String name = "testBoard1";
            String description = "this is a board";
            Dimension aDimension = new Dimension(5, 5);
            Team team = new Team();
            team.Name = "testTeam";

            //objects instance
            BlackBoard aBoard = new BlackBoard(name,description, aDimension, team);
            BlackBoard anotherBoard = new BlackBoard();
            anotherBoard.Name = name;
            anotherBoard.Description = description;
            anotherBoard.Dimension = aDimension;
            anotherBoard.Team = team;

            //assert
            Assert.IsTrue(aBoard.Equals(anotherBoard));


        }
        [TestMethod]
        public void TestBlackBoardEquals() {
            //object instance
            BlackBoard aBoard = new BlackBoard();
            BlackBoard anotherBoard = new BlackBoard();
            Boolean result = aBoard.Equals(anotherBoard);

            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestBlackBoardNotEquals()
        {
            //object instance
            BlackBoard aBoard = new BlackBoard();
            BlackBoard anotherBoard = new BlackBoard();
            anotherBoard.Name = "Different board";
            Boolean result = aBoard.Equals(anotherBoard);

            //assert
            Assert.IsFalse(result);
        }

    }
}
