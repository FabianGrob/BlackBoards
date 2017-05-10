﻿using BlackBoards;
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
            int heigth = 5;
            int width = 5;
            Team team = new Team();
            team.Name = "testTeam";
            //objects instance
            BlackBoard aBoard = new BlackBoard(name,description,heigth,width,team);
            BlackBoard anotherBoard = new BlackBoard();
            anotherBoard.Name = name;
            anotherBoard.Description = description;
            anotherBoard.Heigth = heigth;
            anotherBoard.Width = width;
            anotherBoard.Team = team;

            //assert
            Assert.IsTrue(aBoard.Equals(anotherBoard));


        }

    }
}
