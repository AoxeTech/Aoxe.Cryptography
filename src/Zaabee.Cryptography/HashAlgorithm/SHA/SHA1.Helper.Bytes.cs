namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha1(byte[] bytes)
    {
        using var sha1 = SHA1.Create();
        return bytes.ToHash(sha1);
    }

    public static byte[] ComputeSha1(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha1 = SHA1.Create();
        return bytes.ToHash(sha1, offset, count);
    }
}