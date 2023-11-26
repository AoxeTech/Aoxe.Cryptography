namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return str.ToHash(md5, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return str.ToHash(md5, encoding).ToHexString();
    }
}
