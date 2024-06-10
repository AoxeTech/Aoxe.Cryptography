namespace Aoxe.Cryptography.SymmetricAlgorithm.RC2;

public static partial class Rc2Helper
{
    public static byte[] GenerateKey()
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return SymmetricAlgorithmHelper.GenerateKey(rc2);
    }

    public static byte[] GenerateVector()
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return SymmetricAlgorithmHelper.GenerateVector(rc2);
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return SymmetricAlgorithmHelper.GenerateKeyAndVector(rc2);
    }
}
