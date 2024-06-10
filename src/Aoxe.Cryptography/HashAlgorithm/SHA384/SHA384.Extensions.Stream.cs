namespace Aoxe.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Extensions
{
    public static byte[] ToSha384(this Stream inputStream) => Sha384Helper.ComputeHash(inputStream);

    public static string ToSha384String(this Stream inputStream) =>
        Sha384Helper.ComputeHashString(inputStream);
}
