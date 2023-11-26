namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Extensions
{
    public static byte[] ToSha512(this string str, Encoding? encoding = null) =>
        Sha512Helper.ComputeHash(str, encoding);

    public static string ToSha512String(this string str, Encoding? encoding = null) =>
        Sha512Helper.ComputeHashString(str, encoding);
}
