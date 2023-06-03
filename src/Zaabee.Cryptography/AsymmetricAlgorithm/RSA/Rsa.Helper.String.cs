namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaHelper
{
    public static byte[] Encrypt(
        string data,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        Encrypt((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), publicKey, rsaEncryptionPadding);

    public static byte[] Decrypt(
        string data,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        Decrypt((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, rsaEncryptionPadding);

    public static byte[] SignData(
        string data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        SignData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, hashAlgorithmName,
            rsaEncryptionPadding);

    public static bool VerifyData(
        string data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        VerifyData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), signature, publicKey, hashAlgorithmName,
            rsaEncryptionPadding);

    public static byte[] SignHash(
        string data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        SignHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, hashAlgorithmName,
            rsaEncryptionPadding);

    public static bool VerifyHash(
        string data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        VerifyHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), signature, publicKey, hashAlgorithmName,
            rsaEncryptionPadding);

#if !NETSTANDARD2_0
    public static byte[] Encrypt(
        string data,
        byte[] publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        Encrypt((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), publicKey, rsaEncryptionPadding);

    public static byte[] Decrypt(
        string data,
        byte[] privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        Decrypt((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, rsaEncryptionPadding);

    public static byte[] SignData(
        string data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        SignData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, hashAlgorithmName,
            rsaEncryptionPadding);

    public static bool VerifyData(
        string data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        VerifyData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), signature, publicKey, hashAlgorithmName,
            rsaEncryptionPadding);

    public static byte[] SignHash(
        string data,
        byte[] privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        SignHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, hashAlgorithmName,
            rsaEncryptionPadding);

    public static bool VerifyHash(
        string data,
        byte[] signature,
        byte[] publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        VerifyHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), signature, publicKey, hashAlgorithmName,
            rsaEncryptionPadding);
#endif
}