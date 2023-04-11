namespace Zaabee.Cryptography.DSA;

public static class DsaExtensions
{
    public static byte[] CreateSignatureByDsa(
        this string original,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        DsaHelper.CreateSignature(original, privateKey, encoding);

    public static byte[] CreateSignatureByDsa(
        this byte[] original,
        DSAParameters privateKey) =>
        DsaHelper.CreateSignature(original, privateKey);

    public static bool VerifySignatureByDsa(
        this string original,
        byte[] signature,
        DSAParameters publicKey,
        Encoding? encoding = null) =>
        DsaHelper.VerifySignature(original, signature, publicKey, encoding);

    public static bool VerifySignatureByDsa(
        this byte[] original,
        byte[] signature,
        DSAParameters publicKey) =>
        DsaHelper.VerifySignature(original, signature, publicKey);
}