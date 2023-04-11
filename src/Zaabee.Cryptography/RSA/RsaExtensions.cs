namespace Zaabee.Cryptography.RSA;

public static class RsaExtensions
{
    public static byte[] EncryptByRsa(
        this byte[] original,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Encrypt(original, publicKey, rsaEncryptionPadding);

    public static byte[] DecryptByRsa(
        this byte[] encryptBytes,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null) =>
        RsaHelper.Decrypt(encryptBytes, privateKey, rsaEncryptionPadding);
}