using System;

using ComputationTypes;
using Computations;
using Worlds;
using WorldFunctions;

namespace binaryWorld
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            const int X = 100;
            const int Y = 100;
            const int Z = 100;

            // Coordinate p = new Coordinate(0, 30, 0);
            // Coordinate q = new Coordinate(30, 30, 0);
            // Coordinate r = new Coordinate(0, 0, 0);

            // PlaneEquation equation = Computation.FindPlaneEquation(p, q, r);

            // Coordinate a = new Coordinate(17,17,5);
            // Coordinate b = new Coordinate(15,15,-5);

            // Coordinate intersection = Computation.FindIntersectionPoint(a,b,equation);

            World world = new World(X,Y,Z);
            Camera camera = new Camera(new Coordinate(0,0,10),new Coordinate(30,30,10));

            WorldFunction worldFunctions = new WorldFunction(world);
            worldFunctions.AddCubeToWorld(new Coordinate(0,0,95),5);
            worldFunctions.PlaceObjectsInWorld();


            while(true){

                worldFunctions.SetProjections(camera);
                worldFunctions.RenderProjections(camera);
                Console.WriteLine("move forward : w");
                if(Console.ReadLine() == "w"){
                    Coordinate newTopLeft = new Coordinate(camera.topLeft.X,camera.topLeft.Y,camera.topLeft.Z+10);
                    Coordinate newbottomRight = new Coordinate(camera.bottomRight.X,camera.bottomRight.Y,camera.bottomRight.Z+10);
                    camera.setCameraEq(newTopLeft,newbottomRight);
                    Console.Clear();
                    camera.cameraScreen = new int[camera.height,camera.width];
                }

            }
        }
    }
}
