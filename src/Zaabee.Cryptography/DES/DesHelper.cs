namespace Zaabee.Cryptography.DES;

/// <summary>
/// DES Helper
/// </summary>
public static class DesHelper
{
    public static Encoding Encoding { get; set; } = Encoding.UTF8;

    public static byte[] GenerateKey()
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.GenerateKey();
        return des.Key;
    }

    public static byte[] GenerateVector()
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.GenerateIV();
        return des.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.GenerateKey();
        des.GenerateIV();
        return (des.Key, des.IV);
    }

    /// <summary>
    /// DES Encrypt
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
    /// DES Encrypt
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
        using (var des = System.Security.Cryptography.DES.Create())
        {
            des.Mode = cipherMode;
            des.Padding = paddingMode;
            using (var msEncrypt = new MemoryStream())
            {
                using (var encryptor = des.CreateEncryptor(key, vector))
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
#if NET48
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
    /// DES Decrypt
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
        (encoding ?? Encoding).GetString(Decrypt(encrypted, key, vector, cipherMode, paddingMode));

    /// <summary>
    /// DES Decrypt
    /// </summary>
    /// <param name="encrypted"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var des = System.Security.Cryptography.DES.Create())
        {
            des.Mode = cipherMode;
            des.Padding = paddingMode;
            using (var msDecrypt = new MemoryStream(encrypted))
            using (var decryptor = des.CreateDecryptor(key, vector))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                return csDecrypt.ReadToEnd();
        }
    }
}