namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha256String(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha256HashString(str, encoding);

    public static string ToSha256String(this byte[] bytes) =>
        ShaHelper.GetSha256HashString(bytes);

    public static byte[] ToSha256Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha256HashBytes(str, encoding);

    public static byte[] ToSha256Bytes(this byte[] bytes) =>
        ShaHelper.GetSha256HashBytes(bytes);
}