namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha384(
        string str,
        Encoding? encoding = null)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return sha384.ToHashString(str, encoding);
    }
}