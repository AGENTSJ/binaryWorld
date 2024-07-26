using ComputationTypes;
using Worlds; 


namespace WorldFunctions {

    class WorldFunctions {

        public World world;
        public WorldFunctions(World world){
            this.world = world;
        }
        public void AddbjectToWorld(WorldObject worldObject){
            world.worldObjects.Add(worldObject);
        }
        public void PlaceObjectsInWorld(List<WorldObject> worldObjects){

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
        
        public void AddCubeToWorld(Coordinate spawnPoint , double sideLength){
            
        }
    }

}