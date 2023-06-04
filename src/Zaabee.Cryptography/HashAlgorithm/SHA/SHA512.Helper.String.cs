namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha512(
        string str,
        Encoding? encoding = null)
    {
        using var sha512 = SHA512.Create();
        return str.ToHashString(sha512, encoding);
    }
}