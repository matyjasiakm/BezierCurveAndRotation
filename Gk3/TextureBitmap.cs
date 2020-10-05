using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gk3
{
    public class TextureBitmap
    {

        int bytes;
        int bytesPerPixel;
        int width, height;
        byte[] rgbValues;
        int stride;

        public TextureBitmap(Bitmap bitmap)
        {
            width = bitmap.Width;
            height = bitmap.Height;
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            bytesPerPixel = Bitmap.GetPixelFormatSize(PixelFormat.Format24bppRgb) / 8;
            bytes = Math.Abs(bmpData.Stride) * bitmap.Height; stride = bmpData.Stride;
            rgbValues = new byte[bytes];
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            bitmap.UnlockBits(bmpData);

        }

        public Color GetColor(int x, int y)
        {
            int R, G, B; x = x % width;
            y = y % height;
            if (y >= 0 && x >= 0)
            {
                R = rgbValues[x * bytesPerPixel + y * stride];
                G = rgbValues[x * bytesPerPixel + 1 + y * stride];
                B = rgbValues[x * bytesPerPixel + 2 + y * stride];
                return Color.FromArgb(255, B, G, R);
            }
            return Color.White;

        }
    }
}
