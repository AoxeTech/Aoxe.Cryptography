namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static string ComputeSha256(
        string str,
        Encoding? encoding = null)
    {
        using var sha256 = SHA256.Create();
        return sha256.ToHashString(str, encoding);
    }
}