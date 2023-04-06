namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha512String(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha512HashString(str, encoding);

    public static string ToSha512String(this byte[] bytes) =>
        ShaHelper.GetSha512HashString(bytes);

    public static byte[] ToSha512Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha512HashBytes(str, encoding);

    public static byte[] ToSha512Bytes(this byte[] bytes) =>
        ShaHelper.GetSha512HashBytes(bytes);
}