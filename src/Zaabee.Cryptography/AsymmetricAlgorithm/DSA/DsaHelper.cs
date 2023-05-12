namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static class DsaHelper
{
    public static Encoding Encoding { get; set; } = Encoding.UTF8;

    public static byte[] CreateSignature(
        string original,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        CreateSignature((encoding ?? Encoding).GetBytes(original), privateKey);

    public static byte[] CreateSignature(
        byte[] original,
        DSAParameters privateKey)
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(privateKey);
#if NETSTANDARD2_0
        using var sha1 = SHA1.Create();
        return dsa.CreateSignature(sha1.ComputeHash(original));
#else
        return dsa.CreateSignature(original);
#endif
    }

    public static bool VerifySignature(
        string original,
        byte[] signature,
        DSAParameters publicKey,
        Encoding? encoding = null) =>
        VerifySignature((encoding ?? Encoding).GetBytes(original), signature, publicKey);

    public static bool VerifySignature(
        byte[] original,
        byte[] signature,
        DSAParameters publicKey)
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(publicKey);
#if NETSTANDARD2_0
        using var sha1 = SHA1.Create();
        return dsa.VerifySignature(sha1.ComputeHash(original), signature);
#else
        return dsa.VerifySignature(original, signature);
#endif
    }

    public static (DSAParameters privateKey, DSAParameters publicKey) GenerateParameters()
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        var privateKey = dsa.ExportParameters(true);
        var publicKey = dsa.ExportParameters(false);
        return (privateKey, publicKey);
    }

//     public static void Test()
//     {
//         var dsa = System.Security.Cryptography.DSA.Create();
//
// // Generate a new public/private key pair
//         var publicKey = dsa.ExportParameters(false);
//         var privateKey = dsa.ExportParameters(true);
//
// // Sign some data using the private key
//         var data = new byte[] { 1, 2, 3, 4, 5 };
//         var signature = dsa.SignData(data, privateKey);
//
// // Verify the signature using the public key
//         var verified = dsa.VerifyData(data, signature, publicKey);
//     }
}