namespace Zaabee.Cryptographic;

/// <summary>
/// Triple DES Helper
/// </summary>
public static class TripleDesHelper
{
    public static Encoding Encoding { get; set; } = Encoding.UTF8;

    public static byte[] GenerateKey()
    {
        using var tripleDes = TripleDES.Create();
        tripleDes.GenerateKey();
        return tripleDes.Key;
    }

    public static byte[] GenerateVector()
    {
        using var tripleDes = TripleDES.Create();
        tripleDes.GenerateIV();
        return tripleDes.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var tripleDes = TripleDES.Create();
        tripleDes.GenerateKey();
        tripleDes.GenerateIV();
        return (tripleDes.Key, tripleDes.IV);
    }

    /// <summary>
    /// Triple DES Encrypt
    /// </summary>
    /// <param name="original"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static byte[] Encrypt(string original, string key, string vector, CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7, Encoding? encoding = null)
    {
        var bKey = (encoding ?? Encoding).GetBytes(key);
        var bVector = (encoding ?? Encoding).GetBytes(vector);
        return Encrypt(original, bKey, bVector, cipherMode, paddingMode);
    }

    /// <summary>
    /// Triple DES Encrypt
    /// </summary>
    /// <param name="original"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] Encrypt(string original, byte[] key, byte[] vector, CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        Array.Resize(ref key, 24);
        Array.Resize(ref vector, 8);
        using (var tripleDes = TripleDES.Create())
        {
            tripleDes.Mode = cipherMode;
            tripleDes.Padding = paddingMode;
            using (var encryptor = tripleDes.CreateEncryptor(key, vector))
            using (var msEncrypt = new MemoryStream())
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (var swEncrypt = new StreamWriter(csEncrypt))
                    swEncrypt.Write(original);
                return msEncrypt.ToArray();
            }
        }
    }

    /// <summary>
    /// Triple DES Decrypt
    /// </summary>
    /// <param name="encrypted"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Decrypt(byte[] encrypted, string key, string vector, CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7, Encoding? encoding = null)
    {
        var bKey = (encoding ?? Encoding).GetBytes(key);
        var bVector = (encoding ?? Encoding).GetBytes(vector);
        return Decrypt(encrypted, bKey, bVector, cipherMode, paddingMode);
    }

    /// <summary>
    /// Triple DES Decrypt
    /// </summary>
    /// <param name="encrypted"></param>
    /// <param name="key"></param>
    /// <param name="vector"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    public static string Decrypt(byte[] encrypted, byte[] key, byte[] vector, CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        Array.Resize(ref key, 24);
        Array.Resize(ref vector, 8);
        using (var tripleDes = TripleDES.Create())
        {
            tripleDes.Mode = cipherMode;
            tripleDes.Padding = paddingMode;
            using (var decryptor = tripleDes.CreateDecryptor(key, vector))
            using (var msDecrypt = new MemoryStream(encrypted))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt))
                return srDecrypt.ReadToEnd();
        }
    }
}