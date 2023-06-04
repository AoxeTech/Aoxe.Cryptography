namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha1(Stream inputStream)
    {
        using var sha1 = SHA1.Create();
        return inputStream.ToHash(sha1);
    }
}