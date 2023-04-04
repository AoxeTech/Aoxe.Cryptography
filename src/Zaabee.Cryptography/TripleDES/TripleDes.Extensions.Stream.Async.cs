namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesExtensions
{
    public static Task EncryptByTripleDesAsync(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static Task DecryptByTripleDesAsync(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static Task<MemoryStream> EncryptByTripleDesAsync(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static Task<MemoryStream> DecryptByTripleDesAsync(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}