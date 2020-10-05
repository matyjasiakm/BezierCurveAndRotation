using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
namespace Gk2
{
   public class Edge
    {
        Vertex from;
        Vertex to;
        public Vertex From
        {
            get { return from; }
            set { from = value; }
        }
        public Vertex To
        {
            get { return to; }
            set { to = value; }
        }
        public Edge(Vertex _from, Vertex _to)
        {
            from = _from;
            to = _to;
        }
        public int SignOfVectorProduct(Point point)
        {
            return Sign((to.X - from.X)*(point.Y - from.Y) - (point.X - from.X)*(to.Y - from.Y));
        }
    }
}
