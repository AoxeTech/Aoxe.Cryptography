namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesHelper
{
    public static byte[] GenerateKey()
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        tripleDes.GenerateKey();
        return tripleDes.Key;
    }

    public static byte[] GenerateVector()
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        tripleDes.GenerateIV();
        return tripleDes.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        tripleDes.GenerateKey();
        tripleDes.GenerateIV();
        return (tripleDes.Key, tripleDes.IV);
    }
}