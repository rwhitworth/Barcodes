using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Codabar
{
    public class Codabar
    {
        public String START_A = "10110010010";
        public String START_B = "10100100110";
        public String START_C = "10010010110";
        public String START_D = "10100110010";

        public String START = "10110010010";
        private String QUIET_ZONE = "000000000000000000";

        private String value2encoding(int i)
        {
            switch (i)
            {
                case 0: return "11011001100";
            }
            return null;
        }

        private String partial1(String c)
        {
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            h.Add("0", "101010011");
            h.Add("1", "101011001");
            h.Add("2", "101001011");
            h.Add("3", "110010101");
            h.Add("4", "101101001");
            h.Add("5", "110101001");
            h.Add("6", "100101011");
            h.Add("7", "100101101");
            h.Add("8", "100110101");
            h.Add("9", "110100101");
            h.Add("-", "101001101");
            h.Add("$", "101100101");
            h.Add(":", "1101011011");
            h.Add("/", "1101101011");
            h.Add(".", "1101101101");
            h.Add("+", "101100110011");

            if (h.ContainsKey(c) == true)
            {
                return h[c].ToString();
            }
            return null;
        }

        private int Checksum1(String c)
        {
            // Codabar has no checksum value
            return 0;
        }

        public Bitmap GetBarcodeBitmap(String str)
        {
            if (str.Length > 30)
            {
                throw new ArgumentException("GetBitmap: str length too long");
            }
            if (str.Length < 1)
            {
                throw new ArgumentException("GetBitmap: str length too short");
            }
            
            // Each character will take up 11 bits in the string
            // Plus, the start, end, four quite zones, and check digit
            // And to top it off, the terminator string is two bits
            // int len = ((str.Length + 7) * 11) + 2;
            int height = 20;
            String bits = QUIET_ZONE + START;

            for (int qq = 0; qq < str.Length; qq++)
            {
                bits += partial1(str[qq].ToString()) + "0";
            }

            // bits += value2encoding(Checksum1(str)) + START + QUIET_ZONE;
            bits += START + QUIET_ZONE;

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(bits.Length, height);

            int y = 0;

            while (y < height)
            {
                int x = 0;
                while (x < bits.Length)
                {
                    if (bits[x].ToString() == "1")
                    {
                        b.SetPixel(x, y, Color.Black);
                    }
                    if (bits[x].ToString() == "0")
                    {
                        b.SetPixel(x, y, Color.White);
                    }
                    x++;
                }
                y++;
            }

            return b;
        }
        public Bitmap GetBarcodeBitmap(String str, int height, int width)
        {
            if (height < 10)
            {
                throw new ArgumentException("GetBitmap: height param invalid");
            }
            if (width < 40)
            {
                throw new ArgumentException("GetBitmap: width param invalid");
            }

            Bitmap result = null;

            try
            {
                result = GetBarcodeBitmap(str);

            }
            catch (Exception ee)
            {
                throw ee;
            }
            result = ResizeBitmap(result, width, height);
            return result;
        }

        private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }

        public int min_length(String str)
        {
            int count = (QUIET_ZONE.Length * 2) + (START.Length * 2) + 1;
            
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == "+")
                { count += 12; }
                if ((str[i].ToString() == ":") || (str[i].ToString() == "/") || (str[i].ToString() == "."))
                { count += 10; }
                else
                { count += 9; }
                count++; // each character is followed by a single blank line
            }
            
            return 0;
        }

    }
}
