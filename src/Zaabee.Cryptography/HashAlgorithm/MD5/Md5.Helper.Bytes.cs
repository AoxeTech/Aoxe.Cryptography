namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return bytes.ToHash(md5);
    }

    public static byte[] ComputeHash(
        byte[] bytes,
        int offset,
        int count)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return bytes.ToHash(md5, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return bytes.ToHashString(md5);
    }

    public static string ComputeHashString(
        byte[] bytes,
        int offset,
        int count)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return bytes.ToHashString(md5, offset, count);
    }
}