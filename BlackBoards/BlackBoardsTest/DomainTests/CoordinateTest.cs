using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackBoards;


namespace BlackBoardsTest
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void TestBuilderCoordinate()
        {
            //variables instance
            int xAxis = 3;
            int yAxis = 3;

            //objects instance
            Coordinate aCoordinate = new Coordinate(xAxis, yAxis);
            Coordinate otherCoordinate = new Coordinate();
            otherCoordinate.XAxis = xAxis;
            otherCoordinate.YAxis = yAxis;
            
            //assert
            Assert.IsTrue(aCoordinate.Equals(otherCoordinate));
        }

        [TestMethod]
        public void TestEqualsCoordinate()
        {
            //variables instance
            int xAxisValue1 = 3;
            int yAxisValue1 = 3;
            int xAxisValue2 = 5;
            int yAxisValue2 = 3;

            //objects instance
            Coordinate aCoordinate = new Coordinate(xAxisValue1, yAxisValue1);
            Coordinate otherCoordinate = new Coordinate(xAxisValue2, yAxisValue2);

            //asserts
            Assert.IsFalse(aCoordinate.Equals(otherCoordinate));
        }
    }
}
