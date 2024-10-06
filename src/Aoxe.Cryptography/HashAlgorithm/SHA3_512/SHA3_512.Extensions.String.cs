#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Extensions
{
    public static byte[] ToSha3_512(this string str, Encoding? encoding = null) =>
        Sha3_512Helper.ComputeHash(str, encoding);

    public static string ToSha3_512String(this string str, Encoding? encoding = null) =>
        Sha3_512Helper.ComputeHashString(str, encoding);
}
#endif
