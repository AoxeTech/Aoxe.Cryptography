namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaExtensions
{
    public static byte[] EncryptByRsa(
        this string data,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Encrypt(data, publicKey, rsaEncryptionPadding);

    public static byte[] DecryptByRsa(
        this string data,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Decrypt(data, privateKey, rsaEncryptionPadding);

    public static byte[] SignData(
        this string data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignData(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyData(
        this string data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyData(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

    public static byte[] SignHash(
        this string data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignHash(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyHash(
        this string data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyHash(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

#if !NETSTANDARD2_0
    public static byte[] EncryptByRsa(
        this string data,
        byte[] publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Encrypt(data, publicKey, rsaEncryptionPadding);

    public static byte[] DecryptByRsa(
        this string data,
        byte[] privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Decrypt(data, privateKey, rsaEncryptionPadding);

    public static byte[] SignData(
        this string data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignData(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyData(
        this string data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyData(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

    public static byte[] SignHash(
        this string data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignHash(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyHash(
        this string data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyHash(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);
#endif
}