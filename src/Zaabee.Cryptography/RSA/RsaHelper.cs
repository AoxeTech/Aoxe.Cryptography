namespace Zaabee.Cryptography;

public static class RsaHelper
{
    public static Encoding Encoding { get; set; } = Encoding.UTF8;
    public static RSAEncryptionPadding Padding { get; set; } = RSAEncryptionPadding.OaepSHA256;

    public static byte[] Encrypt(
        string original,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        Encrypt((encoding ?? Encoding).GetBytes(original), publicKey, rsaEncryptionPadding);

    public static byte[] Encrypt(
        byte[] original,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = RSA.Create();
        rsa.ImportParameters(publicKey);
        return rsa.Encrypt(original, rsaEncryptionPadding ?? Padding);
    }

    public static string DecryptToString(
        byte[] encryptBytes,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null,
        Encoding? encoding = null) =>
        (encoding ?? Encoding).GetString(Decrypt(encryptBytes, privateKey, rsaEncryptionPadding));

    public static byte[] Decrypt(
        byte[] encryptBytes,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.Decrypt(encryptBytes, rsaEncryptionPadding ?? Padding);
    }

    public static (RSAParameters privateKey, RSAParameters publicKey) GenerateParameters()
    {
        using var rsa = RSA.Create();
        var privateKey = rsa.ExportParameters(true);
        var publicKey = rsa.ExportParameters(false);
        return (privateKey, publicKey);
    }
}