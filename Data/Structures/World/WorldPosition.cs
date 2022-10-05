using Data.Structures.Geometry;
using System;

namespace Data.Structures.World
{
    public class WorldPosition
    {
        public int MapId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float X2;
        public float Y2;
        public float Z2;

        public double DistanceTo(float x, float y)
        {
            double a = x - X;
            double b = y - Y;

            return Math.Sqrt(a * a + b * b);
        }

        public double DistanceTo(float x, float y, float z)
        {
            double a = x - X;
            double b = y - Y;
            double c = z - Z;

            return Math.Sqrt(a * a + b * b + c * c);
        }

        public double DistanceTo(WorldPosition p2)
        {
            if (p2 == null)
                return double.MaxValue;

            double a = p2.X - X;
            double b = p2.Y - Y;
            double c = p2.Z - Z;

            return Math.Sqrt(a * a + b * b + c * c);
        }

        public double FastDistanceTo(WorldPosition p2)
        {
            double a = p2.X - X;
            double b = p2.Y - Y;

            return Math.Sqrt(a * a + b * b);
        }

        public WorldPosition Clone()
        {
            WorldPosition clone = (WorldPosition)MemberwiseClone();
            return clone;
        }

        public void CopyTo(WorldPosition position)
        {
            position.X = X;
            position.Y = Y;
            position.Z = Z;
        }

        public void CopyTo(Point3D point)
        {
            point.X = X;
            point.Y = Y;
            point.Z = Z;
        }

        public bool IsNull()
        {
            return X == 0f && Y == 0f && Z == 0f;
        }
    }
}
