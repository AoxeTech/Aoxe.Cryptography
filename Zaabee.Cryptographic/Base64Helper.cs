using System;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class Base64Helper
    {
        public static string ToBase64(this string str, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return Convert.ToBase64String(encoding.GetBytes(str));
        }

        public static string FromBase64(this string str, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetString(Convert.FromBase64String(str));
        }

        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}