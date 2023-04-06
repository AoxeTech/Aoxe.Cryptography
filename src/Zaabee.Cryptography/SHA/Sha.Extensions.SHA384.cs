namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha384String(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha384HashString(str, encoding);

    public static string ToSha384String(this byte[] bytes) =>
        ShaHelper.GetSha384HashString(bytes);

    public static byte[] ToSha384Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha384HashBytes(str, encoding);

    public static byte[] ToSha384Bytes(this byte[] bytes) =>
        ShaHelper.GetSha384HashBytes(bytes);
}