namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaExtensions
{
#if !NETSTANDARD2_0 && !NET6_0
    public static byte[] SignData(
        this ReadOnlySpan<byte> data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignData(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyData(
        this ReadOnlySpan<byte> data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyData(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);

    public static byte[] SignHash(
        this ReadOnlySpan<byte> data,
        RSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.SignHash(data, privateKey, hashAlgorithmName, rsaEncryptionPadding);

    public static bool VerifyHash(
        this ReadOnlySpan<byte> data,
        byte[] signature,
        RSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        RSASignaturePadding? rsaEncryptionPadding = null) =>
        RsaHelper.VerifyHash(data, signature, publicKey, hashAlgorithmName, rsaEncryptionPadding);
#endif
}