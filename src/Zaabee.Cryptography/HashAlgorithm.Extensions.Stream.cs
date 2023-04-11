namespace Zaabee.Cryptography;

public static partial class HashAlgorithmExtensions
{
    public static byte[] ToHash(
        this HashAlgorithm hashAlgorithm,
        Stream inputStream) =>
        hashAlgorithm.ComputeHash(inputStream);
}