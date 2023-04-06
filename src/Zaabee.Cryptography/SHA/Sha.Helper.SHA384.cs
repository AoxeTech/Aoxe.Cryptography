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
        return BitConverter.ToString(hashBytes).Replace("-",string.Empty);
    }

    public static byte[] GetSha384HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha384HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha384HashBytes(byte[] bytes)
    {
#if NET48
        using var sha384 = SHA384.Create();
        return sha384.ComputeHash(bytes);
#else
        return SHA384.HashData(bytes);
#endif
    }
}