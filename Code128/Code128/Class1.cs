using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Code128
{
    public class Code128A
    {
        private String START = "11010000100";
        private String STOP = "11000111010";
        private String TERMINATE = "11";
        private String QUIET_ZONE = "0000000000000000000000";

        private String value2encoding(int i)
        {
            switch (i)
            {
                case 0:
                    return "11011001100";
                case 1:
                    return "11001101100";
                case 2:
                    return "11001100110";
                case 3:
                    return "10010011000";
                case 4:
                    return "10010001100";
                case 5:
                    return "10001001100";
                case 6:
                    return "10011001000";
                case 7:
                    return "10011000100";
                case 8:
                    return "10001100100";
                case 9:
                    return "11001001000";
                case 10:
                    return "11001000100";
                case 11:
                    return "11000100100";
                case 12:
                    return "10110011100";
                case 13:
                    return "10011011100";
                case 14:
                    return "10011001110";
                case 15:
                    return "10111001100";
                case 16:
                    return "10011101100";
                case 17:
                    return "10011100110";
                case 18:
                    return "11001110010";
                case 19:
                    return "11001011100";
                case 20:
                    return "11001001110";
                case 21:
                    return "11011100100";
                case 22:
                    return "11001110100";
                case 23:
                    return "11101101110";
                case 24:
                    return "11101001100";
                case 25:
                    return "11100101100";
                case 26:
                    return "11100100110";
                case 27:
                    return "11101100100";
                case 28:
                    return "11100110100";
                case 29:
                    return "11100110010";
                case 30:
                    return "11011011000";
                case 31:
                    return "11011000110";
                case 32:
                    return "11000110110";
                case 33:
                    return "10100011000";
                case 34:
                    return "10001011000";
                case 35:
                    return "10001000110";
                case 36:
                    return "10110001000";
                case 37:
                    return "10001101000";
                case 38:
                    return "10001100010";
                case 39:
                    return "11010001000";
                case 40:
                    return "11000101000";
                case 41:
                    return "11000100010";
                case 42:
                    return "10110111000";
                case 43:
                    return "10110001110";
                case 44:
                    return "10001101110";
                case 45:
                    return "10111011000";
                case 46:
                    return "10111000110";
                case 47:
                    return "10001110110";
                case 48:
                    return "11101110110";
                case 49:
                    return "11010001110";
                case 50:
                    return "11000101110";
                case 51:
                    return "11011101000";
                case 52:
                    return "11011100010";
                case 53:
                    return "11011101110";
                case 54:
                    return "11101011000";
                case 55:
                    return "11101000110";
                case 56:
                    return "11100010110";
                case 57:
                    return "11101101000";
                case 58:
                    return "11101100010";
                case 59:
                    return "11100011010";
                case 60:
                    return "11101111010";
                case 61:
                    return "11001000010";
                case 62:
                    return "11110001010";
                case 63:
                    return "10100110000";
                case 64:
                    return "10100001100";
                case 65:
                    return "10010110000";
                case 66:
                    return "10010000110";
                case 67:
                    return "10000101100";
                case 68:
                    return "10000100110";
                case 69:
                    return "10110010000";
                case 70:
                    return "10110000100";
                case 71:
                    return "10011010000";
                case 72:
                    return "10011000010";
                case 73:
                    return "10000110100";
                case 74:
                    return "10000110010";
                case 75:
                    return "11000010010";
                case 76:
                    return "11001010000";
                case 77:
                    return "11110111010";
                case 78:
                    return "11000010100";
                case 79:
                    return "10001111010";
                case 80:
                    return "10100111100";
                case 81:
                    return "10010111100";
                case 82:
                    return "10010011110";
                case 83:
                    return "10111100100";
                case 84:
                    return "10011110100";
                case 85:
                    return "10011110010";
                case 86:
                    return "11110100100";
                case 87:
                    return "11110010100";
                case 88:
                    return "11110010010";
                case 89:
                    return "11011011110";
                case 90:
                    return "11011110110";
                case 91:
                    return "11110110110";
                case 92:
                    return "10101111000";
                case 93:
                    return "10100011110";
                case 94:
                    return "10001011110";
                case 95:
                    return "10111101000";
                case 96:
                    return "10111100010";
                case 97:
                    return "11110101000";
                case 98:
                    return "11110100010";
                case 99:
                    return "10111011110";
                case 100:
                    return "10111101110";
                case 101:
                    return "11101011110";
                case 102:
                    return "11110101110";
                case 103:
                    return "11010000100";
            }
            return null;
        }

        private String partial1(String c)
        {
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            h.Add(" ", "11011001100");
            h.Add("!", "11001101100");
            h.Add("\"", "11001100110");
            h.Add("#", "10010011000");
            h.Add("$", "10010001100");
            h.Add("%", "10001001100");
            h.Add("&", "10011001000");
            h.Add("'", "10011000100");
            h.Add("(", "10001100100");
            h.Add(")", "11001001000");
            h.Add("*", "11001000100");
            h.Add("+", "11000100100");
            h.Add(",", "10110011100");
            h.Add("-", "10011011100");
            h.Add(".", "10011001110");
            h.Add("/", "10111001100");
            h.Add("0", "10011101100");
            h.Add("1", "10011100110");
            h.Add("2", "11001110010");
            h.Add("3", "11001011100");
            h.Add("4", "11001001110");
            h.Add("5", "11011100100");
            h.Add("6", "11001110100");
            h.Add("7", "11101101110");
            h.Add("8", "11101001100");
            h.Add("9", "11100101100");
            h.Add(":", "11100100110");
            h.Add(";", "11101100100");
            h.Add("<", "11100110100");
            h.Add("=", "11100110010");
            h.Add(">", "11011011000");
            h.Add("?", "11011000110");
            h.Add("@", "11000110110");
            h.Add("A", "10100011000");
            h.Add("B", "10001011000");
            h.Add("C", "10001000110");
            h.Add("D", "10110001000");
            h.Add("E", "10001101000");
            h.Add("F", "10001100010");
            h.Add("G", "11010001000");
            h.Add("H", "11000101000");
            h.Add("I", "11000100010");
            h.Add("J", "10110111000");
            h.Add("K", "10110001110");
            h.Add("L", "10001101110");
            h.Add("M", "10111011000");
            h.Add("N", "10111000110");
            h.Add("O", "10001110110");
            h.Add("P", "11101110110");
            h.Add("Q", "11010001110");
            h.Add("R", "11000101110");
            h.Add("S", "11011101000");
            h.Add("T", "11011100010");
            h.Add("U", "11011101110");
            h.Add("V", "11101011000");
            h.Add("W", "11101000110");
            h.Add("X", "11100010110");
            h.Add("Y", "11101101000");
            h.Add("Z", "11101100010");
            h.Add("[", "11100011010");
            h.Add(@"\", "11101111010");
            h.Add("]", "11001000010");
            h.Add("^", "11110001010");
            h.Add("_", "10100110000");

            if (h.ContainsKey(c) == true)
            {
                return h[c].ToString();
            }
            return null;
        }

        private int Checksum1(String c)
        {
            /*
            Please note that this function does NOT support all
            characters in the Code128A dictionary.  
            
            Values 64 thru 105 are NOT supported as they are escape 
            sequences of one type or another.
            */
            String allchars = " !\"";
            allchars += "#$%&'()*+,-./";
            allchars += "0123456789";
            allchars += ":;<=>?@";
            allchars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            allchars += @"[\]^_";
            
            System.Collections.Hashtable h = new System.Collections.Hashtable();

            for (int i = 0; i < allchars.Length; i++) 
            {
                h.Add(System.Convert.ToString(allchars[i]), i.ToString());
            }

            /*
            
            h.Add("-", "13");
            h.Add("/", "15");
            h.Add("0", "16");
            h.Add("1", "17");
            h.Add("2", "18");
            h.Add("3", "19");
            h.Add("4", "20");
            h.Add("5", "21");
            h.Add("6", "22");
            h.Add("7", "23");
            h.Add("8", "24");
            h.Add("9", "25");
            h.Add(":", "26");
            for (int i = 0; i <= 26; i++)
            {
                Char tempchar = System.Convert.ToChar(65 + i);
                h.Add(tempchar.ToString(), i + 33);
            }
           
            // h.Add("A", "33");
            // h.Add("B", "34");
            // h.Add("H", "40");
            // h.Add("I", "41");
            
             */

            int checksum = 103;
            for (int i = 0; i < c.Length; i++)
            {
                int adder = System.Convert.ToInt16(h[c[i].ToString()].ToString());
                adder = adder * (i + 1);
                checksum += adder;
            }

            checksum = checksum % 103;
            return checksum;
        }

        public Bitmap GetBarcodeBitmap (String str)
        {
            // Each character will take up 11 bits in the string
            // Plus, the start, end, four quite zones, and check digit
            // And to top it off, the terminator string is two bits
            if (str.Length > 30)
            {
                throw new ArgumentException("GetBitmap: str length too long");
            }
            if (str.Length < 1)
            {
                throw new ArgumentException("GetBitmap: str length too short");
            }

            int len = ((str.Length + 7) * 11) + 2;
            int height = 20;
//            System.Drawing.Bitmap b = new System.Drawing.Bitmap(len, height);
            String bits = QUIET_ZONE + START;

            for (int qq = 0; qq < str.Length; qq++)
            {
                bits += partial1(str[qq].ToString());
            }

            bits += value2encoding(Checksum1(str)) + STOP + TERMINATE + QUIET_ZONE;

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(bits.Length, height);

            int y = 0;

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
            return ((str.Length + 7) * 11) + 2;
        }

    }

    public class Code128B
    {
        private String START = "11010010000";
        private String STOP = "11000111010";
        private String TERMINATE = "11";
        private String QUIET_ZONE = "0000000000000000000000";

        private String value2encoding(int i)
        {
            switch (i)
            {
                case 0:
                    return "11011001100";
                case 1:
                    return "11001101100";
                case 2:
                    return "11001100110";
                case 3:
                    return "10010011000";
                case 4:
                    return "10010001100";
                case 5:
                    return "10001001100";
                case 6:
                    return "10011001000";
                case 7:
                    return "10011000100";
                case 8:
                    return "10001100100";
                case 9:
                    return "11001001000";
                case 10:
                    return "11001000100";
                case 11:
                    return "11000100100";
                case 12:
                    return "10110011100";
                case 13:
                    return "10011011100";
                case 14:
                    return "10011001110";
                case 15:
                    return "10111001100";
                case 16:
                    return "10011101100";
                case 17:
                    return "10011100110";
                case 18:
                    return "11001110010";
                case 19:
                    return "11001011100";
                case 20:
                    return "11001001110";
                case 21:
                    return "11011100100";
                case 22:
                    return "11001110100";
                case 23:
                    return "11101101110";
                case 24:
                    return "11101001100";
                case 25:
                    return "11100101100";
                case 26:
                    return "11100100110";
                case 27:
                    return "11101100100";
                case 28:
                    return "11100110100";
                case 29:
                    return "11100110010";
                case 30:
                    return "11011011000";
                case 31:
                    return "11011000110";
                case 32:
                    return "11000110110";
                case 33:
                    return "10100011000";
                case 34:
                    return "10001011000";
                case 35:
                    return "10001000110";
                case 36:
                    return "10110001000";
                case 37:
                    return "10001101000";
                case 38:
                    return "10001100010";
                case 39:
                    return "11010001000";
                case 40:
                    return "11000101000";
                case 41:
                    return "11000100010";
                case 42:
                    return "10110111000";
                case 43:
                    return "10110001110";
                case 44:
                    return "10001101110";
                case 45:
                    return "10111011000";
                case 46:
                    return "10111000110";
                case 47:
                    return "10001110110";
                case 48:
                    return "11101110110";
                case 49:
                    return "11010001110";
                case 50:
                    return "11000101110";
                case 51:
                    return "11011101000";
                case 52:
                    return "11011100010";
                case 53:
                    return "11011101110";
                case 54:
                    return "11101011000";
                case 55:
                    return "11101000110";
                case 56:
                    return "11100010110";
                case 57:
                    return "11101101000";
                case 58:
                    return "11101100010";
                case 59:
                    return "11100011010";
                case 60:
                    return "11101111010";
                case 61:
                    return "11001000010";
                case 62:
                    return "11110001010";
                case 63:
                    return "10100110000";
                case 64:
                    return "10100001100";
                case 65:
                    return "10010110000";
                case 66:
                    return "10010000110";
                case 67:
                    return "10000101100";
                case 68:
                    return "10000100110";
                case 69:
                    return "10110010000";
                case 70:
                    return "10110000100";
                case 71:
                    return "10011010000";
                case 72:
                    return "10011000010";
                case 73:
                    return "10000110100";
                case 74:
                    return "10000110010";
                case 75:
                    return "11000010010";
                case 76:
                    return "11001010000";
                case 77:
                    return "11110111010";
                case 78:
                    return "11000010100";
                case 79:
                    return "10001111010";
                case 80:
                    return "10100111100";
                case 81:
                    return "10010111100";
                case 82:
                    return "10010011110";
                case 83:
                    return "10111100100";
                case 84:
                    return "10011110100";
                case 85:
                    return "10011110010";
                case 86:
                    return "11110100100";
                case 87:
                    return "11110010100";
                case 88:
                    return "11110010010";
                case 89:
                    return "11011011110";
                case 90:
                    return "11011110110";
                case 91:
                    return "11110110110";
                case 92:
                    return "10101111000";
                case 93:
                    return "10100011110";
                case 94:
                    return "10001011110";
                case 95:
                    return "10111101000";
                case 96:
                    return "10111100010";
                case 97:
                    return "11110101000";
                case 98:
                    return "11110100010";
                case 99:
                    return "10111011110";
                case 100:
                    return "10111101110";
                case 101:
                    return "11101011110";
                case 102:
                    return "11110101110";
                case 103:
                    return "11010000100";
            }
            return null;
        }

        private String partial1(String c)
        {
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            h.Add(" ", "11011001100");
            h.Add("!", "11001101100");
            h.Add("\"", "11001100110");
            h.Add("#", "10010011000");
            h.Add("$", "10010001100");
            h.Add("%", "10001001100");
            h.Add("&", "10011001000");
            h.Add("'", "10011000100");
            h.Add("(", "10001100100");
            h.Add(")", "11001001000");
            h.Add("*", "11001000100");
            h.Add("+", "11000100100");
            h.Add(",", "10110011100");
            h.Add("-", "10011011100");
            h.Add(".", "10011001110");
            h.Add("/", "10111001100");
            h.Add("0", "10011101100");
            h.Add("1", "10011100110");
            h.Add("2", "11001110010");
            h.Add("3", "11001011100");
            h.Add("4", "11001001110");
            h.Add("5", "11011100100");
            h.Add("6", "11001110100");
            h.Add("7", "11101101110");
            h.Add("8", "11101001100");
            h.Add("9", "11100101100");
            h.Add(":", "11100100110");
            h.Add(";", "11101100100");
            h.Add("<", "11100110100");
            h.Add("=", "11100110010");
            h.Add(">", "11011011000");
            h.Add("?", "11011000110");
            h.Add("@", "11000110110");
            h.Add("A", "10100011000");
            h.Add("B", "10001011000");
            h.Add("C", "10001000110");
            h.Add("D", "10110001000");
            h.Add("E", "10001101000");
            h.Add("F", "10001100010");
            h.Add("G", "11010001000");
            h.Add("H", "11000101000");
            h.Add("I", "11000100010");
            h.Add("J", "10110111000");
            h.Add("K", "10110001110");
            h.Add("L", "10001101110");
            h.Add("M", "10111011000");
            h.Add("N", "10111000110");
            h.Add("O", "10001110110");
            h.Add("P", "11101110110");
            h.Add("Q", "11010001110");
            h.Add("R", "11000101110");
            h.Add("S", "11011101000");
            h.Add("T", "11011100010");
            h.Add("U", "11011101110");
            h.Add("V", "11101011000");
            h.Add("W", "11101000110");
            h.Add("X", "11100010110");
            h.Add("Y", "11101101000");
            h.Add("Z", "11101100010");
            h.Add("[", "11100011010");
            h.Add(@"\", "11101111010");
            h.Add("]", "11001000010");
            h.Add("^", "11110001010");
            h.Add("_", "10100110000");
            h.Add("`", "10100001100");
            h.Add("a", "10010110000");
            h.Add("b", "10010000110");
            h.Add("c", "10000101100");
            h.Add("d", "10000100110");
            h.Add("e", "10110010000");
            h.Add("f", "10110000100");
            h.Add("g", "10011010000");
            h.Add("h", "10011000010");
            h.Add("i", "10000110100");
            h.Add("j", "10000110010");
            h.Add("k", "11000010010");
            h.Add("l", "11001010000");
            h.Add("m", "11110111010");
            h.Add("n", "11000010100");
            h.Add("o", "10001111010");
            h.Add("p", "10100111100");
            h.Add("q", "10010111100");
            h.Add("r", "10010011110");
            h.Add("s", "10111100100");
            h.Add("t", "10011110100");
            h.Add("u", "10011110010");
            h.Add("v", "11110100100");
            h.Add("w", "11110010100");
            h.Add("x", "11110010010");
            h.Add("y", "11011011110");
            h.Add("z", "11011110110");
            h.Add("{", "11110110110");
            h.Add("|", "10101111000");
            h.Add("}", "10100011110");
            h.Add("~", "10001011110");

            if (h.ContainsKey(c) == true)
            {
                return h[c].ToString();
            }
            return null;
        }

        private int Checksum1(String c)
        {
            /*
            Please note that this function does NOT support all
            characters in the Code128A dictionary.  
            
            Values 64 thru 105 are NOT supported as they are escape 
            sequences of one type or another.
            */
            String allchars = " !\"";
            allchars += "#$%&'()*+,-./";
            allchars += "0123456789";
            allchars += ":;<=>?@";
            allchars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            allchars += @"[\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

            System.Collections.Hashtable h = new System.Collections.Hashtable();

            for (int i = 0; i < allchars.Length; i++)
            {
                h.Add(System.Convert.ToString(allchars[i]), i.ToString());
            }

            /*
            
            h.Add("-", "13");
            h.Add("/", "15");
            h.Add("0", "16");
            h.Add("1", "17");
            h.Add("2", "18");
            h.Add("3", "19");
            h.Add("4", "20");
            h.Add("5", "21");
            h.Add("6", "22");
            h.Add("7", "23");
            h.Add("8", "24");
            h.Add("9", "25");
            h.Add(":", "26");
            for (int i = 0; i <= 26; i++)
            {
                Char tempchar = System.Convert.ToChar(65 + i);
                h.Add(tempchar.ToString(), i + 33);
            }
           
            // h.Add("A", "33");
            // h.Add("B", "34");
            // h.Add("H", "40");
            // h.Add("I", "41");
            
             */

            int checksum = 104;
            for (int i = 0; i < c.Length; i++)
            {
                int adder = System.Convert.ToInt16(h[c[i].ToString()].ToString());
                adder = adder * (i + 1);
                checksum += adder;
            }

            checksum = checksum % 103;
            return checksum;
        }

        public Bitmap GetBarcodeBitmap(String str)
        {
            // Each character will take up 11 bits in the string
            // Plus, the start, end, four quite zones, and check digit
            // And to top it off, the terminator string is two bits
            if (str.Length > 30)
            {
                throw new ArgumentException("GetBitmap: str length too long");
            }
            if (str.Length < 1)
            {
                throw new ArgumentException("GetBitmap: str length too short");
            }

            int len = ((str.Length + 7) * 11) + 2;
            int height = 20;
//            System.Drawing.Bitmap b = new System.Drawing.Bitmap(len, height);
            String bits = QUIET_ZONE + START;

            for (int qq = 0; qq < str.Length; qq++)
            {
                bits += partial1(str[qq].ToString());
            }

            bits += value2encoding(Checksum1(str)) + STOP + TERMINATE + QUIET_ZONE;

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(bits.Length, height);

            int y = 0;

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
            return ((str.Length + 7) * 11) + 2;
        }

    }

    public class Code128C
    {
        public void NotImplimented()
        {

        }
    }
}
