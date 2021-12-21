namespace Zaabee.Cryptographic;

public static class RsaExtensions
{
    public static byte[] EncryptByRsa(this string original, RSAParameters publicKey,
        RSAEncryptionPadding rsaEncryptionPadding = null, Encoding encoding = null) =>
        RsaHelper.Encrypt(original, publicKey, rsaEncryptionPadding, encoding);

    public static byte[] EncryptByRsa(this byte[] original, RSAParameters publicKey,
        RSAEncryptionPadding rsaEncryptionPadding = null) =>
        RsaHelper.Encrypt(original, publicKey, rsaEncryptionPadding);

    public static string DecryptToStringByRsa(this byte[] encryptBytes, RSAParameters privateKey,
        RSAEncryptionPadding rsaEncryptionPadding = null) =>
        RsaHelper.DecryptToString(encryptBytes, privateKey, rsaEncryptionPadding);

    public static byte[] DecryptByRsa(this byte[] encryptBytes, RSAParameters privateKey,
        RSAEncryptionPadding rsaEncryptionPadding = null) =>
        RsaHelper.Decrypt(encryptBytes, privateKey, rsaEncryptionPadding);
}