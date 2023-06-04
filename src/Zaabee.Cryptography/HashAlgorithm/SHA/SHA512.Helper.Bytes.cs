namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha512(byte[] bytes)
    {
        using var sha512 = SHA512.Create();
        return bytes.ToHash(sha512);
    }

    public static byte[] ComputeSha512(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha512 = SHA512.Create();
        return bytes.ToHash(sha512, offset, count);
    }
}