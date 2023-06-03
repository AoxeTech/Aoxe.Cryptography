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

#if !NETSTANDARD2_0
    public static byte[] SignDataByDsa(
        this byte[] data,
        DSAParameters privateKey) =>
        DsaHelper.SignData(data, privateKey);

    public static bool VerifyDataByDsa(
        this byte[] data,
        byte[] signature,
        DSAParameters publicKey) =>
        DsaHelper.VerifyData(data, signature, publicKey);
#endif
}