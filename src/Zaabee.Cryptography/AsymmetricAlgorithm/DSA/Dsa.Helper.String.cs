namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
    public static bool VerifySignature(
        string original,
        byte[] signature,
        DSAParameters publicKey,
        Encoding? encoding = null) =>
        VerifySignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey);

    public static (DSAParameters privateKey, DSAParameters publicKey) GenerateParameters()
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        var privateKey = dsa.ExportParameters(true);
        var publicKey = dsa.ExportParameters(false);
        return (privateKey, publicKey);
    }
}