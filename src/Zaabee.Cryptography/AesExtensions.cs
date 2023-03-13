namespace Zaabee.Cryptography;

public static class AesExtensions
{
    public static byte[] EncryptByAes(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] EncryptByAes(
        this string original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        AesHelper.Encrypt(original, key, vector, cipherMode, paddingMode, encoding);

    public static byte[] DecryptToBytesByAes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        AesHelper.DecryptToBytes(encrypted, key, vector, cipherMode, paddingMode);

    public static string DecryptToStringByAes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        AesHelper.DecryptToString(encrypted, key, vector, cipherMode, paddingMode, encoding);
}