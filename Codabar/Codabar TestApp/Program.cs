using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Codabar_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Codabar.Codabar c = new Codabar.Codabar();
            Bitmap b = c.GetBarcodeBitmap("40156");
            b.Save(@"e:\codabar.tif", System.Drawing.Imaging.ImageFormat.Tiff);

        }
    }
}
