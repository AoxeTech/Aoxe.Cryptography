namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaExtensions
{
    public static byte[] SignDataByEcdsa(
        this byte[] original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null) =>
        EcdsaHelper.SignData(original, privateKey, hashAlgorithmName);

    public static bool VerifyDataByEcdsa(
        this byte[] original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null) =>
        EcdsaHelper.VerifyData(original, signature, publicKey, hashAlgorithmName);

    public static byte[] SignHashByEcdsa(
        this byte[] original,
        ECParameters privateKey) =>
        EcdsaHelper.SignHash(original, privateKey);

    public static bool VerifyHashByEcdsa(
        this byte[] original,
        byte[] signature, ECParameters publicKey) =>
        EcdsaHelper.VerifyHash(original, signature, publicKey);
}