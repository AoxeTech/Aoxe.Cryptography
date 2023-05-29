namespace Zaabee.Cryptography;

public static partial class HashAlgorithmExtensions
{
    public static string ToHashString(
        this System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        string str,
        Encoding? encoding = null) =>
        BitConverter
            .ToString(hashAlgorithm.ToHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(str)))
            .Replace("-", string.Empty);
}