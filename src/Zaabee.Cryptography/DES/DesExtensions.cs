namespace Zaabee.Cryptography;

public static class DesExtensions
{
    public static byte[] EncryptByDes(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] EncryptByDes(
        this string original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        DesHelper.Encrypt(original, key, vector, cipherMode, paddingMode, encoding);

    public static byte[] DecryptByDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);

    public static string DecryptToStringByDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        DesHelper.DecryptToString(encrypted, key, vector, cipherMode, paddingMode, encoding);
}