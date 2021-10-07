using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class TripleDesExtensions
    {
        public static byte[] EncryptByTripleDes(this string original, string key, string vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7,
            Encoding encoding = null) =>
            TripleDesHelper.Encrypt(original, key, vector, cipherMode, paddingMode, encoding);

        public static byte[] EncryptByTripleDes(this string original, byte[] key, byte[] vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7) =>
            TripleDesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

        public static string DecryptByTripleDes(this byte[] encrypted, string key, string vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7,
            Encoding encoding = null) =>
            TripleDesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode, encoding);

        public static string DecryptByTripleDes(this byte[] encrypted, byte[] key, byte[] vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7) =>
            TripleDesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
    }
}