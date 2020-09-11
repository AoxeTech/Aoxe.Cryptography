using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class DsaHelper
    {
        public static Encoding Encoding { get; set; } = Encoding.UTF8;

        public static byte[] CreateSignature(string original, DSAParameters privateKey, Encoding encoding = null) =>
            CreateSignature(encoding is null ? Encoding.GetBytes(original) : encoding.GetBytes(original), privateKey);

        public static byte[] CreateSignature(byte[] original, DSAParameters privateKey)
        {
            using var dsa = DSA.Create();
            dsa.ImportParameters(privateKey);
            return dsa.CreateSignature(original);
        }

        public static bool VerifySignature(string original, byte[] signature, DSAParameters publicKey,
            Encoding encoding = null) =>
            VerifySignature(encoding is null ? Encoding.GetBytes(original) : encoding.GetBytes(original), signature,
                publicKey);

        public static bool VerifySignature(byte[] original, byte[] signature, DSAParameters publicKey)
        {
            using var dsa = DSA.Create();
            dsa.ImportParameters(publicKey);
            return dsa.VerifySignature(original, signature);
        }

        public static (DSAParameters privateKey, DSAParameters publicKey) GenerateParameters()
        {
            using var dsa = DSA.Create();
            var privateKey = dsa.ExportParameters(true);
            var publicKey = dsa.ExportParameters(false);
            return (privateKey, publicKey);
        }
    }
}