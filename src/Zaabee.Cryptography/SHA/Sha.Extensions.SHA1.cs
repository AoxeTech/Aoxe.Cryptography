namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha1String(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha1HashString(str, encoding);

    public static string ToSha1String(this byte[] bytes) =>
        ShaHelper.GetSha1HashString(bytes);

    public static byte[] ToSha1Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha1HashBytes(str, encoding);

    public static byte[] ToSha1Bytes(this byte[] bytes) =>
        ShaHelper.GetSha1HashBytes(bytes);
}