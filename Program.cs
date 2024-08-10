using System;
using ComputationTypes;
using world;
using camera;
using worldObject;

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
            // const string ROTATE_RIGHT = "rr";
            // const string ROTATE_LEFT = "rl";

            const int STEP = 10;
            // const int STEP_ANGLE = 10;

            World world = new World(X, Y, Z);
            Camera camera = new Camera(new Coordinate(0, 0, 10), new Coordinate(30, 30, 10));

            world.AddCubeToWorld(new Coordinate(12, 12, 94), 5);
            world.PlaceObjectsInWorld();


            while (true)
            {
                Console.Clear();
                world.SetProjections(camera);
                world.RenderProjections(camera);

                Console.WriteLine("\nMove forward   : " + MOVE_FORWARD);
                Console.WriteLine("Move back      : " + MOVE_BACK);
                Console.WriteLine("Move left      : " + MOVE_LEFT);
                Console.WriteLine("Move right     : " + MOVE_RIGHT);
                Console.WriteLine("Move up        : " + MOVE_UP);
                Console.WriteLine("Move down      : " + MOVE_DOWN);
                Console.WriteLine();
                Console.Write("> ");
                string? userActions = string.Empty;
                userActions = Console.ReadLine();
                
                Coordinate newTopLeft = new Coordinate(camera.topLeft.X, camera.topLeft.Y, camera.topLeft.Z);
                Coordinate newbottomRight = new Coordinate(camera.bottomRight.X, camera.bottomRight.Y, camera.bottomRight.Z);

                switch (userActions)
                {
                    case MOVE_FORWARD:
                        {
                            camera.MoveForward(STEP);
                            break;
                        }
                    case MOVE_BACK:
                        {
                            camera.MoveBackward(STEP);
                            break;
                        }
                    case MOVE_RIGHT:
                        {
                            camera.MoveRight(STEP);
                            break;
                        }
                    case MOVE_LEFT:
                        {
                            camera.MoveLeft(STEP);
                            break;
                        }
                    case MOVE_UP:
                        {
                            camera.MoveUp(STEP);
                            break;
                        }
                    case MOVE_DOWN:
                        {
                            camera.MoveDown(STEP);
                            break;
                        }
                }
            }
        }
    }
}
