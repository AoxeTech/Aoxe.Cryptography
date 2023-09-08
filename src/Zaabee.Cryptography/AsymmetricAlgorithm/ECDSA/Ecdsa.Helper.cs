namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaHelper
{
    public static (ECParameters privateKey, ECParameters publicKey) GenerateParameters()
    {
        using var ecDsa = ECDsa.Create();
        var privateKey = ecDsa.ExportParameters(true);
        var publicKey = ecDsa.ExportParameters(false);

        return (privateKey, publicKey);
    }

#if !NETSTANDARD2_0
    public static (byte[] privateKey, byte[] publicKey) GenerateKeys()
    {
        using var ecDsa = ECDsa.Create();
        var privateKey = ecDsa.ExportECPrivateKey();
        var publicKey = ecDsa.ExportSubjectPublicKeyInfo();
        return (privateKey, publicKey);
    }
#endif
}