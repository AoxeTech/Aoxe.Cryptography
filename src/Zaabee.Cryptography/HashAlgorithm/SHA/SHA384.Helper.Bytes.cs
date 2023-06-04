namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha384(byte[] bytes)
    {
        using var sha384 = SHA384.Create();
        return bytes.ToHash(sha384);
    }

    public static byte[] ComputeSha384(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha384 = SHA384.Create();
        return bytes.ToHash(sha384, offset, count);
    }
}