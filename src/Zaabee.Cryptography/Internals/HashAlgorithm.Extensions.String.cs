namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
    internal static byte[] ToHash(
        this string str,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        Encoding? encoding = null
    ) => str.GetBytes(encoding ?? CommonSettings.DefaultEncoding).ToHash(hashAlgorithm);

    internal static string ToHashString(
        this string str,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        Encoding? encoding = null
    ) =>
        str.GetBytes(encoding ?? CommonSettings.DefaultEncoding)
            .ToHash(hashAlgorithm)
            .ToHexString();
}
