namespace Zaabee.Cryptographic;

public static class ShaExtensions
{
    public static string ToSha1String(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha1HashString(str, encoding);

    public static string ToSha1String(this byte[] bytes) =>
        ShaHelper.GetSha1HashString(bytes);

    public static byte[] ToSha1Bytes(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha1HashBytes(str, encoding);

    public static byte[] ToSha1Bytes(this byte[] bytes) =>
        ShaHelper.GetSha1HashBytes(bytes);

    public static string ToSha256String(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha256HashString(str, encoding);

    public static string ToSha256String(this byte[] bytes) =>
        ShaHelper.GetSha256HashString(bytes);

    public static byte[] ToSha256Bytes(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha256HashBytes(str, encoding);

    public static byte[] ToSha256Bytes(this byte[] bytes) =>
        ShaHelper.GetSha256HashBytes(bytes);

    public static string ToSha384String(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha384HashString(str, encoding);

    public static string ToSha384String(this byte[] bytes) =>
        ShaHelper.GetSha384HashString(bytes);

    public static byte[] ToSha384Bytes(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha384HashBytes(str, encoding);

    public static byte[] ToSha384Bytes(this byte[] bytes) =>
        ShaHelper.GetSha384HashBytes(bytes);

    public static string ToSha512String(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha512HashString(str, encoding);

    public static string ToSha512String(this byte[] bytes) =>
        ShaHelper.GetSha512HashString(bytes);

    public static byte[] ToSha512Bytes(this string str, Encoding encoding = null) =>
        ShaHelper.GetSha512HashBytes(str, encoding);

    public static byte[] ToSha512Bytes(this byte[] bytes) =>
        ShaHelper.GetSha512HashBytes(bytes);
}