namespace Aoxe.Cryptography.SymmetricAlgorithm.DES;

public static partial class DesHelper
{
    public static byte[] GenerateKey()
    {
        using var des = System.Security.Cryptography.DES.Create();
        return SymmetricAlgorithmHelper.GenerateKey(des);
    }

    public static byte[] GenerateVector()
    {
        using var des = System.Security.Cryptography.DES.Create();
        return SymmetricAlgorithmHelper.GenerateVector(des);
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var des = System.Security.Cryptography.DES.Create();
        return SymmetricAlgorithmHelper.GenerateKeyAndVector(des);
    }
}
