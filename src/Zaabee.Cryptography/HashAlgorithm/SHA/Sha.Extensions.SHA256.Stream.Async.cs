namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToSha256Async(this Stream inputStream) =>
        ShaHelper.ComputeSha256Async(inputStream);
#endif
}