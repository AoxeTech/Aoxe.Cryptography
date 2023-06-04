namespace Zaabee.Cryptography.Internals;

internal static class SymmetricAlgorithmHelper
{
    internal static byte[] GenerateKey(System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm)
    {
        symmetricAlgorithm.GenerateKey();
        return symmetricAlgorithm.Key;
    }

    internal static byte[] GenerateVector(System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm)
    {
        symmetricAlgorithm.GenerateIV();
        return symmetricAlgorithm.IV;
    }

    internal static (byte[] key, byte[] vector) GenerateKeyAndVector(
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm)
    {
        symmetricAlgorithm.GenerateKey();
        symmetricAlgorithm.GenerateIV();
        return (symmetricAlgorithm.Key, symmetricAlgorithm.IV);
    }
}