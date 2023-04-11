namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha256(byte[] bytes)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return sha256.ToHash(bytes);
    }

    public static byte[] ComputeSha256(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return sha256.ToHash(bytes, offset, count);
    }
}