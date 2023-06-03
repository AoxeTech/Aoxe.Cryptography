namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaHelper
{
#if NET7_0_OR_GREATER
    public static byte[] Encrypt(
        ReadOnlySpan<byte> data,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(publicKey);
        return rsa.Encrypt(data, rsaEncryptionPadding ?? CommonSettings.DefaultRsaEncryptionPadding);
    }

    public static byte[] Decrypt(
        ReadOnlySpan<byte> data,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.Decrypt(data, rsaEncryptionPadding ?? CommonSettings.DefaultRsaEncryptionPadding);
    }

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

    public static byte[] Encrypt(
        ReadOnlySpan<byte> data,
        byte[] publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPublicKey(publicKey, out _);
        return rsa.Encrypt(data, rsaEncryptionPadding ?? CommonSettings.DefaultRsaEncryptionPadding);
    }

    public static byte[] Decrypt(
        ReadOnlySpan<byte> data,
        byte[] privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPrivateKey(privateKey, out _);
        return rsa.Decrypt(data, rsaEncryptionPadding ?? CommonSettings.DefaultRsaEncryptionPadding);
    }

    public static byte[] SignData(
        ReadOnlySpan<byte> data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPrivateKey(privateKey, out _);
        return rsa.SignData(data, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }

    public static bool VerifyData(
        ReadOnlySpan<byte> data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPublicKey(publicKey, out _);
        return rsa.VerifyData(data, signature, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }

    public static byte[] SignHash(
        ReadOnlySpan<byte> data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPrivateKey(privateKey, out _);
        return rsa.SignHash(data, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }

    public static bool VerifyHash(
        ReadOnlySpan<byte> data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPublicKey(publicKey, out _);
        return rsa.VerifyHash(data, signature, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName,
            rsaEncryptionPadding ?? CommonSettings.DefaultRsaSignaturePadding);
    }
#endif
}