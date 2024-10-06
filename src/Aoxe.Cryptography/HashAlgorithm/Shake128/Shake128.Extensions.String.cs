# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Extensions
{
    public static byte[] ToShake128(this string str, int outputLength) =>
        Shake128Helper.ComputeHash(str, outputLength);

    public static string ToShake128String(this string str, int outputLength) =>
        Shake128Helper.ComputeHashString(str, outputLength);

    public static void ToShake128(this string str, Span<byte> destination) =>
        Shake128Helper.ComputeHash(str, destination);
}
# endif
