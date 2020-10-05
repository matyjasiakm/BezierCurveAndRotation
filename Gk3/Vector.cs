using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gk3
{
    /// <summary>
    /// Vector class
    /// </summary>
    public class Vector
    {
        public double U { get; set; }
        public double V { get; set; }

        public Vector(Vertex from, Vertex to)
        {
            U = to.X - from.X;
            V = to.Y - from.Y;
        }
    }
}
