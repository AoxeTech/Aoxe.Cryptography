namespace Zaabee.Cryptography.RC2;

public static partial class Rc2Helper
{
    public static MemoryStream Encrypt(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        var encrypted = new MemoryStream();
        Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);
        return encrypted;
    }

    public static void Encrypt(
        Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var rc2 = System.Security.Cryptography.RC2.Create())
        {
            rc2.Mode = cipherMode;
            rc2.Padding = paddingMode;
            using (var encryptor = rc2.CreateEncryptor(key, vector))
            {
#if NETSTANDARD2_0
                var ms = new MemoryStream();
                using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    original.CopyTo(cryptoStream);
                    cryptoStream.FlushFinalBlock();
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.CopyTo(encrypted);
                }
#else
                using (var cryptoStream = new CryptoStream(encrypted, encryptor, CryptoStreamMode.Write, true))
                    original.CopyTo(cryptoStream);
#endif
            }
        }
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    public static MemoryStream Decrypt(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        var decrypted = new MemoryStream();
        Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);
        return decrypted;
    }

    public static void Decrypt(
        Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var rc2 = System.Security.Cryptography.RC2.Create())
        {
            rc2.Mode = cipherMode;
            rc2.Padding = paddingMode;
            using (var decryptor = rc2.CreateDecryptor(key, vector))
            {
#if NETSTANDARD2_0
                var ms = new MemoryStream();
                encrypted.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                using (var csDecrypt = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    csDecrypt.CopyTo(decrypted);
#else
                using (var csDecrypt = new CryptoStream(encrypted, decryptor, CryptoStreamMode.Read, true))
                    csDecrypt.CopyTo(decrypted);
#endif
            }
        }
        encrypted.TrySeek(0, SeekOrigin.Begin);
        decrypted.TrySeek(0, SeekOrigin.Begin);
    }
}