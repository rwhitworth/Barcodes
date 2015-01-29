using System;
using System.Collections.Generic;
using System.Text;


namespace Code128_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code128.Code128A a = new Code128.Code128A();
            // System.Drawing.Bitmap q = a.GetBarcodeBitmap("A-Z!@#", 100, 300);
            // q.Save(@"e:/barcode-a.bmp");
            Code128.Code128B b = new Code128.Code128B();
            System.Drawing.Bitmap q = b.GetBarcodeBitmap("1Aa*");
            System.Windows.Forms.MessageBox.Show(b.min_length("1Aa*").ToString());
            q.Save(@"e:/barcode-b.bmp");
        }
    }
}
