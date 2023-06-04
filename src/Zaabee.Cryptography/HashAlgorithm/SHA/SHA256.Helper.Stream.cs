namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha256(Stream inputStream)
    {
        using var sha256 = SHA256.Create();
        return inputStream.ToHash(sha256);
    }
}