using ComputationTypes;
using Worlds; 
using Computations;

namespace WorldFunctions {

    class WorldFunction {

        public const char pixel = '█';
        public World world;
        public WorldFunction(World world){
            this.world = world;
        }
        public void AddbjectToWorld(WorldObject worldObject){
            world.worldObjects.Add(worldObject);
        }
        
        public void PlaceObjectsInWorld(){

            List<WorldObject> worldObjects = this.world.worldObjects;
            int debugCount = 0;
            foreach(WorldObject worldObject in worldObjects){

                List<Coordinate> occupiedCoordinates = worldObject.occupiedCoordinates;

                foreach(Coordinate coordinate in occupiedCoordinates){
                    int z = (int) Math.Ceiling(coordinate.Z);
                    int y = (int) Math.Ceiling(coordinate.Y);
                    int x = (int) Math.Ceiling(coordinate.X);
                    debugCount++;
                    this.world.worldSpace[z,y,x] = 1;
                }
            }
            Console.WriteLine(debugCount);
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

            Console.WriteLine(new string('_',camera.width));

            for (int i = 0; i < screenHeight; i++)
            {
                for(int j = 0 ; j<screenWidth ; j++)
                {   
                    if(j==0){
                        Console.Write("|");
                    }

                    if(screen[i,j]==1){
                        Console.Write(pixel);
                    }else{
                        Console.Write(' ');
                    }

                    if(j==screenWidth-1){
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('_',camera.width));
        }
    }

}

// public void ProjectWorldToCamera(Camera camera){
            
//             // Camera camera = this.world.camera;
//             int[,] screen = camera.cameraScreen;
//             List<WorldObject> worldObjects = this.world.worldObjects;
//             int count = 0;
            
//             for(int i = 0 ; i<this.world.maxZ;i++){

//                 for(int j = 0 ;j<this.world.maxY ;j++){

//                     for(int k = 0;k<this.world.maxX;k++){

//                         if(this.world.worldSpace[i,j,k]==1){
//                             count++;                                
//                             var intrPoint = Computation.FindIntersectionPoint(new Coordinate(k,j,i),camera.focalPoint,camera.cameraPlaneEq);
                            
//                             screen[(int)intrPoint.Y,(int)intrPoint.X] = 1;

//                         }
//                     }
//                 }
//             }
            
//             for(int i = 0;i<camera.height;i++){

//                 for(int j = 0;j<camera.width;j++){

//                     if(screen[i,j]==1){
//                         Console.Write('█');
                        
//                     }else{
//                         Console.Write(' ');
//                     }
//                 }
//                 Console.WriteLine();
//             }

//             Console.WriteLine(count);
//         }
 