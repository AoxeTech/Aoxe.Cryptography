namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var tripleDes = System.Security.Cryptography.TripleDES.Create())
        {
            tripleDes.Mode = cipherMode;
            tripleDes.Padding = paddingMode;
            using (var msEncrypt = new MemoryStream())
            {
                using (var encryptor = tripleDes.CreateEncryptor(key, vector))
                using (var cryptoStream = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
#if NETSTANDARD2_0
                    cryptoStream.Write(original, 0, original.Length);
#else
                    cryptoStream.Write(original);
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
        using (var tripleDes = System.Security.Cryptography.TripleDES.Create())
        {
            tripleDes.Mode = cipherMode;
            tripleDes.Padding = paddingMode;
            using (var msDecrypt = new MemoryStream(encrypted))
            using (var decryptor = tripleDes.CreateDecryptor(key, vector))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                return csDecrypt.ReadToEnd();
        }
    }
}