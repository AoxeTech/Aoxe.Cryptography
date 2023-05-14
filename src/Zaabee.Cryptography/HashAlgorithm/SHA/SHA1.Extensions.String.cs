namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static string ToSha1(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.ComputeSha1(str, encoding);
}