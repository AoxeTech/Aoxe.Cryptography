using System;
using System.Text;

namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static string GetSha384HashString(
        string str,
        Encoding? encoding = null) =>
        GetSha384HashString((encoding ?? Encoding).GetBytes(str));

    public static string GetSha384HashString(byte[] bytes)
    {
        var hashBytes = GetSha384HashBytes(bytes);
        return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
    }
}