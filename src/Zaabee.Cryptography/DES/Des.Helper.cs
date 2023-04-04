namespace Zaabee.Cryptography.DES;

/// <summary>
/// DES Helper
/// </summary>
public static partial class DesHelper
{
    public static byte[] GenerateKey()
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.GenerateKey();
        return des.Key;
    }

    public static byte[] GenerateVector()
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.GenerateIV();
        return des.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.GenerateKey();
        des.GenerateIV();
        return (des.Key, des.IV);
    }
}