namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToSha512Async(this Stream inputStream) =>
        ShaHelper.ComputeSha512Async(inputStream);
#endif
}