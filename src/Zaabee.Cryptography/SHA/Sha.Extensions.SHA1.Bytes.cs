namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha1Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha1HashBytes(str, encoding);

    public static byte[] ToSha1Bytes(this byte[] bytes) =>
        ShaHelper.GetSha1HashBytes(bytes);
}