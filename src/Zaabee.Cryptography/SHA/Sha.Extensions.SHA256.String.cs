namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha256(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.ComputeSha256(str, encoding);
}