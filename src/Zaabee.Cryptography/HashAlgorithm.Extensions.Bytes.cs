namespace Zaabee.Cryptography;

public static partial class HashAlgorithmExtensions
{
    public static byte[] ToHash(
        this System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        byte[] buffer) =>
        hashAlgorithm.ComputeHash(buffer);

    public static byte[] ToHash(
        this System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        byte[] buffer,
        int offset,
        int count) =>
        hashAlgorithm.ComputeHash(buffer, offset, count);
}