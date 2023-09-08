namespace Zaabee.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Extensions
{
    public static byte[] ToSha384(
        this string str,
        Encoding? encoding = null) =>
        Sha384Helper.ComputeHash(str, encoding);

    public static string ToSha384String(
        this string str,
        Encoding? encoding = null) =>
        Sha384Helper.ComputeHashString(str, encoding);
}