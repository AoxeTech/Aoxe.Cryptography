namespace Zaabee.Cryptography.MD5;

public static partial class Md5Helper
{
    public static string GetMd5String(byte[] bytes)
    {
        var hashBytes = GetMd5Bytes(bytes);
        return BitConverter.ToString(hashBytes).Replace("-",string.Empty);
    }

    public static byte[] GetMd5Bytes(byte[] bytes)
    {
#if NETSTANDARD2_0
        using var md5 = System.Security.Cryptography.MD5.Create();
        return md5.ComputeHash(bytes);
#else
        return System.Security.Cryptography.MD5.HashData(bytes);
#endif
    }
}