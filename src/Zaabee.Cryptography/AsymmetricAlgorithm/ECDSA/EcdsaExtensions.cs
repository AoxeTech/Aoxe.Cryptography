namespace Zaabee.Cryptography.ECDSA;

public static class EcdsaExtensions
{
    #region Data

    public static byte[] SignDataByEcdsa(
        this string original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        EcdsaHelper.SignData(original, privateKey, hashAlgorithmName, encoding);

    public static byte[] SignDataByEcdsa(
        this byte[] original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null) =>
        EcdsaHelper.SignData(original, privateKey, hashAlgorithmName);

    public static bool VerifyDataByEcdsa(
        this string original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        EcdsaHelper.VerifyData(original, signature, publicKey, hashAlgorithmName, encoding);

    public static bool VerifyDataByEcdsa(
        this byte[] original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null) =>
        EcdsaHelper.VerifyData(original, signature, publicKey, hashAlgorithmName);

    #endregion

    #region Hash

    public static byte[] SignHashByEcdsa(
        this string original,
        ECParameters privateKey,
        Encoding? encoding = null) =>
        EcdsaHelper.SignHash(original, privateKey, encoding);

    public static byte[] SignHashByEcdsa(
        this byte[] original,
        ECParameters privateKey) =>
        EcdsaHelper.SignHash(original, privateKey);

    public static bool VerifyHashByEcdsa(
        this string original,
        byte[] signature,
        ECParameters publicKey,
        Encoding? encoding = null) =>
        EcdsaHelper.VerifyHash(original, signature, publicKey, encoding);

    public static bool VerifyHashByEcdsa(
        this byte[] original,
        byte[] signature, ECParameters publicKey) =>
        EcdsaHelper.VerifyHash(original, signature, publicKey);

    #endregion
}