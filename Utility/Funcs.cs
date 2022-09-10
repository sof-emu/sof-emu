using System;
using System.Globalization;
using System.Text;

namespace Utility
{
    public static class Funcs
    {
        private static readonly DateTime StaticDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static readonly string[] Baths;

        private static byte[] PwdCryptKeys = new byte[12]
                {
                    170, 171, 172, 173, 174, 175, 186, 187, 188, 189,
                    190, 191
                };

        private static readonly Random Randomizer = new Random((int)DateTime.Now.Ticks);

        static Funcs()
        {
            Baths = new string[256];
            for (int i = 0; i < 256; i++)
                Baths[i] = String.Format("{0:X2}", i);
        }

        

        public static Random Random()
        {
            return Randomizer;
        }

        public static byte[] NextBytes(int len)
        {
            byte[] rand = new byte[len];
            Random().NextBytes(rand);
            return rand;
        }

        public static long GetCurrentMilliseconds()
        {
            return (long)(DateTime.UtcNow - StaticDate).TotalMilliseconds;
        }

        public static int GetRoundedLocal()
        {
            return (int)Math.Round((double)(GetCurrentMilliseconds() / 1000));
        }

        public static string ToHex(this byte[] array)
        {
            StringBuilder builder = new StringBuilder(array.Length * 2);

            for (int i = 0; i < array.Length; i++)
                builder.Append(Baths[array[i]]);

            return builder.ToString();
        }

        public static string FormatHex(this byte[] data)
        {
            StringBuilder builder = new StringBuilder(data.Length * 4);

            int count = 0;
            int pass = 1;
            foreach (byte b in data)
            {
                if (count == 0)
                    builder.AppendFormat("{0,-6}\t", "[" + (pass - 1) * 16 + "]");

                count++;
                builder.Append(b.ToString("X2"));
                if (count == 4 || count == 8 || count == 12)
                    builder.Append(" ");
                if (count == 16)
                {
                    builder.Append("\t");
                    for (int i = (pass * count) - 16; i < (pass * count); i++)
                    {
                        char c = (char)data[i];
                        if (c > 0x1f && c < 0x80)
                            builder.Append(c);
                        else
                            builder.Append(".");
                    }
                    builder.Append("\r\n");
                    count = 0;
                    pass++;
                }
            }

            return builder.ToString();
        }

        public static byte[] ToBytes(this String hexString)
        {
            try
            {
                byte[] result = new byte[hexString.Length / 2];

                for (int index = 0; index < result.Length; index++)
                {
                    string byteValue = hexString.Substring(index * 2, 2);
                    result[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }

                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid hex string: {0}", hexString);
                throw;
            }
        }

        public static string DecryptPassword(this string encpwd)
        {
            int keyIndex = Convert.ToInt32(encpwd.Remove(2, encpwd.Length - 2), 16);
            int cryptKey = PwdCryptKeys[keyIndex];
            byte[] pwdBytes = encpwd.ToBytes();
            for (int i = 0; i < pwdBytes.Length; i++)
            {
                pwdBytes[i] ^= (byte)cryptKey;
            }
            string decPwd = pwdBytes
                .ToHex()
                .ToLower();

            return decPwd.Substring(2, decPwd.Length - 4);
        }
    }
}
