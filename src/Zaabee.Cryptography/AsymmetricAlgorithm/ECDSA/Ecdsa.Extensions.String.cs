namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaExtensions
{
    public static byte[] SignDataByEcdsa(
        this string data,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        EcdsaHelper.SignData(data, privateKey, hashAlgorithmName, encoding);

    public static bool VerifyDataByEcdsa(
        this string data,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        EcdsaHelper.VerifyData(data, signature, publicKey, hashAlgorithmName, encoding);

    public static byte[] SignHashByEcdsa(
        this string hash,
        ECParameters privateKey,
        Encoding? encoding = null) =>
        EcdsaHelper.SignHash(hash, privateKey, encoding);

    public static bool VerifyHashByEcdsa(
        this string hash,
        byte[] signature,
        ECParameters publicKey,
        Encoding? encoding = null) =>
        EcdsaHelper.VerifyHash(hash, signature, publicKey, encoding);
}