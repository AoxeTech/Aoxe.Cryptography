namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
    public static byte[] CreateSignature(
        string rgbHash,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        CreateSignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(rgbHash), privateKey);

    public static bool VerifySignature(
        string rgbHash,
        byte[] signature,
        DSAParameters publicKey,
        Encoding? encoding = null) =>
        VerifySignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(rgbHash), signature, publicKey);

#if !NETSTANDARD2_0
    public static byte[] SignData(
        string data,
        DSAParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null)
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(privateKey);
        return dsa.SignData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data),
            hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName);
    }

    public static bool VerifyData(
        string data,
        byte[] signature,
        DSAParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null)
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        dsa.ImportParameters(publicKey);
        return dsa.VerifyData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), signature,
            hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName);
    }
#endif
}