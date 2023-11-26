namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return str.ToHash(sha1, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return str.ToHashString(sha1, encoding);
    }
}
