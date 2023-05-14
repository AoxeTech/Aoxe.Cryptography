namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha1(
        string str,
        Encoding? encoding = null)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return sha1.ToHashString(str, encoding);
    }
}