namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
    internal static byte[] ToHash(
        this Stream inputStream,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm)
    {
        var hashBytes = hashAlgorithm.ComputeHash(inputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return hashBytes;
    }

    internal static string ToHashString(
        this Stream inputStream,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm)
    {
        var hashString = hashAlgorithm.ComputeHash(inputStream).ToHexString();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return hashString;
    }
}