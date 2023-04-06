namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static string GetSha512HashString(
        string str,
        Encoding? encoding = null) =>
        GetSha512HashString((encoding ?? Encoding).GetBytes(str));

    public static string GetSha512HashString(byte[] bytes)
    {
        var hashBytes = GetSha512HashBytes(bytes);
        return BitConverter.ToString(hashBytes);
    }

    public static byte[] GetSha512HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha512HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha512HashBytes(byte[] bytes)
    {
#if NET48
        using var sha512 = SHA512.Create();
        return sha512.ComputeHash(bytes);
#else
        return SHA512.HashData(bytes);
#endif
    }
}