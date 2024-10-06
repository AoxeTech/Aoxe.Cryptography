# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Extensions
{
    public static byte[] ToShake256(this Stream inputStream, int outputLength) =>
        Shake256Helper.ComputeHash(inputStream, outputLength);

    public static string ToShake256String(this Stream inputStream, int outputLength) =>
        Shake256Helper.ComputeHashString(inputStream, outputLength);

    public static void ToShake256(this Stream inputStream, Span<byte> destination) =>
        Shake256Helper.ComputeHash(inputStream, destination);
}
# endif
