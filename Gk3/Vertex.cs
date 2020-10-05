using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gk3
{
    /// <summary>
    /// Vertex class
    /// </summary>
    public class Vertex : ICloneable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vertex()
        {
            X = 0;
            Y = 0;
        }
        public Vertex Copy()
        {
            return new Vertex(X, Y);
        }

        public object Clone()
        {
            return new Vertex(X, Y);
        }

        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(a.X + b.X, a.Y + b.Y);
        }
        public static Vertex operator -(Vertex a, Vertex b)
        {
            return new Vertex(a.X - b.X, a.Y - b.Y);
        }
        public static Vertex operator /(Vertex a, double b)
        {
            return new Vertex(a.X / b, a.Y / b);
        }
        public static Vertex operator *(Vertex a, double b)
        {
            return new Vertex(a.X * b, a.Y * b);
        }
        public double length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }
}
