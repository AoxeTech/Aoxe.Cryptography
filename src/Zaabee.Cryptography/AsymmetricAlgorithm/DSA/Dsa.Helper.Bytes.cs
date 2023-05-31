namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
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
}