namespace Zaabee.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return str.ToHash(sha256, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return str.ToHashString(sha256, encoding);
    }
}
