namespace Zaabee.Cryptography.Internals;

internal static class CommonSettings
{
    internal const CipherMode DefaultCipherMode = CipherMode.CBC;
    internal const PaddingMode DefaultPaddingMode = PaddingMode.PKCS7;
    internal static readonly Encoding DefaultEncoding = Encoding.UTF8;
    internal static readonly HashAlgorithmName DefaultHashAlgorithmName = HashAlgorithmName.SHA256;
    internal static readonly RSAEncryptionPadding DefaultRsaEncryptionPadding = RSAEncryptionPadding.Pkcs1;
    internal static readonly RSASignaturePadding DefaultRsaSignaturePadding = RSASignaturePadding.Pkcs1;
}