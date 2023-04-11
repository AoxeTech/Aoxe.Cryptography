namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static byte[] GetSha384HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha384HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha384HashBytes(byte[] bytes)
    {
#if NETSTANDARD2_0
        using var sha384 = SHA384.Create();
        return sha384.ComputeHash(bytes);
#else
        return SHA384.HashData(bytes);
#endif
    }
}