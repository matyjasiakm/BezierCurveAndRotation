using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Gk3
{   /// <summary>
    /// Rectangle structure used to computing if points are in rectangle during naiv rotation.
    /// </summary>
    public class MyRectangle
    {
        Vertex vertex1, vertex2, vertex3, vertex4;

        public MyRectangle(Vertex v1, Vertex v2, Vertex v3, Vertex v4)
        {
            vertex1 = v1;
            vertex2 = v2;
            vertex3 = v3;
            vertex4 = v4;
        }
        private int sign(Vertex v1, Vertex v2, Vertex v3)
        {
            double pom = (v1.X - v3.X) * (v2.Y - v3.Y) - (v2.X - v3.X) * (v1.Y - v3.Y);
            if (pom < 0) return -1;
            if (pom > 0) return 1;
            return 0;
        }
        public int minX()
        {
            double pom = Min(vertex1.X, vertex2.X);
            pom = Min(pom, vertex3.X);
            pom = Min(pom, vertex4.X);
            return (int)pom;
        }
        public int minY()
        {
            double pom = Min(vertex1.Y, vertex2.Y);
            pom = Min(pom, vertex3.Y);
            pom = Min(pom, vertex4.Y);
            return (int)pom;
        }
        public int maxX()
        {
            double pom = Max(vertex1.X, vertex2.X);
            pom = Max(pom, vertex3.X);
            pom = Max(pom, vertex4.X);
            return (int)pom;
        }
        public int maxY()
        {
            double pom = Max(vertex1.Y, vertex2.Y);
            pom = Max(pom, vertex3.Y);
            pom = Max(pom, vertex4.Y);
            return (int)pom;
        }
        public bool InRectangle(Vertex v)
        {
            bool b1 = false;
            int a1 = sign(vertex1, vertex2, v), a2 = sign(vertex2, vertex3, v), a3 = sign(vertex3, vertex1, v);
            int a4 = sign(vertex3, vertex4, v), a5 = sign(vertex4, vertex1, v), a6 = sign(vertex1, vertex3, v);
            if (a1 >= 0 && a2 >= 0 && a3 >= 0)
            {
                b1 = true;
            }
            bool b2 = false;
            if (a4 >= 0 && a5 >= 0 && a6 >= 0)
            {
                b2 = true;
            }

            return b1 || b2;

        }
    }
}
