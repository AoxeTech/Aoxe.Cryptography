namespace Zaabee.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Extensions
{
    public static byte[] ToSha256(this Stream inputStream) =>
        Sha256Helper.ComputeHash(inputStream);

    public static string ToSha256String(this Stream inputStream) =>
        Sha256Helper.ComputeHashString(inputStream);
}