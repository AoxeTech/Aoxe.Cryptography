namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha384(byte[] bytes)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return sha384.ToHash(bytes);
    }

    public static byte[] ComputeSha384(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return sha384.ToHash(bytes, offset, count);
    }
}