namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha512(Stream inputStream)
    {
        using var sha512 = SHA512.Create();
        return inputStream.ToHash(sha512);
    }
}