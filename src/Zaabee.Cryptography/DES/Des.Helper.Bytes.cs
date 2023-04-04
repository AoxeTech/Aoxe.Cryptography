namespace Zaabee.Cryptography.DES;

public static partial class DesHelper
{
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