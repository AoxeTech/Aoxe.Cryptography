# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Extensions
{
    public static byte[] ToShake128(this ReadOnlySpan<byte> bytes, int outputLength) =>
        Shake128Helper.ComputeHash(bytes, outputLength);

    public static string ToShake128String(this ReadOnlySpan<byte> bytes, int outputLength) =>
        Shake128Helper.ComputeHashString(bytes, outputLength);

    public static void ToShake128(this ReadOnlySpan<byte> bytes, Span<byte> destination) =>
        Shake128Helper.ComputeHash(bytes, destination);
}
# endif
