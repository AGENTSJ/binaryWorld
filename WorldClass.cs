using System.Collections.Generic;
using ComputationTypes;
using Computations;

namespace Worlds
{
    public class World
    {
        public int maxX;
        public int maxY;
        public int maxZ;

        public Camera camera;
        public List<WorldObject> worldObjects;

        public int[,,] worldSpace;
        // public int[][][] world = new int[100][][];
        public World(int x, int y, int z)
        {
            this.maxX = x;
            this.maxY = y;
            this.maxZ = z;

            worldSpace = new int[z, y, x];
            // for(int i = 0;i<100;i++){
            //     world[i] = new int[100][];
            //     world[i][i] = new int[100];
            // }
            worldObjects = new List<WorldObject>();
        }

    }
   
    public class Camera
    {
        public Coordinate topLeft;
        public Coordinate topRight;
        public Coordinate bottomLeft;
        public Coordinate bottomRight;
        public double zoomFactor = -5;
        public Coordinate focalPoint;
        public PlaneEquation cameraPlaneEq;
        
        public Camera(Coordinate topLeft, Coordinate bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            //obtaing other two cordinates with just in case can be removed if foudn useless
            this.topRight = new Coordinate(bottomRight.X, topLeft.Y,0);
            this.bottomLeft = new Coordinate(topLeft.X, bottomRight.Y,0);  

            this.cameraPlaneEq = Computation.FindPlaneEquation(this.topLeft,this.bottomLeft,this.topRight);
            
            this.focalPoint = new Coordinate(this.topRight.X/2, this.topRight.Y/2 ,zoomFactor);
        }

    }
    public class WorldObject
    {
        public List<Coordinate> occupiedCoordinates= new List<Coordinate>();

    }

   
}
