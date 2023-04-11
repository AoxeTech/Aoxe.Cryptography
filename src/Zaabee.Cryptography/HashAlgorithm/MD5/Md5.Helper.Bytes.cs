namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
    public static byte[] ComputeMd5(byte[] bytes)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return md5.ToHash(bytes);
    }

    public static byte[] ComputeMd5(
        byte[] bytes,
        int offset,
        int count)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return md5.ToHash(bytes, offset, count);
    }
}