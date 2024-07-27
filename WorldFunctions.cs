using ComputationTypes;
using Worlds; 
using Computations;

/*
    Namespace used for storing functions that helps for the following Operations:

        Operations :
            
            1 Adding objects into the world                                -> AddbjectToWorld
            2 palacing objects inside the 3d array                         -> PlaceObjectsInWorld
            3 Sets projections of 3d objects to a 2d plane (camera plane ) -> SetProjections
            4 Displays the projection on camera plane to user              -> RenderProjections
*/
namespace WorldFunctions {

    class WorldFunction {

        const char WHITE_PIXEL = '█';
        const char BLACK_PIXEL = ' ';
        const char TOP_WINDOW_BOUNDARY = '+' ;
        const char SIDE_WINDOW_BOUNDARY = '|' ;
        const int PADDING = 2;

        private World world;
        public WorldFunction(World world){
            this.world = world;
        }
        public void AddbjectToWorld(WorldObject worldObject){
            world.worldObjects.Add(worldObject);
        }
        
        public void PlaceObjectsInWorld(){

            List<WorldObject> worldObjects = this.world.worldObjects;

            foreach(WorldObject worldObject in worldObjects){

                List<Coordinate> occupiedCoordinates = worldObject.occupiedCoordinates;

                foreach(Coordinate coordinate in occupiedCoordinates){
                    int z = (int) Math.Ceiling(coordinate.Z);
                    int y = (int) Math.Ceiling(coordinate.Y);
                    int x = (int) Math.Ceiling(coordinate.X);

                    this.world.worldSpace[z,y,x] = 1;
                }
            }

        }
        
        public void AddCubeToWorld(Coordinate spawnPoint , int sideLength){
            int z = (int) spawnPoint.Z;
            int y = (int) spawnPoint.Y;
            int x = (int) spawnPoint.X;

            this.world.worldSpace[z,y,x] = 1;
            
            WorldObject cube = new WorldObject();


            for(int i = 0;i< sideLength;i++){

                for(int j = 0 ;j<sideLength ; j++){

                    for(int k = 0 ;k<sideLength;k++){

                        // this.world.worldSpace[z+i,y+j,x+k] = 1;
                        cube.occupiedCoordinates.Add(new Coordinate(x+k,y+j,z+i));
                    }
                }
            }
            this.world.worldObjects.Add(cube);
        }
        
        public void SetProjections(Camera camera){

            int[,] screen = camera.cameraScreen;
            List<WorldObject> worldObjects = this.world.worldObjects;
            Coordinate focalPoint = camera.focalPoint;
            PlaneEquation cameraPlaneEq = camera.cameraPlaneEq;

            //marking the projections of objects in the world to screen 1 
            foreach(WorldObject worldObject in worldObjects){

                List<Coordinate> occupiedCoordinates = worldObject.occupiedCoordinates;

                foreach(Coordinate occupiedCoordinate in occupiedCoordinates){

                    Coordinate projectionPoint = Computation.FindIntersectionPoint(occupiedCoordinate,focalPoint,cameraPlaneEq);
                    int xProjection = (int)projectionPoint.X;
                    int yProjection = (int)projectionPoint.Y;

                    try{
                        screen[yProjection,xProjection] = 1;
                    }catch(Exception){
                        //actiavted when the intersection point avoid 
                    }
                    
                }
            }
           
        }
    
        public void RenderProjections(Camera camera){

            int[,] screen = camera.cameraScreen;
            int screenHeight = camera.height;
            int screenWidth = camera.width;

            Console.WriteLine(new string(TOP_WINDOW_BOUNDARY,screenWidth+PADDING));

            for (int i = 0; i < screenHeight; i++)
            {
                for(int j = 0 ; j<screenWidth ; j++)
                {   
                    if(j==0){
                        Console.Write(SIDE_WINDOW_BOUNDARY);
                    }

                    if(screen[i,j]==1){
                        Console.Write(WHITE_PIXEL);
                    }else{
                        Console.Write(BLACK_PIXEL);
                    }

                    if(j==screenWidth-1){
                        Console.Write(SIDE_WINDOW_BOUNDARY);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string(TOP_WINDOW_BOUNDARY,camera.width+PADDING));
        }
    }
}
