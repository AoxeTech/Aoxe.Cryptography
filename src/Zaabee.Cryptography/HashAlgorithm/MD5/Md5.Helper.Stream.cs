namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return inputStream.ToHash(md5);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return inputStream.ToHashString(md5);
    }
}
