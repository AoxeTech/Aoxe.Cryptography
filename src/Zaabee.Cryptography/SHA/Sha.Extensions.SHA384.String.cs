namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha384(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.ComputeSha384(str, encoding);
}