namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha256(byte[] bytes)
    {
        using var sha256 = SHA256.Create();
        return bytes.ToHash(sha256);
    }

    public static byte[] ComputeSha256(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha256 = SHA256.Create();
        return bytes.ToHash(sha256, offset, count);
    }
}