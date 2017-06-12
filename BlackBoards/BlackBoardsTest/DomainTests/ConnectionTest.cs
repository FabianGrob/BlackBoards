﻿using BlackBoards;
using BlackBoards.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoardsTest.DomainTests
{
    [TestClass]
    public class ConnectionTest
    {
        public Connection setUp()
        {
            //instance
            TextBox from = new TextBox();
            from.Content = "firstItem";
            TextBox to = new TextBox();
            to.Content = "secondItem";
            string name = "testingConnection";
            string description = "this is a test";
            DirectionType direction = DirectionType.nonDirected;
            Connection connection = new Connection(from, to, name, description, direction);
            return connection;
        }
        [TestMethod]
        public void TestBuilderConnection()
        {
            //instance
            Connection connection = this.setUp();
            TextBox from = new TextBox(connection.From as TextBox);
            TextBox to = new TextBox(connection.To as TextBox);
            DirectionType direction = DirectionType.nonDirected;
            //assertion
            bool sameName = connection.Name.Equals("testingConnection");
            bool sameDesccription = connection.Description.Equals("this is a test");
            bool sameItems = from.Equals(connection.From) && to.Equals(connection.To);
            bool sameDirection = direction == connection.Direction;
            bool result = sameName && sameDesccription && sameItems && sameDirection;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestBuilderConnectionNotEq()
        {
            //instance
            Connection connection = this.setUp();
            TextBox from = new TextBox(connection.From as TextBox);
            TextBox to = new TextBox(connection.From as TextBox);
            DirectionType direction = DirectionType.nonDirected;
            //assertion
            bool sameName = connection.Name.Equals("testingConnection");
            bool sameDesccription = connection.Description.Equals("this is a test");
            bool sameItems = from.Equals(connection.From) && to.Equals(connection.To);
            bool sameDirection = direction == connection.Direction;
            bool result = sameName && sameDesccription && sameItems && sameDirection;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidOk()
        {
            Connection connection = this.setUp();
            bool result = connection.isValid().Validation;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsValidShortName()
        {
            Connection connection = this.setUp();
            connection.Name = "A1";
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidEmptyName()
        {
            Connection connection = this.setUp();
            connection.Name = "";
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidSameItem()
        {
            Connection connection = this.setUp();
            connection.To = new TextBox(connection.From as TextBox);
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidNullItemTo()
        {
            Connection connection = this.setUp();
            connection.To = null;
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidNullItemFrom()
        {
            Connection connection = this.setUp();
            connection.From = null;
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }

    }
}
