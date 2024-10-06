# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Extensions
{
    public static byte[] ToShake256(this string str, int outputLength) =>
        Shake256Helper.ComputeHash(str, outputLength);

    public static string ToShake256String(this string str, int outputLength) =>
        Shake256Helper.ComputeHashString(str, outputLength);

    public static void ToShake256(this string str, Span<byte> destination) =>
        Shake256Helper.ComputeHash(str, destination);
}
# endif
