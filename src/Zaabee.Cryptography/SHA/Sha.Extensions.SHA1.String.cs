namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha1String(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha1HashString(str, encoding);

    public static string ToSha1String(this byte[] bytes) =>
        ShaHelper.GetSha1HashString(bytes);
}