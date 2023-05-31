namespace Zaabee.Cryptography;

internal class CommonSettings
{
    internal const CipherMode DefaultCipherMode = CipherMode.CBC;
    internal const PaddingMode DefaultPaddingMode = PaddingMode.PKCS7;
    internal static readonly Encoding DefaultEncoding = Encoding.UTF8;
    internal static readonly HashAlgorithmName DefaultHashAlgorithmName = HashAlgorithmName.SHA256;
    internal static readonly RSAEncryptionPadding DefaultRsaEncryptionPadding = RSAEncryptionPadding.OaepSHA256;
    internal static readonly RSASignaturePadding DefaultRsaSignaturePadding = RSASignaturePadding.Pkcs1;
}