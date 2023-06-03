namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaHelper
{
#if !NETSTANDARD2_0 && !NET6_0
    public static byte[] SignData(
        ReadOnlySpan<byte> data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.SignData(data, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }

    public static bool VerifyData(
        ReadOnlySpan<byte> data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(publicKey);
        return rsa.VerifyData(data, signature, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }

    public static byte[] SignHash(
        ReadOnlySpan<byte> data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.SignHash(data, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }

    public static bool VerifyHash(
        ReadOnlySpan<byte> data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(publicKey);
        return rsa.VerifyHash(data, signature, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }
#endif
}