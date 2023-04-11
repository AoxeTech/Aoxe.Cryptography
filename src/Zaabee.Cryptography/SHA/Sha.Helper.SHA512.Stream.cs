namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha512(Stream inputStream)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return sha512.ToHash(inputStream);
    }
}