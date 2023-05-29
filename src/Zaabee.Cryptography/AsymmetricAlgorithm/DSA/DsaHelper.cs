namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static class DsaHelper
{
    public static byte[] CreateSignature(
        string original,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        CreateSignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey);

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
        VerifySignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey);

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
}