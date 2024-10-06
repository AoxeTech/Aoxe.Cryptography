# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Extensions
{
    public static byte[] ToShake256(this ReadOnlySpan<byte> bytes, int outputLength) =>
        Shake256Helper.ComputeHash(bytes, outputLength);

    public static string ToShake256String(this ReadOnlySpan<byte> bytes, int outputLength) =>
        Shake256Helper.ComputeHashString(bytes, outputLength);

    public static void ToShake256(this ReadOnlySpan<byte> bytes, Span<byte> destination) =>
        Shake256Helper.ComputeHash(bytes, destination);
}
# endif
