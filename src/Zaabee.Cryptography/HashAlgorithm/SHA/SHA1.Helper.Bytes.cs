namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha1(byte[] bytes)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return sha1.ToHash(bytes);
    }

    public static byte[] ComputeSha1(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return sha1.ToHash(bytes, offset, count);
    }
}