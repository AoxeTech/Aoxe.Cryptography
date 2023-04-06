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
        return BitConverter.ToString(hashBytes);
    }

    public static byte[] GetSha1HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha1HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha1HashBytes(byte[] bytes)
    {
#if NET48
        using var sha1 = SHA1.Create();
        return sha1.ComputeHash(bytes);
#else
        return SHA1.HashData(bytes);
#endif
    }
}