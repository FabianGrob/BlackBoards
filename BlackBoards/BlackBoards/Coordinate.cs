using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Coordinate
    {
        private int xAxis;
        private int yAxis;

        public Coordinate()
        {
            this.xAxis = 0;
            this.yAxis = 0;
        }

        public Coordinate(int xAxis, int yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }
        public int XAxis
        {
            get
            {
                return this.xAxis;
            }
            set
            {
                this.xAxis = value;
            }
        }

        public int YAxis
        {
            get
            {
                return this.yAxis;
            }
            set
            {
                this.yAxis = value;
            }
        }
        
        public override bool Equals(object aCoordinate)
        {
            if (aCoordinate == null)
            {
                return false;
            }
            Coordinate anotherCoordinate = aCoordinate as Coordinate;
            if ((System.Object)anotherCoordinate == null)
            {
                return false;
            }

            bool xAxisBool = this.XAxis == anotherCoordinate.XAxis;
            bool yAxisBool = this.YAxis == anotherCoordinate.YAxis;
            return (xAxisBool && yAxisBool);
        }
    }
}
