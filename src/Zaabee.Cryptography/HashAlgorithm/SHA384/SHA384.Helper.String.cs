namespace Zaabee.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return str.ToHash(sha384, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return str.ToHashString(sha384, encoding);
    }
}
