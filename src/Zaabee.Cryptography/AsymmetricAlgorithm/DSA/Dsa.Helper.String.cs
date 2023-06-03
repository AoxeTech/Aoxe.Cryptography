namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
    public static byte[] CreateSignature(
        string original,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        CreateSignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey);

    public static bool VerifySignature(
        string original,
        byte[] signature,
        DSAParameters publicKey,
        Encoding? encoding = null) =>
        VerifySignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey);
}