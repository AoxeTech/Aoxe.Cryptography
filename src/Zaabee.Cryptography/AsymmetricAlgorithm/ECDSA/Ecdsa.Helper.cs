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
}
