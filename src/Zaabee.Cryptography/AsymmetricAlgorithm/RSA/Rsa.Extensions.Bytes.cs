namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaExtensions
{
    public static byte[] EncryptByRsa(
        this byte[] data,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Encrypt(data, publicKey, rsaEncryptionPadding);

    public static byte[] DecryptByRsa(
        this byte[] data,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Decrypt(data, privateKey, rsaEncryptionPadding);

    public static byte[] SignDataByRsa(
        this byte[] data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignData(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyDataByRsa(
        this byte[] data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyData(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

    public static byte[] SignHashByRsa(
        this byte[] data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignHash(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyHashByRsa(
        this byte[] data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyHash(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

#if !NETSTANDARD2_0
    public static byte[] EncryptByRsa(
        this byte[] data,
        byte[] publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Encrypt(data, publicKey, rsaEncryptionPadding);

    public static byte[] DecryptByRsa(
        this byte[] data,
        byte[] privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Decrypt(data, privateKey, rsaEncryptionPadding);

    public static byte[] SignDataByRsa(
        this byte[] data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignData(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyDataByRsa(
        this byte[] data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyData(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

    public static byte[] SignHashByRsa(
        this byte[] data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignHash(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyHashByRsa(
        this byte[] data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyHash(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);
#endif
}