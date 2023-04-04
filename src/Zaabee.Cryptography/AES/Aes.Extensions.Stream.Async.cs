namespace Zaabee.Cryptography.AES;

public static partial class AesExtensions
{
    public static Task EncryptByAesAsync(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static Task DecryptByAesAsync(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static Task<MemoryStream> EncryptByAesAsync(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static Task<MemoryStream> DecryptByAesAsync(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}