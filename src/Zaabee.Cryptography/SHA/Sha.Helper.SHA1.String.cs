using System;
using System.Text;

namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static string GetSha1HashString(
        string str,
        Encoding? encoding = null) =>
        GetSha1HashString((encoding ?? Encoding).GetBytes(str));

    public static string GetSha1HashString(byte[] bytes)
    {
        var hashBytes = GetSha1HashBytes(bytes);
        return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
    }
}