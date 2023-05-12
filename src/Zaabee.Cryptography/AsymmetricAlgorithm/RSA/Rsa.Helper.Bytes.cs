namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaHelper
{
    public static byte[] Encrypt(
        byte[] original,
        RSAParameters publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(publicKey);
        return rsa.Encrypt(original, rsaEncryptionPadding ?? Padding);
    }

    public static byte[] Decrypt(
        byte[] encryptBytes,
        RSAParameters privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportParameters(privateKey);
        return rsa.Decrypt(encryptBytes, rsaEncryptionPadding ?? Padding);
    }

#if !NETSTANDARD2_0
    public static byte[] Encrypt(
        byte[] original,
        byte[] publicKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPublicKey(publicKey, out _);
        return rsa.Encrypt(original, rsaEncryptionPadding ?? Padding);
    }

    public static byte[] Decrypt(
        byte[] encryptBytes,
        byte[] privateKey,
        RSAEncryptionPadding? rsaEncryptionPadding = null)
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportRSAPrivateKey(privateKey, out _);
        return rsa.Decrypt(encryptBytes, rsaEncryptionPadding ?? Padding);
    }
#endif
}