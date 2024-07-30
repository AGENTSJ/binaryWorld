using ComputationTypes;
using System;
using Worlds;


namespace Computations
{
    internal class Computation
    {
        static public Vector CoordinatesToVector(Coordinate coord1, Coordinate coord2)
        {
            Vector newVector = new Vector();
            newVector.i = coord2.X - coord1.X;
            newVector.j = coord2.Y - coord1.Y;
            newVector.k = coord2.Z - coord1.Z;
            return newVector;
        }

        static public Vector CrossProduct(Vector a, Vector b)
        {
            Vector result = new Vector();
            result.i = (a.j * b.k) - (b.j * a.k);
            result.j = -1 * ((a.i * b.k) - (a.k * b.i));
            result.k = (a.i * b.j) - (a.j * b.i);
            return result;
        }

        static public PlaneEquation FindPlaneEquation(Coordinate coordP, Coordinate coordQ, Coordinate coordR)
        {
            PlaneEquation planeEq = new PlaneEquation();

            Vector pq = CoordinatesToVector(coordP, coordQ);
            Vector pr = CoordinatesToVector(coordP, coordR);
            Vector normal = CrossProduct(pq, pr);

            // taking a reference point p
            planeEq.coifX = normal.i;
            planeEq.coifY = normal.j;
            planeEq.coifZ = normal.k;

            planeEq.constant = -1 * normal.i * coordP.X;
            planeEq.constant += -1 * normal.j * coordP.Y;
            planeEq.constant += -1 * normal.k * coordP.Z;

            return planeEq;
        }

        static public Coordinate FindIntersectionPoint(Coordinate startPointA, Coordinate endPointB, PlaneEquation planeEq)
        {
            //
            Vector ab = CoordinatesToVector(startPointA, endPointB);
            double x;
            double y;
            double z;
            double t; //lamda in line equation 

            t = (planeEq.constant - (planeEq.coifX * startPointA.X + planeEq.coifY * startPointA.Y + planeEq.coifZ * startPointA.Z)) / (planeEq.coifX * ab.i + planeEq.coifY * ab.j + planeEq.coifZ * ab.k);

            x = startPointA.X + (ab.i * t);
            y = startPointA.Y + (ab.j * t);
            z = startPointA.Z + (ab.k * t);

            Coordinate interSectionCoordinate = new Coordinate(x, y, z);

            return interSectionCoordinate;

        }

        // static public bool IsInsideCameraPlane(Coordinate point,PlaneEquation cameraPlaneEq ){

        //     return true;
        // }
    }
}
