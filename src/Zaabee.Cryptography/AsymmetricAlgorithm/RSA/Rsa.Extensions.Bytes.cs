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
#endif
}