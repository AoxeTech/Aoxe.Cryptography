namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaExtensions
{
    public static byte[] SignDataByEcdsa(
        this string original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        EcdsaHelper.SignData(original, privateKey, hashAlgorithmName, encoding);

    public static bool VerifyDataByEcdsa(
        this string original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        EcdsaHelper.VerifyData(original, signature, publicKey, hashAlgorithmName, encoding);

    public static byte[] SignHashByEcdsa(
        this string original,
        ECParameters privateKey,
        Encoding? encoding = null) =>
        EcdsaHelper.SignHash(original, privateKey, encoding);

    public static bool VerifyHashByEcdsa(
        this string original,
        byte[] signature,
        ECParameters publicKey,
        Encoding? encoding = null) =>
        EcdsaHelper.VerifyHash(original, signature, publicKey, encoding);
}