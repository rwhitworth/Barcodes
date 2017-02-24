using System;
using System.Drawing;

namespace Code39
{
    public class Code39
    {
        private const string START = "1001011011010";
        private const string STOP =  "1001011011010";
        private const string QUIET_ZONE = "000000000000000000000000";
        private const string GAP = "0";
        public bool CHECKSUM = false;

        #region checksum_bytes array
        private string[] checksum_bytes =
        {
            "101001101101", // 0
            "110100101011",
            "101100101011",
            "101100101011",
            "101001101011",
            "110100110101",
            "101100110101",
            "101001011011",
            "110100101101",
            "101100101101", 
            "110101001011", // 10
            "101101001011",
            "110110100101",
            "101011001011",
            "110101100101",
            "101101100101",
            "101010011011",
            "110101001101",
            "101101001101",
            "101011001101",
            "110101010011", // 20
            "101101010011",
            "110110101001",
            "101011010011",
            "110101101001",
            "101101101001",
            "101010110011",
            "110101011001",
            "101101011001",
            "101011011001",
            "110010101011", // 30
            "100110101011",
            "110011010101",
            "100101101011",
            "100101101011",
            "100110110101",
            "100101011011",
            "110010101101",
            "100110101101",
            "100100100101",
            "100100101001", // 40
            "100101001001",
            "101001001001",
            "100101101101"
        };
        #endregion

        private string partial(char c)
        {
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            // TODO: fix this abuse of Hashtable

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
            throw new Exception(String.Format("partial: input item {0} not in hashtable", c));
        }

        private byte checksum(string c)
        {
            String allchars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            allchars += "-. $/+%*";

            System.Collections.Hashtable h = new System.Collections.Hashtable();

            for (int i = 0; i < allchars.Length; i++)
            {
                h.Add(allchars[i], i.ToString());
            }

            byte checksum = 0;
            for (int i = 0; i < c.Length; i++)
            {
                checksum += System.Convert.ToByte(h[c[i]]);
            }

            checksum = Convert.ToByte(checksum % 43);
            return checksum;
        }

        public Bitmap GetBarcodeBitmap(string str)
        {
            if (str.Length > 30)
            {
                throw new ArgumentException("GetBarcodeBitmap: str length too long");
            }
            if (str.Length < 1)
            {
                throw new ArgumentException("GetBarcodeBitmap: str length too short");
            }
            
            int height = 40;
            String bits = QUIET_ZONE + START;

            for (int qq = 0; qq < str.Length; qq++)
            {
                bits += partial(str[qq]) + GAP;
            }

            if (CHECKSUM)
            {
                bits += checksum_bytes[checksum(str)] + STOP + QUIET_ZONE;
            }
            else
            {
                bits += STOP + QUIET_ZONE;
            }

            int y = 0;

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(bits.Length, height);

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
        public Bitmap GetBarcodeBitmap(string str, int height, int width)
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

        public int min_length(string str)
        {
            // TODO: describe this algorithm
            return (12 * 4) + ((str.Length + 2) * 13);
        }

    }
}
