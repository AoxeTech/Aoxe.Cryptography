namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesExtensions
{
    public static void EncryptByTripleDes(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);

    public static void DecryptByTripleDes(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static MemoryStream EncryptByTripleDes(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static MemoryStream DecryptByTripleDes(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}