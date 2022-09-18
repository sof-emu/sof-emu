using System;
using System.Security.Cryptography;

namespace Utility
{
    public static class Rng
    {
        private static RNGCryptoServiceProvider rngcryptoServiceProvider_0 = new RNGCryptoServiceProvider();

        private static byte[] rb = new byte[4];

        public static int Next()
        {
            rngcryptoServiceProvider_0.GetBytes(rb);
            int num = BitConverter.ToInt32(rb, 0);
            if (num < 0)
            {
                num = -num;
            }
            return num;
        }

        public static int Next(int val)
        {
            rngcryptoServiceProvider_0.GetBytes(rb);
            int num = BitConverter.ToInt32(rb, 0) % (val + 1);
            if (num < 0)
            {
                num = -num;
            }
            return num;
        }

        public static int Next(int val1, int val2)
        {
            return Next(val2 - val1) + val1;
        }
    }
}
