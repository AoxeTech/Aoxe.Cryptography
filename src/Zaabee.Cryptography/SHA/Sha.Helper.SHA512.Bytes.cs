namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha512(byte[] bytes)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return sha512.ToHash(bytes);
    }

    public static byte[] ComputeSha512(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return sha512.ToHash(bytes, offset, count);
    }
}