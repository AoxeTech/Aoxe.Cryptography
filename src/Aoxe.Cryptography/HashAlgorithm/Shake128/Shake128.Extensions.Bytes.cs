# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Extensions
{
    public static byte[] ToShake128(this byte[] bytes, int outputLength) =>
        Shake128Helper.ComputeHash(bytes, outputLength);

    public static string ToShake128String(this byte[] bytes, int outputLength) =>
        Shake128Helper.ComputeHashString(bytes, outputLength);
}
# endif
