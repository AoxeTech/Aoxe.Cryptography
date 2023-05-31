namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
    public static byte[] CreateSignature(
        string original,
        DSAParameters privateKey,
        Encoding? encoding = null) =>
        CreateSignature((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey);
}