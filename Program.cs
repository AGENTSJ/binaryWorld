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

            const string MOVE_FORWARD = "w";
            const string MOVE_LEFT = "a";
            const string MOVE_RIGHT = "d";
            const string MOVE_BACK = "s";
            const string MOVE_UP = "q";
            const string MOVE_DOWN = "z";
            const string ROTATE_RIGHT = "rr";
            const string ROTATE_LEFT = "rl";

            const int STEP = 10;
            const int STEP_ANGLE = 10;

            World world = new World(X, Y, Z);
            Camera camera = new Camera(new Coordinate(0, 0, 10), new Coordinate(30, 30, 10));

            WorldFunction worldFunctions = new WorldFunction(world);
            worldFunctions.AddCubeToWorld(new Coordinate(12, 12, 94), 6);
            worldFunctions.PlaceObjectsInWorld();


            while (true)
            {
                Console.Clear();
                worldFunctions.SetProjections(camera);
                worldFunctions.RenderProjections(camera);

                Console.WriteLine("move forward : " + MOVE_FORWARD);
                Console.WriteLine("move back : " + MOVE_BACK);
                Console.WriteLine("move left : " + MOVE_LEFT);
                Console.WriteLine("move right : " + MOVE_RIGHT);
                Console.WriteLine("move up : " + MOVE_UP);
                Console.WriteLine("move down : " + MOVE_DOWN);
                string userActions = string.Empty;
                userActions = Console.ReadLine();

                Coordinate newTopLeft = new Coordinate(camera.topLeft.X, camera.topLeft.Y, camera.topLeft.Z);
                Coordinate newbottomRight = new Coordinate(camera.bottomRight.X, camera.bottomRight.Y, camera.bottomRight.Z);

                switch (userActions)
                {
                    case MOVE_FORWARD:
                        {
                            newTopLeft.Z += STEP;
                            newbottomRight.Z += STEP;

                            camera.setCameraEq(newTopLeft, newbottomRight);
                            camera.cameraScreen = new int[camera.height, camera.width];
                            break;
                        }
                    case MOVE_BACK:
                        {
                            newTopLeft.Z -= STEP;
                            newbottomRight.Z -= STEP;
                            camera.setCameraEq(newTopLeft, newbottomRight);
                            camera.cameraScreen = new int[camera.height, camera.width];
                            break;
                        }
                    case MOVE_RIGHT:
                        {
                            newTopLeft.X += STEP;
                            newbottomRight.X += STEP;
                            camera.setCameraEq(newTopLeft, newbottomRight);
                            camera.cameraScreen = new int[camera.height, camera.width];
                            break;
                        }
                    case MOVE_LEFT:
                        {
                            newTopLeft.X -= STEP;
                            newbottomRight.X -= STEP;
                            camera.setCameraEq(newTopLeft, newbottomRight);
                            camera.cameraScreen = new int[camera.height, camera.width];
                            break;
                        }
                    case MOVE_UP:
                        {
                            newTopLeft.Y += STEP;
                            newbottomRight.Y += STEP;
                            camera.setCameraEq(newTopLeft, newbottomRight);
                            camera.cameraScreen = new int[camera.height, camera.width];
                            break;
                        }
                    case MOVE_DOWN:
                        {
                            newTopLeft.Y -= STEP;
                            newbottomRight.Y -= STEP;
                            camera.setCameraEq(newTopLeft, newbottomRight);
                            camera.cameraScreen = new int[camera.height, camera.width];
                            break;
                        }
                    case ROTATE_LEFT:
                        {

                        }


                }
            }
        }
    }
}
