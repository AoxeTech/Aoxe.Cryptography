namespace Zaabee.Cryptography;

public static class DesExtensions
{
    public static byte[] EncryptByDes(
        this string original,
        string key, string vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        DesHelper.Encrypt(original, key, vector, cipherMode, paddingMode, encoding);

    public static byte[] EncryptByDes(
        this string original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static string DecryptByDes(
        this byte[] encrypted,
        string key, string vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        DesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode, encoding);

    public static string DecryptByDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}