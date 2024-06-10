namespace Aoxe.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaExtensions
{
    public static byte[] SignDataByEcdsa(
        this byte[] data,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null
    ) => EcdsaHelper.SignData(data, privateKey, hashAlgorithmName);

    public static bool VerifyDataByEcdsa(
        this byte[] original,
        byte[] data,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null
    ) => EcdsaHelper.VerifyData(original, data, publicKey, hashAlgorithmName);

    public static byte[] SignHashByEcdsa(this byte[] hash, ECParameters privateKey) =>
        EcdsaHelper.SignHash(hash, privateKey);

    public static bool VerifyHashByEcdsa(
        this byte[] hash,
        byte[] signature,
        ECParameters publicKey
    ) => EcdsaHelper.VerifyHash(hash, signature, publicKey);
}
