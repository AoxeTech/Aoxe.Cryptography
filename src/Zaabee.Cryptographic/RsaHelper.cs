using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class RsaHelper
    {
        public static Encoding Encoding { get; set; } = Encoding.UTF8;
        public static RSAEncryptionPadding Padding { get; set; } = RSAEncryptionPadding.OaepSHA256;

        public static byte[] Encrypt(string original, RSAParameters publicKey,
            RSAEncryptionPadding rsaEncryptionPadding = null, Encoding encoding = null)
        {
            encoding ??= Encoding;
            return Encrypt(encoding.GetBytes(original), publicKey, rsaEncryptionPadding);
        }

        public static byte[] Encrypt(byte[] original, RSAParameters publicKey,
            RSAEncryptionPadding rsaEncryptionPadding = null)
        {
            using var rsa = RSA.Create();
            rsa.ImportParameters(publicKey);
            return rsa.Encrypt(original, rsaEncryptionPadding ?? Padding);
        }

        public static byte[] Decrypt(byte[] original, RSAParameters privateKey,
            RSAEncryptionPadding rsaEncryptionPadding = null)
        {
            using var rsa = RSA.Create();
            rsa.ImportParameters(privateKey);
            return rsa.Decrypt(original, rsaEncryptionPadding ?? Padding);
        }

        public static (RSAParameters privateKey, RSAParameters publicKey) GenerateParameters()
        {
            using var rsa = RSA.Create();
            var privateKey = rsa.ExportParameters(true);
            var publicKey = rsa.ExportParameters(false);
            return (privateKey, publicKey);
        }
    }
}