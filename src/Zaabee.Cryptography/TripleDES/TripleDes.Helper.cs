namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesHelper
{
    public static byte[] GenerateKey()
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return SymmetricAlgorithmHelper.GenerateKey(tripleDes);
    }

    public static byte[] GenerateVector()
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return SymmetricAlgorithmHelper.GenerateVector(tripleDes);
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return SymmetricAlgorithmHelper.GenerateKeyAndVector(tripleDes);
    }
}