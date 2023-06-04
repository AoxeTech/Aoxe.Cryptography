namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha384(
        string str,
        Encoding? encoding = null)
    {
        using var sha384 = SHA384.Create();
        return str.ToHashString(sha384, encoding);
    }
}