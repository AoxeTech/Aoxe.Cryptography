namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Extensions
{
    public static byte[] ToSha512(this Stream inputStream) =>
        Sha512Helper.ComputeHash(inputStream);

    public static string ToSha512String(this Stream inputStream) =>
        Sha512Helper.ComputeHashString(inputStream);
}