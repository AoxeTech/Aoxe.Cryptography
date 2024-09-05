#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Extensions
{
    public static byte[] ToSha3_256(this string str, Encoding? encoding = null) =>
        Sha3_256Helper.ComputeHash(str, encoding);

    public static string ToSha3_256String(this string str, Encoding? encoding = null) =>
        Sha3_256Helper.ComputeHashString(str, encoding);
}
#endif
