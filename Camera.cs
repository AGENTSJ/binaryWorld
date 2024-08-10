using ComputationTypes;
using Computations;

namespace camera {
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
            setCameraEq(topLeft, bottomRight);
            this.height = (int)(bottomRight.Y - topLeft.Y);
            this.width = (int)(bottomRight.X - topLeft.X);
            cameraScreen = new int[height, width];
        }

        public void setCameraEq(Coordinate topLeft, Coordinate bottomRight)
        {

            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            this.topRight = new Coordinate(bottomRight.X, topLeft.Y, this.topLeft.Z);
            this.bottomLeft = new Coordinate(topLeft.X, bottomRight.Y, bottomRight.Z);

            this.cameraPlaneEq = Computation.FindPlaneEquation(this.topLeft, this.bottomLeft, this.topRight);

            this.focalPoint = new Coordinate(this.bottomRight.X / 2, this.bottomRight.Y / 2, this.bottomRight.Z + zoomFactor);

        }

        public void MoveForward(int step)
        {
            this.topLeft.Z += step;
            this.bottomRight.Z += step;
            this.setCameraEq(this.topLeft, this.bottomRight);
            this.cameraScreen = new int[this.height, this.width];
                            
        }

        public void MoveBackward(int step)
        {
            this.topLeft.Z -= step;
            this.bottomRight.Z -= step;
            this.setCameraEq(this.topLeft, this.bottomRight);
            this.cameraScreen = new int[this.height, this.width];
        }

        public void MoveLeft(int step)
        {
            this.topLeft.X += step;
            this.bottomRight.X += step;
            this.setCameraEq(this.topLeft, this.bottomRight);
            this.cameraScreen = new int[this.height, this.width];
        }

        public void MoveRight(int step)
        {
            this.topLeft.X -= step;
            this.bottomRight.X -= step;
            this.setCameraEq(this.topLeft, this.bottomRight);
            this.cameraScreen = new int[this.height, this.width];
        }

        public void MoveUp(int step)
        {
            this.topLeft.Y -= step;
            this.bottomRight.Y -= step;
            this.setCameraEq(this.topLeft, this.bottomRight);
            this.cameraScreen = new int[this.height, this.width];      
        }

        public void MoveDown(int step)
        {
            this.topLeft.Y += step;
            this.bottomRight.Y += step;
            this.setCameraEq(this.topLeft, this.bottomRight);
            this.cameraScreen = new int[this.height, this.width];
        }
    }
}