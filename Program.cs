using System;

using ComputationTypes;
using Computations;
using Worlds;

namespace binaryWorld
{
    internal class Program
    {
        public const char pixel = '█';
        static void Main(string[] args)
        {
            const int X = 100;
            const int Y = 100;
            const int Z = 100;

            //Coordinates camTopLeft = new Coordinates(0,30,0);
            //Coordinates camBottomRight  = new Coordinates(30,0,0);
            //World gameWorld = new World(X,Y,Z);
            //gameWorld.camera = new Camera(camTopLeft,camBottomRight);
            //plane coordinates
            Coordinate p = new Coordinate(0, 30, 0);
            Coordinate q = new Coordinate(30, 30, 0);
            Coordinate r = new Coordinate(0, 0, 0);

            PlaneEquation equation = Computation.FindPlaneEquation(p, q, r);

            Coordinate a = new Coordinate(17,17,5);
            Coordinate b = new Coordinate(15,15,-5);

            Coordinate intersection = Computation.FindIntersectionPoint(a,b,equation);


        }
    }
}
