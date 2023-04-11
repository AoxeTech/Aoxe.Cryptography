namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static string ToSha512(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.ComputeSha512(str, encoding);
}