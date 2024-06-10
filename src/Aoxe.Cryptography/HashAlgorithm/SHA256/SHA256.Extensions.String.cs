namespace Aoxe.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Extensions
{
    public static byte[] ToSha256(this string str, Encoding? encoding = null) =>
        Sha256Helper.ComputeHash(str, encoding);

    public static string ToSha256String(this string str, Encoding? encoding = null) =>
        Sha256Helper.ComputeHashString(str, encoding);
}
