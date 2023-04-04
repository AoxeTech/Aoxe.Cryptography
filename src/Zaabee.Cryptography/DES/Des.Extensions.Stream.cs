namespace Zaabee.Cryptography.DES;

public static partial class DesExtensions
{
    public static void EncryptByDes(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);

    public static void DecryptByDes(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static MemoryStream EncryptByDes(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static MemoryStream DecryptByDes(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}