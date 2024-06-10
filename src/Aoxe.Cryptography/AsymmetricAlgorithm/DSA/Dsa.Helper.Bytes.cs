namespace Aoxe.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
    public static byte[] CreateSignature(byte[] rgbHash, DSAParameters privateKey)
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(privateKey);
#if NETSTANDARD2_0
        using var sha1 = SHA1.Create();
        return dsa.CreateSignature(sha1.ComputeHash(rgbHash));
#else
        return dsa.CreateSignature(rgbHash);
#endif
    }

    public static bool VerifySignature(byte[] rgbHash, byte[] signature, DSAParameters publicKey)
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(publicKey);
#if NETSTANDARD2_0
        using var sha1 = SHA1.Create();
        return dsa.VerifySignature(sha1.ComputeHash(rgbHash), signature);
#else
        return dsa.VerifySignature(rgbHash, signature);
#endif
    }

#if !NETSTANDARD2_0
    public static byte[] SignData(
        byte[] data,
        DSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null
    )
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(privateKey);
        return dsa.SignData(data, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName);
    }

    public static bool VerifyData(
        byte[] data,
        byte[] signature,
        DSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null
    )
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(publicKey);
        return dsa.VerifyData(
            data,
            signature,
            hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName
        );
    }
#endif
}
