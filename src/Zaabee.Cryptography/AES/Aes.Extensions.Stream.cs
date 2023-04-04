namespace Zaabee.Cryptography.AES;

public static partial class AesExtensions
{
    public static void EncryptByAes(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);

    public static void DecryptByAes(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static MemoryStream EncryptByAes(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static MemoryStream DecryptByAes(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}