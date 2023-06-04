namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
    internal static byte[] ToHash(
        this Stream inputStream,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm) =>
        hashAlgorithm.ComputeHash(inputStream);
}