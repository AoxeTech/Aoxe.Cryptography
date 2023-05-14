namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha1(this byte[] bytes) =>
        ShaHelper.ComputeSha1(bytes);

    public static byte[] ToSha1(
        this byte[] bytes,
        int offset,
        int count) =>
        ShaHelper.ComputeSha1(bytes, offset, count);
}