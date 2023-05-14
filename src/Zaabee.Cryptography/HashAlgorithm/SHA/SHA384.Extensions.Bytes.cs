namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha384(this byte[] bytes) =>
        ShaHelper.ComputeSha384(bytes);

    public static byte[] ToSha384(
        this byte[] bytes,
        int offset,
        int count) =>
        ShaHelper.ComputeSha384(bytes, offset, count);
}