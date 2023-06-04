namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha1(
        string str,
        Encoding? encoding = null)
    {
        using var sha1 = SHA1.Create();
        return str.ToHashString(sha1, encoding);
    }
}