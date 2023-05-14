namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha512(
        string str,
        Encoding? encoding = null)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return sha512.ToHashString(str, encoding);
    }
}