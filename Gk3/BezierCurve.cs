using Gk3.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gk3
{   /// <summary>
    /// A class thath draw bezier curve and animate image throught it
    /// </summary>
    public class BezierCurve
    {
        protected Vertex[] bSplinePoints;
        Vertex[] breizerPoints;
        int radius = 6;
        public bool drawPolylineEnable;
        AnimatedPicture animatedPicture;
        Vertex actualPicturePositionOnCurve;
        public bool animatedActive;
        public bool rotationNaivActive;
        public bool rotationFilterActive;
        public bool animate;
        int actualsegment;
        double actualt;
        static double d = 0.01;
        public int PolylinePointsNumber { get; private set; }


        public List<Vertex> GetbSpline()
        {
            return bSplinePoints.ToList();
        }

        public BezierCurve(List<Vertex> list, Bitmap image)
        {
            drawPolylineEnable = true;
            bSplinePoints = list.ToArray();
            animatedPicture = new AnimatedPicture(image);
            actualPicturePositionOnCurve = new Vertex(-1, -1);
            animatedActive = false;
            actualsegment = 0;
            actualt = 0;
            rotationNaivActive = false;
            animate = false;
            PolylinePointsNumber = list.Count;
        }

        public BezierCurve(int m, int width, int height, Bitmap image)
        {
            drawPolylineEnable = true;
            double interval = (double)width / (m + 2);
            List<Vertex> list = new List<Vertex>();
            list.Add(new Vertex(interval, height / 2));
            for (int i = 2; i < m; i++)
            {
                if (i % 2 == 0)
                    list.Add(new Vertex(interval * i, height * 0.9));
                if (i % 2 == 1)
                    list.Add(new Vertex(interval * i, height * 0.1));
            }
            if (m > 1)
                list.Add(new Vertex(interval * (m + 1), height / 2));

            bSplinePoints = list.ToArray();
            animatedPicture = new AnimatedPicture(image);
            actualPicturePositionOnCurve = new Vertex(-1, -1);
            animatedActive = false;
            actualsegment = 0;
            actualt = 0;
            rotationNaivActive = false;
            animate = false;
            PolylinePointsNumber = m;

        }

        /// <summary>
        /// Converts bsplines to 3rd degree bezier segments
        /// </summary>
        private void bSplineToBreizerVertex()
        {
            List<Vertex> list = new List<Vertex>();
            if (bSplinePoints.Length > 4)
            {
                list.Add(bSplinePoints[0]);
                list.Add(bSplinePoints[1]);

                for (int i = 1; i <= bSplinePoints.Length - 3; i++)
                {
                    if (i == 1)
                    {
                        list.Add((bSplinePoints[i] + bSplinePoints[i + 1]) / 2d);
                    }
                    else if (i == bSplinePoints.Length - 3)
                    {
                        Vertex vertex1 = (bSplinePoints[i] + bSplinePoints[i + 1]) / 2d;
                        Vector vector = new Vector(list[list.Count - 1], vertex1);
                        list.Add(new Vertex(list[list.Count - 1].X + vector.U / 2d, list[list.Count - 1].Y + vector.V / 2d));
                        list.Add(vertex1);
                    }
                    else
                    {
                        Vector vector = new Vector(bSplinePoints[i], bSplinePoints[i + 1]);

                        Vertex vertex1 = new Vertex(bSplinePoints[i].X + vector.U / 3d, bSplinePoints[i].Y + vector.V / 3d);

                        Vector vector1 = new Vector(list[list.Count - 1], vertex1);

                        list.Add(new Vertex(list[list.Count - 1].X + vector1.U / 2d, list[list.Count - 1].Y + vector1.V / 2d));
                        list.Add(vertex1);
                        list.Add(new Vertex(bSplinePoints[i].X + vector.U * 2d / 3d, bSplinePoints[i].Y + vector.V * 2d / 3d));

                    }
                }

                list.Add(bSplinePoints[bSplinePoints.Length - 2]);
                list.Add(bSplinePoints[bSplinePoints.Length - 1]);
            }
            else if (bSplinePoints.Length == 4)
            {
                list = bSplinePoints.ToList();
            }
            else if (bSplinePoints.Length == 3)
            {
                list = bSplinePoints.ToList();
                list.Add(list[list.Count - 1].Copy());
            }
            else if (bSplinePoints.Length == 2)
            {
                list = bSplinePoints.ToList();
                list.Add(list[list.Count - 1].Copy());
                list.Add(list[list.Count - 1].Copy());

            }
            else
            {
                list = bSplinePoints.ToList();
                list.Add(list[list.Count - 1].Copy());
                list.Add(list[list.Count - 1].Copy());
                list.Add(list[list.Count - 1].Copy());
            }

            breizerPoints = list.ToArray();
        }
        /// <summary>
        /// The auxiliary function that sets the next center point of the drawn image on the bezier curve
        /// </summary>
        /// <param name="d"></param>
        private void Translate(double d)
        {
            Vertex A0 = breizerPoints[actualsegment * 3];
            Vertex A1 = breizerPoints[actualsegment * 3 + 1];
            Vertex A2 = breizerPoints[actualsegment * 3 + 2];
            Vertex A3 = breizerPoints[actualsegment * 3 + 3];
            actualt += d;
            Vertex nextpoint = A0 * Math.Pow(1 - actualt, 3) + A1 * Math.Pow(1 - actualt, 2) * 3 * actualt + A2 * (1 - actualt) * 3 * actualt * actualt + A3 * actualt * actualt * actualt;
            if (actualt >= 1)
            {
                actualt = 0;
                actualsegment += 1;
            }
            if (actualsegment * 3 + 2 > breizerPoints.Length) actualsegment = 0;
            animatedPicture.TranslateToPoint(nextpoint);
        }
        /// <summary>
        /// Draws a picture and a bezier curve
        /// </summary>
        /// <param name="g">Picture box Graphics</param>
        /// <param name="picturebox">Picture box</param>
        public void DrawBezierCurve(Graphics g, PictureBox picturebox)
        {
            DirectBitmap direct = new DirectBitmap(picturebox.Width, picturebox.Height);
            Graphics graphics = Graphics.FromImage(direct.Bitmap);
            bSplineToBreizerVertex();
            for (int i = 0; i < breizerPoints.Length - 1; i += 3)
            {
                Vertex P = breizerPoints[i];
                Vertex A1 = (breizerPoints[i + 1] - breizerPoints[i]) * 3d;
                Vertex A2 = (breizerPoints[i + 2] - breizerPoints[i + 1] * 2d + breizerPoints[i]) * 3d;
                Vertex A3 = breizerPoints[i + 3] - breizerPoints[i + 2] * 3d + breizerPoints[i + 1] * 3d - breizerPoints[i];
                Vertex deltaP = A3 * d * d * d + A2 * d * d + A1 * d;
                Vertex delta2P = A3 * 6 * d * d * d + A2 * 2 * d * d;
                Vertex delta3P = A3 * 6 * d * d * d;
                for (double j = d; j <= 1; j += d)
                {
                    Vertex newP = P + deltaP;
                    Vertex newDeltaP = deltaP + delta2P;
                    Vertex newDeltaP2 = delta2P + delta3P;

                    g.DrawLine(Pens.Black, (int)P.X, (int)P.Y, (int)newP.X, (int)newP.Y);

                    P = newP;
                    deltaP = newDeltaP;
                    delta2P = newDeltaP2;
                }
            }

            List<Point> list = new List<Point>();
            for (int i = 0; i < breizerPoints.Length; i++)
            {
                list.Add(new Point((int)breizerPoints[i].X, (int)breizerPoints[i].Y));
            }


            if (drawPolylineEnable == true)
            {
                for (int i = 0; i < bSplinePoints.Length - 1; i++)
                {
                    graphics.DrawLine(Pens.Aqua, (int)bSplinePoints[i].X, (int)bSplinePoints[i].Y, (int)bSplinePoints[i + 1].X, (int)bSplinePoints[i + 1].Y);
                    graphics.FillEllipse(new SolidBrush(Color.Red), (int)bSplinePoints[i].X - radius / 2, (int)bSplinePoints[i].Y - radius / 2, radius, radius);

                }
                graphics.FillEllipse(new SolidBrush(Color.Red), (int)bSplinePoints[bSplinePoints.Length - 1].X - radius / 2, (int)bSplinePoints[bSplinePoints.Length - 1].Y - radius / 2, radius, radius);
            }
            if (animate)
            {
                if (animatedActive)
                {
                    Translate(d);
                }
                else if (rotationNaivActive)
                {
                    Translate(0);
                    animatedPicture.RotateNaiv(Math.PI / 12d);
                }
                else if (rotationFilterActive)
                {
                    Translate(0);
                    animatedPicture.RotateFiltering(Math.PI / 12d);
                }
            }
            else
            {
                Translate(0);
            }
            animatedPicture.DrawOnDirectBitmap(direct);


            g.DrawImage(direct.Bitmap, 0, 0);
            direct.Dispose();

        }
        public Vertex GetClickedPoint(int x, int y)
        {
            if (drawPolylineEnable)
            {
                foreach (var elem in bSplinePoints)
                    if (Math.Sqrt(Math.Pow(elem.X - x, 2) + Math.Pow(elem.Y - y, 2)) <= radius)
                        return elem;
            }
            return null;
        }
        public void MoveVertexTo(Vertex vertex, int x, int y)
        {
            vertex.X = x;
            vertex.Y = y;
        }
    }
}
