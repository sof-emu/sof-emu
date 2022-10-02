using Newtonsoft.Json.Linq;
using System;

namespace Data.Models.World
{
    public class Position
    {
        public int MapId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        /// <summary>
        /// Distance from Position to Target X,Y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double DistanceTo(float x, float y)
        {
            double a = x - X;
            double b = y - Y;

            return Math.Sqrt(a * a + b * b);
        }

        /// <summary>
        /// Distance from Position to Target X,Y,Z
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public double DistanceTo(float x, float y, float z)
        {
            double a = x - X;
            double b = y - Y;
            double c = z - Z;

            return Math.Sqrt(a * a + b * b + c * c);
        }

        /// <summary>
        /// Distance from Position to Target Position
        /// </summary>
        /// <param name="p2"></param>
        /// <returns></returns>
        public double DistanceTo(Position p2)
        {
            if (p2 == null)
                return double.MaxValue;

            double a = p2.X - X;
            double b = p2.Y - Y;
            double c = p2.Z - Z;

            return Math.Sqrt(a * a + b * b + c * c);
        }

        /// <summary>
        /// Clone Position out
        /// </summary>
        /// <returns></returns>
        public Position Clone()
        {
            Position clone = (Position)MemberwiseClone();
            return clone;
        }

        /// <summary>
        /// Copy Position to param Position
        /// </summary>
        /// <param name="position"></param>
        public void CopyTo(Position position)
        {
            position.X = X;
            position.Y = Y;
            position.Z = Z;
        }
    }
}
