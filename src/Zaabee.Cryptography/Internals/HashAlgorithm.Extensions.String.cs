namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
    internal static string ToHashString(
        this string str,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        Encoding? encoding = null) =>
        BitConverter
            .ToString((encoding ?? CommonSettings.DefaultEncoding).GetBytes(str).ToHash(hashAlgorithm))
            .Replace("-", string.Empty);
}