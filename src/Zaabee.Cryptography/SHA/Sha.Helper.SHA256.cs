namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static string GetSha256HashString(
        string str,
        Encoding? encoding = null) =>
        GetSha256HashString((encoding ?? Encoding).GetBytes(str));

    public static string GetSha256HashString(byte[] bytes)
    {
        var hashBytes = GetSha256HashBytes(bytes);
        return BitConverter.ToString(hashBytes).Replace("-",string.Empty);
    }

    public static byte[] GetSha256HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha256HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha256HashBytes(byte[] bytes)
    {
#if NET48
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(bytes);
#else
        return SHA256.HashData(bytes);
#endif
    }
}