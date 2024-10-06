#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Extensions
{
    public static byte[] ToSha3_384(this string str, Encoding? encoding = null) =>
        Sha3_384Helper.ComputeHash(str, encoding);

    public static string ToSha3_384String(this string str, Encoding? encoding = null) =>
        Sha3_384Helper.ComputeHashString(str, encoding);
}
#endif
