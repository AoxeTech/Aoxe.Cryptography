namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Extensions
{
    public static byte[] ToSha1(this string str, Encoding? encoding = null) =>
        Sha1Helper.ComputeHash(str, encoding);

    public static string ToSha1String(this string str, Encoding? encoding = null) =>
        Sha1Helper.ComputeHashString(str, encoding);
}
