namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
    internal static string ToHashString(
        this string str,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        Encoding? encoding = null,
        bool isLowerCase = false,
        bool withoutDash = false)
    {
        var hash = (encoding ?? CommonSettings.DefaultEncoding).GetBytes(str).ToHash(hashAlgorithm);
        var result = BitConverter.ToString(hash);
        if (isLowerCase) result = result.ToLowerInvariant();
        if (withoutDash) result = result.Replace("-", string.Empty);
        return result;
    }
}