using System;
using System.Text;

namespace Cheapy_API.Services
{
    public static class Crypt
    {
        public static string Encrypt(string plainText)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            string hexString = Convert.ToHexString(bytes);

            return hexString;
        }

        public static string Decrypt(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}