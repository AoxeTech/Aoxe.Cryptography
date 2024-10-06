# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Extensions
{
    public static byte[] ToShake128(this Stream inputStream, int outputLength) =>
        Shake128Helper.ComputeHash(inputStream, outputLength);

    public static string ToShake128String(this Stream inputStream, int outputLength) =>
        Shake128Helper.ComputeHashString(inputStream, outputLength);

    public static void ToShake128(this Stream inputStream, Span<byte> destination) =>
        Shake128Helper.ComputeHash(inputStream, destination);
}
# endif
