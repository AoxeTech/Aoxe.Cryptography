namespace Zaabee.Cryptography;

public static class AesExtensions
{
    public static byte[] EncryptByAes(this string original, string key, string vector,
        CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        AesHelper.Encrypt(original, key, vector, cipherMode, paddingMode, encoding);

    public static byte[] EncryptByAes(this string original, byte[] key, byte[] vector,
        CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static string DecryptByAes(this byte[] encrypted, string key, string vector,
        CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        AesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode, encoding);

    public static string DecryptByAes(this byte[] encrypted, byte[] key, byte[] vector,
        CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}