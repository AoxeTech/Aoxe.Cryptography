namespace Zaabee.Cryptography.RC2;

public static partial class Rc2Helper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var rc2 = System.Security.Cryptography.RC2.Create())
        {
            rc2.Mode = cipherMode;
            rc2.Padding = paddingMode;
            using (var msEncrypt = new MemoryStream())
            {
                using (var encryptor = rc2.CreateEncryptor(key, vector))
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

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var rc2 = System.Security.Cryptography.RC2.Create())
        {
            rc2.Mode = cipherMode;
            rc2.Padding = paddingMode;
            using (var msDecrypt = new MemoryStream(encrypted))
            using (var decryptor = rc2.CreateDecryptor(key, vector))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                return csDecrypt.ReadToEnd();
        }
    }
}