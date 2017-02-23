using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Code39_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Code39.Code39 c39 = new Code39.Code39();
            c39.CHECKSUM = false;
            Bitmap b = c39.GetBarcodeBitmap("123");
            b.Save("code39.bmp");
            //b.Save("code39.tif", System.Drawing.Imaging.ImageFormat.Tiff);
            //b.Save("code39.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
