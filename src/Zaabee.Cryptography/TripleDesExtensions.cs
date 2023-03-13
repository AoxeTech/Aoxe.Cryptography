namespace Zaabee.Cryptography;

public static class TripleDesExtensions
{

    public static byte[] EncryptByTripleDes(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] EncryptByTripleDes(
        this string original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        TripleDesHelper.Encrypt(original, key, vector, cipherMode, paddingMode, encoding);

    public static byte[] DecryptToBytesByTripleDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        TripleDesHelper.DecryptToBytes(encrypted, key, vector, cipherMode, paddingMode);

    public static string DecryptToStringByTripleDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        TripleDesHelper.DecryptToString(encrypted, key, vector, cipherMode, paddingMode, encoding);
}