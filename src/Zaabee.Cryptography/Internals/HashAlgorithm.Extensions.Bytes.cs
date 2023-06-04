namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
    internal static byte[] ToHash(
        this byte[] buffer,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm) =>
        hashAlgorithm.ComputeHash(buffer);

    internal static byte[] ToHash(
        this byte[] buffer,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        int offset,
        int count) =>
        hashAlgorithm.ComputeHash(buffer, offset, count);
}