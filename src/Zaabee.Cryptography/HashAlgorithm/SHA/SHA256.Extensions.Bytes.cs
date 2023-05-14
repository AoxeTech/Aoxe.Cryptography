namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha256(this byte[] bytes) =>
        ShaHelper.ComputeSha256(bytes);

    public static byte[] ToSha256(
        this byte[] bytes,
        int offset,
        int count) =>
        ShaHelper.ComputeSha256(bytes, offset, count);
}