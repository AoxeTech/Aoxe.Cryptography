using System;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class Base64Helper
    {
        public static string ToBase64(this string str, Encoding encoding = null) =>
            encoding is null
                ? Convert.ToBase64String(Encoding.UTF8.GetBytes(str))
                : Convert.ToBase64String(encoding.GetBytes(str));

        public static string FromBase64(this string str, Encoding encoding = null) =>
            encoding is null
                ? Encoding.UTF8.GetString(Convert.FromBase64String(str))
                : encoding.GetString(Convert.FromBase64String(str));

        public static string ToBase64(this byte[] bytes) => Convert.ToBase64String(bytes);

        public static string FromBase64(this byte[] bytes, Encoding encoding = null) =>
            encoding is null
                ? Encoding.UTF8.GetString(bytes)
                : encoding.GetString(bytes);
    }
}