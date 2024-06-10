namespace Aoxe.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return inputStream.ToHash(sha384);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return inputStream.ToHashString(sha384);
    }
}
