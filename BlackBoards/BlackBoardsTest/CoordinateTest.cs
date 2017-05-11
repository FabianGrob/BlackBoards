using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BlackBoardsTest
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void testBuilderCoordinate()
        {
            int xAxis = 3;
            int yAxis = 3;
          
            Coordinate aCoordinate = new Coordinate(xAxis, yAxis);
            Coordinate otherCoordinate = new Coordinate();
            otherCoordinate.XAxis = xAxis;
            otherCoordinate.YAxis = yAxis;
            
            Assert.IsTrue(aCoordinate.Equals(otherCoordinate));
        }
    }
    [TestMethod]
    public void testEqualsCoordinate()
    {
        int xAxisVaule1 = 3;
        int yAxisValue1 = 3;
        int xAxisVaule2 = 5;
        int yAxisValue2 = 3;

        Coordinate aCoordinate = new Coordinate(xAxisValue1, yAxisValue1);
        Coordinate otherCoordinate = new Coordinate(xAxisValue2, yAxisValue2);

        Assert.IsFalse(aCoordinate.Equals(otherCoordinate));
    }
}
}
