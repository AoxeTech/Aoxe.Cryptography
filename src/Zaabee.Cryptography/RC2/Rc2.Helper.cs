namespace Zaabee.Cryptography.RC2;

public static partial class Rc2Helper
{
    public static byte[] GenerateKey()
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        rc2.GenerateKey();
        return rc2.Key;
    }

    public static byte[] GenerateVector()
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        rc2.GenerateIV();
        return rc2.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        rc2.GenerateKey();
        rc2.GenerateIV();
        return (rc2.Key, rc2.IV);
    }
}