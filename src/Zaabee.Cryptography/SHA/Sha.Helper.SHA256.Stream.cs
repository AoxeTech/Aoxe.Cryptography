namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha256(Stream inputStream)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return sha256.ToHash(inputStream);
    }
}