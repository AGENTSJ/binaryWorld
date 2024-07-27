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

        public World(int x, int y, int z)
        {
            this.maxX = x;
            this.maxY = y;
            this.maxZ = z;

            worldSpace = new int[z, y, x];
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
        
        public int height;
        public int width;
        public int[,] cameraScreen;

        public Camera(Coordinate topLeft, Coordinate bottomRight)
        {
            setCameraEq(topLeft,bottomRight);
            this. height = (int)(bottomRight.Y - topLeft.Y);
            this.width  = (int)(bottomRight.X-topLeft.X);
            cameraScreen = new int[height,width];
        }
        public void setCameraEq(Coordinate topLeft, Coordinate bottomRight){
            
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            this.topRight = new Coordinate(bottomRight.X, topLeft.Y,this.topLeft.Z);
            this.bottomLeft = new Coordinate(topLeft.X, bottomRight.Y,bottomRight.Z);  

            this.cameraPlaneEq = Computation.FindPlaneEquation(this.topLeft,this.bottomLeft,this.topRight);
            
            this.focalPoint = new Coordinate(this.bottomRight.X/2, this.bottomRight.Y/2 ,this.bottomRight.Z+zoomFactor);
    
        }

    }
    public class WorldObject
    {
        public List<Coordinate> occupiedCoordinates= new List<Coordinate>();

    }

   
}
