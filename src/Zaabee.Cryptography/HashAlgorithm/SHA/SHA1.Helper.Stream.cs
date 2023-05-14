namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha1(Stream inputStream)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return sha1.ToHash(inputStream);
    }
}