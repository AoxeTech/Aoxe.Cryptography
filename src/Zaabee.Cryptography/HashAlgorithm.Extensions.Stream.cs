namespace Zaabee.Cryptography;

public static partial class HashAlgorithmExtensions
{
    public static byte[] ToHash(
        this System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        Stream inputStream) =>
        hashAlgorithm.ComputeHash(inputStream);
}