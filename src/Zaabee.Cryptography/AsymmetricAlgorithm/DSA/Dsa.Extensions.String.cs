namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaExtensions
{
    public static byte[] CreateSignatureByDsa(
        this string original,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        DsaHelper.CreateSignature(original, privateKey, encoding);

    public static bool VerifySignatureByDsa(
        this string original,
        byte[] signature,
        DSAParameters publicKey,
        Encoding? encoding = null) =>
        DsaHelper.VerifySignature(original, signature, publicKey, encoding);
}