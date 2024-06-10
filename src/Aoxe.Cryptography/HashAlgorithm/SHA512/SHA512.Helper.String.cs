namespace Aoxe.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return str.ToHash(sha512, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return str.ToHashString(sha512, encoding);
    }
}
