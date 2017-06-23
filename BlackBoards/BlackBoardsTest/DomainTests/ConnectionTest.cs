using BlackBoards;
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
            TextBox from = new TextBox(connection.from as TextBox);
            TextBox to = new TextBox(connection.to as TextBox);
            DirectionType direction = DirectionType.nonDirected;
            //assertion
            bool sameName = connection.Name.Equals("testingConnection");
            bool sameDesccription = connection.Description.Equals("this is a test");
            bool sameItems = from.Equals(connection.from) && to.Equals(connection.to);
            bool sameDirection = direction == connection.Direction;
            bool result = sameName && sameDesccription && sameItems && sameDirection;
            Assert.IsTrue(result);
        }     
        [TestMethod]
        public void TestIsValidShortName()
        {
            //instance
            Connection connection = this.setUp();
            connection.Name = "A1";
            //assertion
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidEmptyName()
        {
            //instance
            Connection connection = this.setUp();
            connection.Name = "";
            //assertion
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidSameItem()
        {
            //instance
            Connection connection = this.setUp();
            connection.to = new TextBox(connection.from as TextBox);
            //assertion
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidNullItemTo()
        {
            //instance
            Connection connection = this.setUp();
            connection.to = null;
            //assertion
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIsValidNullItemFrom()
        {
            //instance
            Connection connection = this.setUp();
            connection.from = null;
            //assertion
            bool result = connection.isValid().Validation;
            Assert.IsFalse(result);
        }
    }
}
