using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Code39
{
    public class Code39
    {
        private String START = "1001011011010";
        private String STOP =  "1001011011010";
        private String QUIET_ZONE = "000000000000000000000000";
        private String GAP = "0";
        public bool CHECKSUM = false;

        private String value2encoding(int i)
        {
            switch (i)
            {
                case 0: return "101001101101";
                case 1: return "110100101011";
                case 2: return "101100101011";
                case 3: return "101100101011";
                case 4: return "101001101011";
                case 5: return "110100110101";
                case 6: return "101100110101";
                case 7: return "101001011011";
                case 8: return "110100101101";
                case 9: return "101100101101";
                case 10: return "110101001011";
                case 11: return "101101001011";
                case 12: return "110110100101";
                case 13: return "101011001011";
                case 14: return "110101100101";
                case 15: return "101101100101";
                case 16: return "101010011011";
                case 17: return "110101001101";
                case 18: return "101101001101";
                case 19: return "101011001101";
                case 20: return "110101010011";
                case 21: return "101101010011";
                case 22: return "110110101001";
                case 23: return "101011010011";
                case 24: return "110101101001";
                case 25: return "101101101001";
                case 26: return "101010110011";
                case 27: return "110101011001";
                case 28: return "101101011001";
                case 29: return "101011011001";
                case 30: return "110010101011";
                case 31: return "100110101011";
                case 32: return "110011010101";
                case 33: return "100101101011";
                case 34: return "100101101011";
                case 35: return "100110110101";
                case 36: return "100101011011";
                case 37: return "110010101101";
                case 38: return "100110101101";
                case 39: return "100100100101";
                case 40: return "100100101001";
                case 41: return "100101001001";
                case 42: return "101001001001";
                case 43: return "100101101101";
            }
            return null;
        }

        private String partial1(String c)
        {
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            h.Add("0", "101001101101");
            h.Add("1", "110100101011");
            h.Add("2", "101100101011");
            h.Add("3", "110110010101");
            h.Add("4", "101001101011");
            h.Add("5", "110100110101");
            h.Add("6", "101100110101");
            h.Add("7", "101001011011");
            h.Add("8", "110100101101");
            h.Add("9", "101100101101");
            h.Add("A", "110101001011");
            h.Add("B", "101101001011");
            h.Add("C", "110110100101");
            h.Add("D", "101011001011");
            h.Add("E", "110101100101");
            h.Add("F", "101101100101");
            h.Add("G", "101010011011");
            h.Add("H", "110101001101");
            h.Add("I", "101101001101");
            h.Add("J", "101011001101");
            h.Add("K", "110101010011");
            h.Add("L", "101101010011");
            h.Add("M", "110110101001");
            h.Add("N", "101011010011");
            h.Add("O", "110101101001");
            h.Add("P", "101101101001");
            h.Add("Q", "101010110011");
            h.Add("R", "110101011001");
            h.Add("S", "101101011001");
            h.Add("T", "101011011001");
            h.Add("U", "110010101011");
            h.Add("V", "100110101011");
            h.Add("W", "110011010101");
            h.Add("X", "100101101011");
            h.Add("Y", "110010110101");
            h.Add("Z", "100110110101");
            h.Add("-", "100101011011");
            h.Add(".", "110010101101");
            h.Add(" ", "100110101101");
            h.Add("$", "100100100101");
            h.Add("/", "100100101001");
            h.Add("+", "100101001001");
            h.Add("%", "101001001001");

            if (h.ContainsKey(c) == true)
            {
                return h[c].ToString();
            }
            return null;
        }

        private int Checksum1(String c)
        {
            String allchars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            allchars += "-. $/+%*";

            System.Collections.Hashtable h = new System.Collections.Hashtable();

            for (int i = 0; i < allchars.Length; i++)
            {
                h.Add(System.Convert.ToString(allchars[i]), i.ToString());
            }

            int checksum = 0;
            for (int i = 0; i < c.Length; i++)
            {
                int adder = System.Convert.ToInt16(h[c[i].ToString()].ToString());
                checksum += adder;
            }

            checksum = checksum % 43;
            return checksum;
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
            
            // Each character will take up 12 bits in the string
            // Plus, the start, end, and four quite zones are all included
            // And add one because it helps center things
            // int len = ((str.Length + 6) * 13);
            int height = 40;
            // System.Drawing.Bitmap b = new System.Drawing.Bitmap(len, height);
            String bits = QUIET_ZONE + START;

            for (int qq = 0; qq < str.Length; qq++)
            {
                bits += partial1(str[qq].ToString()) + GAP;
            }

            // bits += value2encoding(Checksum1(str)) + STOP + QUIET_ZONE;
            if (CHECKSUM)
            {
                bits += value2encoding(Checksum1(str)) + STOP + QUIET_ZONE;
            }
            else
            {
                bits += STOP + QUIET_ZONE;
            }

            // System.Windows.Forms.MessageBox.Show(bits.Length.ToString());

            int y = 0;

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(bits.Length, height);

            while (y < height)
            {
                int x = 0;
                // while (x < (len - 1))
                // while (x < (bits.Length - 1))
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

            /*
            if (1 == 2)
            {
                b = ResizeBitmap(b, System.Convert.ToInt16(bits.Length * 1.7), System.Convert.ToInt16(height * 1.6));
            }
            */

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
            return (12 * 4) + ((str.Length + 2) * 13);
        }

    }
}
