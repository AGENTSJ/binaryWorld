using System;
using Computations;

namespace ComputationTypes
{
    public class Coordinate
    {
        public double X;
        public double Y;
        public double Z;
        public Coordinate(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
    public class Vector
    {
        public double i;
        public double j;
        public double k;
    }
    public class PlaneEquation
    {
        public double coifX;
        public double coifY;
        public double coifZ;

        public double constant;
    }


}
