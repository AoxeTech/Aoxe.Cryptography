namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha512(this byte[] bytes) =>
        ShaHelper.ComputeSha512(bytes);

    public static byte[] ToSha512(
        this byte[] bytes,
        int offset,
        int count) =>
        ShaHelper.ComputeSha512(bytes, offset, count);
}