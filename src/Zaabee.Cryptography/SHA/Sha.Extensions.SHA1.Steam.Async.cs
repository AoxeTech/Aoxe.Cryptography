namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToSha1Async(this Stream inputStream) =>
        ShaHelper.ComputeSha1Async(inputStream);
#endif
}