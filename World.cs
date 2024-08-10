using ComputationTypes;
using worldObject;
using camera;
using Computations;

/*
Namespace used for creating a world and related operation

    Operations :
        
        1 Adding objects into the world                                -> AddbjectToWorld
        2 palacing objects inside the 3d array                         -> PlaceObjectsInWorld
        3 Sets projections of 3d objects to a 2d plane (camera plane ) -> SetProjections
        4 Displays the projection on camera plane to user              -> RenderProjections
*/
namespace world {

    public class World
    {
        public int maxX;
        public int maxY;
        public int maxZ;
        const char WHITE_PIXEL = '.';
        const char BLACK_PIXEL = ' ';
        const char TOP_WINDOW_BOUNDARY = '+';
        const char SIDE_WINDOW_BOUNDARY = '|';
        const int PADDING = 2;
        public Camera? camera;
        public List<WorldObject> worldObjects;

        public int[,,] worldSpace;

        public World(int x, int y, int z)
        {
            this.maxX = x;
            this.maxY = y;
            this.maxZ = z;

            worldSpace = new int[z, y, x];
            worldObjects = new List<WorldObject>();
        }
        public void AddbjectToWorld(WorldObject worldObject)
        {
            this.worldObjects.Add(worldObject);
        }

        /*
            places all occupied coordinated of a object inside world array
        */
        public void PlaceObjectsInWorld()
        {

            List<WorldObject> worldObjects = this.worldObjects;

            foreach (WorldObject worldObject in worldObjects)
            {

                List<Coordinate> occupiedCoordinates = worldObject.occupiedCoordinates;

                foreach (Coordinate coordinate in occupiedCoordinates)
                {
                    int z = (int)Math.Ceiling(coordinate.Z);
                    int y = (int)Math.Ceiling(coordinate.Y);
                    int x = (int)Math.Ceiling(coordinate.X);

                    this.worldSpace[z, y, x] = 1;
                }
            }
        }

        /*
            adds a basic cube to list of worldobject (worldobjects)
        */
        public void AddCubeToWorld(Coordinate spawnPoint, int sideLength)
        {
            int z = (int)spawnPoint.Z;
            int y = (int)spawnPoint.Y;
            int x = (int)spawnPoint.X;

            WorldObject cube = new WorldObject();


            for (int i = 0; i < sideLength; i++)
            {

                for (int j = 0; j < sideLength; j++)
                {

                    for (int k = 0; k < sideLength; k++)
                    {
                        cube.occupiedCoordinates.Add(new Coordinate(x + k, y + j, z + i));
                    }
                }
            }
            this.worldObjects.Add(cube);
        }

        /*
            takes all the occupied coordinates from all the objects present inside worldobjects list and set their 2d projection to camera plane
        */
        public void SetProjections(Camera camera)
        {

            int[,] screen = camera.cameraScreen;
            List<WorldObject> worldObjects = this.worldObjects;
            Coordinate focalPoint = camera.focalPoint;
            PlaneEquation cameraPlaneEq = camera.cameraPlaneEq;

            
            foreach (WorldObject worldObject in worldObjects)//looping through each object in the world
            {

                List<Coordinate> occupiedCoordinates = worldObject.occupiedCoordinates;

                foreach (Coordinate occupiedCoordinate in occupiedCoordinates)//looping through each cordinate in an object
                {

                    Coordinate projectionPoint = Computation.FindIntersectionPoint(occupiedCoordinate, focalPoint, cameraPlaneEq);
                    int xProjection = (int)projectionPoint.X- (int)camera.topLeft.X;
                    int yProjection = (int)projectionPoint.Y - (int)camera.topLeft.Y;

                    try
                    {
                        screen[yProjection, xProjection] = 1;
                    }
                    catch (Exception)
                    {
                        //actiavted when the intersection point falls outside the camera plane
                    }
                }
            }
        }

        /*
            Displays Camera Screen  to console 
        */
        public void RenderProjections(Camera camera)
        {
            
            int[,] screen = camera.cameraScreen;
            int screenHeight = camera.height;
            int screenWidth = camera.width;

            Console.WriteLine(new string(TOP_WINDOW_BOUNDARY, screenWidth + PADDING));

            for (int i = 0; i < screenHeight; i++)
            {
                for (int j = 0; j < screenWidth; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(SIDE_WINDOW_BOUNDARY);
                    }

                    if (screen[i, j] == 1)
                    {
                        Console.Write(WHITE_PIXEL);
                    }
                    else
                    {
                        Console.Write(BLACK_PIXEL);
                    }

                    if (j == screenWidth - 1)
                    {
                        Console.Write(SIDE_WINDOW_BOUNDARY);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string(TOP_WINDOW_BOUNDARY, camera.width + PADDING));
        }
    }
}