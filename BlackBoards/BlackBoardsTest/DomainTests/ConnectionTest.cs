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
            Connection connection = this.setUp();
            TextBox from = new TextBox(connection.From as TextBox);
            TextBox to = new TextBox(connection.To as TextBox);
            DirectionType direction = DirectionType.nonDirected;

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
            Connection connection = this.setUp();
            TextBox from = new TextBox(connection.From as TextBox);
            TextBox to = new TextBox(connection.From as TextBox);
            DirectionType direction = DirectionType.nonDirected;

            bool sameName = connection.Name.Equals("testingConnection");
            bool sameDesccription = connection.Description.Equals("this is a test");
            bool sameItems = from.Equals(connection.From) && to.Equals(connection.To);
            bool sameDirection = direction == connection.Direction;
            bool result = sameName && sameDesccription && sameItems && sameDirection;
            Assert.IsFalse(result);
        }

    }
}
