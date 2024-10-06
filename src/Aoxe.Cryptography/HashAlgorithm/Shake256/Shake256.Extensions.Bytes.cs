# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Extensions
{
    public static byte[] ToShake256(this byte[] bytes, int outputLength) =>
        Shake256Helper.ComputeHash(bytes, outputLength);

    public static string ToShake256String(this byte[] bytes, int outputLength) =>
        Shake256Helper.ComputeHashString(bytes, outputLength);
}
# endif
