namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha512String(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha512HashString(str, encoding);

    public static string ToSha512String(this byte[] bytes) =>
        ShaHelper.GetSha512HashString(bytes);
}