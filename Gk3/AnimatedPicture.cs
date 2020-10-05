using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gk3
{
    /// <summary>
    /// Class holds the image that is on the bezier curve and animates it. 
    // The image is transformed and rotated on a bitmap using the drawing function.
    /// </summary>
    public class AnimatedPicture
    {
        Vertex[][] pixelPositions;
        RGB[][] pixelColors;
        Bitmap image;
        Vertex actualPositionOfImageMiddlePoint;
        TextureBitmap bitmapWithColor;
        static int size = 150;
        double fi;
        public bool rotationNaiv;
        public bool rotationFilter;
        double deegre;

        public AnimatedPicture(Bitmap image_)
        {
            image = new Bitmap(image_, size, size);
            actualPositionOfImageMiddlePoint = new Vertex();
            bitmapWithColor = new TextureBitmap(image);
            pixelPositions = new Vertex[size][];
            pixelColors = new RGB[size][];
            rotationNaiv = false;
            deegre = 0;
            fi = 0;

            for (int i = 0; i < size; i++)
            {
                pixelPositions[i] = new Vertex[size];
                pixelColors[i] = new RGB[size];

                for (int j = 0; j < size; j++)
                {
                    pixelPositions[i][j] = new Vertex(j - size / 2, i - size / 2);
                    pixelColors[i][j] = new RGB(bitmapWithColor.GetColor(j, i).R, bitmapWithColor.GetColor(j, i).G, bitmapWithColor.GetColor(j, i).B);
                }
            }


        }
        /// <summary>
        /// Naiv rotation
        /// </summary>
        /// <param name="theta">Rotation deegre</param>
        public void RotateNaiv(double theta = 0)
        {
            fi += theta;
            fi %= 2 * Math.PI;
            deegre = 0;
            rotationFilter = false;
            rotationNaiv = true;
        }
        /// <summary>
        /// Rotation by Shearing
        /// </summary>
        /// <param name="deg">Rotation degree</param>
        public void RotateFiltering(double deg = 0)
        {
            fi = 0;
            deegre += deg;
            deegre %= 2 * Math.PI;
            rotationFilter = true;
            rotationNaiv = false;
        }
        /// <summary>
        /// Middle point of image to vertex translation. Another points translatiown with middle point - vertex vector 
        /// </summary>
        /// <param name="vertex">Vertex to translate middle point of image</param>
        public void TranslateToPoint(Vertex vertex)
        {
            Vector vector = new Vector(actualPositionOfImageMiddlePoint, vertex);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    pixelPositions[i][j].X += vector.U;
                    pixelPositions[i][j].Y += vector.V;
                }
            }
            actualPositionOfImageMiddlePoint = vertex;
        }

        /// <summary>
        /// Obrót obrazka o 90 stopni
        /// </summary>
        /// <param name="tab">Kolory obrazka</param>
        /// <returns></returns>
        private RGB[][] RotationLeft90(RGB[][] tab)
        {
            RGB[][] newtab = new RGB[tab.GetLength(0)][];
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab[i].GetLength(0); j++)
                {
                    newtab[i] = new RGB[tab[i].GetLength(0)];
                }
            }

            for (int i = 0; i < tab[0].GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(0); j++)
                {
                    newtab[j][i] = (RGB)tab[i][tab[0].GetLength(0) - 1 - j].Clone();
                }
            }

            return newtab;
        }

        /// <summary>
        /// Drawing on bitmap
        /// </summary>
        /// <param name="direct">Bitmap to drawning</param>
        public void DrawOnDirectBitmap(DirectBitmap direct)
        {
            if (rotationFilter)
            {
                RGB[][] newPixelsColors;
                if (deegre >= 0 && deegre < Math.PI / 2)
                    newPixelsColors = pixelColors;

                else if (deegre >= Math.PI / 2 && deegre < Math.PI)
                {
                    newPixelsColors = RotationLeft90(pixelColors);
                }
                else if (deegre >= Math.PI && deegre < Math.PI * 3 / 2)
                {
                    newPixelsColors = RotationLeft90(pixelColors);
                    newPixelsColors = RotationLeft90(newPixelsColors);

                }
                else
                {
                    newPixelsColors = RotationLeft90(pixelColors);
                    newPixelsColors = RotationLeft90(newPixelsColors);
                    newPixelsColors = RotationLeft90(newPixelsColors);
                }

                double rotationAngle = deegre % (Math.PI / 2);
                double l = Math.Tan(rotationAngle / 2);
                double k = Math.Sin(rotationAngle);
                RGB[][] newPixelsColors = Xshear(l, newPixelsColors);
                newPixelsColors = Yshear(k, newPixelsColors);
                newPixelsColors = Xshear(l, newPixelsColors);
                Vector vertex = new Vector(new Vertex(newPixelsColors[0].GetLength(0) / 2, newPixelsColors.GetLength(0) / 2), actualPositionOfImageMiddlePoint);
                for (int x = 0; x < newPixelsColors.GetLength(0); x++)
                {
                    for (int y = 0; y < newPixelsColors[x].GetLength(0); y++)
                    {
                        if (newPixelsColors[x][y] != null)
                        {
                            direct.SetPixel((int)(y + vertex.U), (int)(x + vertex.V), Color.FromArgb(newPixelsColors[x][y].R, newPixelsColors[x][y].G, newPixelsColors[x][y].B));
                        }
                    }
                }
            }
            else
            {
                double u = (0 - size / 2) * Math.Cos(fi) - Math.Sin(fi) * (0 - size / 2);
                double v = ((0 - size / 2)) * Math.Sin(fi) + Math.Cos(fi) * (0 - size / 2);
                Vertex v1 = new Vertex(u + size / 2, v + size / 2);

                u = ((size - 1 - size / 2) * Math.Cos(fi) - Math.Sin(fi) * (0 - size / 2));
                v = ((size - 1 - size / 2)) * Math.Sin(fi) + Math.Cos(fi) * (0 - size / 2);
                Vertex v2 = new Vertex(u + size / 2, v + size / 2);

                u = ((size - 1 - size / 2) * Math.Cos(fi) - Math.Sin(fi) * ((size - 1 - size / 2)));
                v = ((size - 1 - size / 2)) * Math.Sin(fi) + Math.Cos(fi) * ((size - 1 - size / 2));
                Vertex v3 = new Vertex(u + size / 2, v + size / 2);

                u = ((0 - size / 2)) * Math.Cos(fi) - Math.Sin(fi) * (size - 1 - size / 2);
                v = ((0 - size / 2)) * Math.Sin(fi) + Math.Cos(fi) * (size - 1 - size / 2);
                Vertex v4 = new Vertex(u + size / 2, v + size / 2);

                MyRectangle myRectangle = new MyRectangle(v1, v2, v3, v4);

                int fromX = myRectangle.minX();
                int fromY = myRectangle.minY();
                Vector vertex = new Vector(new Vertex(size / 2, size / 2), actualPositionOfImageMiddlePoint);
                for (int i = fromX; i <= myRectangle.maxX(); i++)
                {
                    for (int j = fromY; j <= myRectangle.maxY(); j++)
                    {
                        if (myRectangle.InRectangle(new Vertex(i, j)))
                        {
                            int x = (int)((i - size / 2) * Math.Cos(fi) + Math.Sin(fi) * (j - size / 2)) + size / 2;
                            int y = (int)((-(i - size / 2)) * Math.Sin(fi) + Math.Cos(fi) * (j - size / 2)) + size / 2;
                            if (i + vertex.U >= 0 && i + vertex.U < direct.Width && j + vertex.V >= 0 && j + vertex.V < direct.Height)
                            {
                                direct.SetPixel((int)(i + vertex.U), (int)(j + vertex.V), bitmapWithColor.GetColor(x, y));
                            }
                        }
                    }
                }
            }
        }


        private RGB[][] Xshear(double shear, RGB[][] rgbTab)
        {
            RGB[][] newTab = new RGB[rgbTab.GetLength(0)][];
            for (int p = 0; p < rgbTab.GetLength(0); p++)
            {
                newTab[p] = new RGB[rgbTab[0].GetLength(0) + Math.Abs((int)Math.Floor((shear * (rgbTab.GetLength(0) + 0.5))))];
            }

            for (int y = 0; y < rgbTab.GetLength(0); y++)
            {

                int ii = (int)(shear * (y + 0.5));
                double ff = shear * (y + 0.5) - Math.Truncate(shear * (y + 0.5));

                RGB prev_left = new RGB();

                for (int x = 0; x < rgbTab[y].GetLength(0); x++)
                {
                    RGB pixel = rgbTab[y][rgbTab[y].GetLength(0) - x - 1];
                    if (pixel == null) continue;
                    RGB left = pixel * ff;
                    pixel = pixel - left + prev_left;
                    prev_left = left;
                    newTab[y][rgbTab[y].GetLength(0) - x + ii - 1] = new RGB(pixel.R, pixel.G, pixel.B);
                }

            }
            return newTab;
        }

        private RGB[][] Yshear(double shear, RGB[][] rgbTab)
        {
            RGB[][] newTab = new RGB[rgbTab.GetLength(0) + (int)(shear * (rgbTab[0].GetLength(0) + 0.5))][];
            for (int p = 0; p < rgbTab.GetLength(0) + (int)(shear * (rgbTab[0].GetLength(0) + 0.5)); p++)
            {
                newTab[p] = new RGB[rgbTab[0].GetLength(0)];
            }

            for (int x = 0; x < rgbTab[0].GetLength(0); x++)
            {

                int ii = (int)(shear * (rgbTab[0].GetLength(0) - x + 0.5));
                double ff = shear * (rgbTab[0].GetLength(0) - x + 0.5) - Math.Truncate(shear * (rgbTab[0].GetLength(0) - x + 0.5));

                RGB prev_left = new RGB();

                for (int y = 0; y < rgbTab.GetLength(0); y++)
                {
                    RGB pixel = rgbTab[rgbTab.GetLength(0) - y - 1][x];
                    if (pixel == null) continue;
                    RGB left = pixel * ff;
                    pixel = pixel - left + prev_left;
                    prev_left = left;

                    newTab[rgbTab.GetLength(0) - y + ii - 1][x] = new RGB(pixel.R, pixel.G, pixel.B);
                }
            }
            return newTab;
        }

        /// <summary>
        /// A class that stores a color in RGB
        /// </summary>
        public class RGB : ICloneable
        {
            public int R;
            public int G;
            public int B;

            public RGB()
            {
                R = 0;
                G = 0;
                B = 0;
            }
            public RGB(int r, int g, int b)
            {
                R = r;
                B = b;
                G = g;
            }
            public static RGB operator -(RGB x, RGB y)
            {
                RGB z = new RGB();
                z.R = x.R - y.R;
                z.G = x.G - y.G;
                z.B = x.B - y.B;
                return z;
            }

            public static RGB operator +(RGB x, RGB y)
            {
                RGB z = new RGB();
                z.R = x.R + y.R;
                z.G = x.G + y.G;
                z.B = x.B + y.B;
                return z;


            }

            public static RGB operator *(RGB x, double y)
            {
                RGB z = new RGB();
                z.R = (int)(x.R * y);
                z.G = (int)(x.G * y);
                z.B = (int)(x.B * y);
                return z;


            }

            public object Clone()
            {
                return new RGB(R, G, B);
            }
        }
    }
}
