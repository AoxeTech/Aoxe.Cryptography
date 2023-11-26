namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Extensions
{
    public static byte[] ToSha1(this Stream inputStream) => Sha1Helper.ComputeHash(inputStream);

    public static string ToSha1String(this Stream inputStream) =>
        Sha1Helper.ComputeHashString(inputStream);
}
