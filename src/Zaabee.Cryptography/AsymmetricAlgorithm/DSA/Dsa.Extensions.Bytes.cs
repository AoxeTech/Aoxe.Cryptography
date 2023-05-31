namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaExtensions
{
    public static byte[] CreateSignatureByDsa(
        this byte[] original,
        DSAParameters privateKey) =>
        DsaHelper.CreateSignature(original, privateKey);

    public static bool VerifySignatureByDsa(
        this byte[] original,
        byte[] signature,
        DSAParameters publicKey) =>
        DsaHelper.VerifySignature(original, signature, publicKey);
}