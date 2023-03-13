namespace Zaabee.Cryptography;

/// <summary>
/// AES helper
/// </summary>
public static class AesHelper
{
    public static Encoding Encoding { get; set; } = Encoding.UTF8;

    public static byte[] GenerateKey()
    {
        using var aes = Aes.Create();
        aes.GenerateKey();
        return aes.Key;
    }

    public static byte[] GenerateVector()
    {
        using var aes = Aes.Create();
        aes.GenerateIV();
        return aes.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();
        return (aes.Key, aes.IV);
    }

    /// <summary>
    /// AES Encrypt
    /// </summary>
    /// <param name="original"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] Encrypt(
        string original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        Encrypt((encoding ?? Encoding).GetBytes(original), key, vector, cipherMode, paddingMode);

    /// <summary>
    /// AES Encrypt
    /// </summary>
    /// <param name="original"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var aes = Aes.Create())
        {
            aes.Mode = cipherMode;
            aes.Padding = paddingMode;
            using (var msEncrypt = new MemoryStream())
            {
                using (var encryptor = aes.CreateEncryptor(key, vector))
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
#if NETSTANDARD2_0
                    csEncrypt.Write(original, 0, original.Length);
#else
                    csEncrypt.Write(original);
#endif
                }
                return msEncrypt.ToArray();
            }
        }
    }

    /// <summary>
    /// AES Decrypt
    /// </summary>
    /// <param name="encrypted"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static string DecryptToString(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        Encoding? encoding = null) =>
        (encoding ?? Encoding).GetString(DecryptToBytes(encrypted, key, vector, cipherMode, paddingMode));

    /// <summary>
    /// AES Decrypt
    /// </summary>
    /// <param name="encrypted"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] DecryptToBytes(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var aes = Aes.Create())
        {
            aes.Mode = cipherMode;
            aes.Padding = paddingMode;
            using (var msDecrypt = new MemoryStream(encrypted))
            using (var decryptor = aes.CreateDecryptor(key, vector))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                return csDecrypt.ReadToEnd();
        }
    }
}