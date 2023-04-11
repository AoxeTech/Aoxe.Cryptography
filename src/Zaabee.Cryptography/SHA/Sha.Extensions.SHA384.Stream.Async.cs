namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToSha384Async(this Stream inputStream) =>
        ShaHelper.ComputeSha384Async(inputStream);
#endif
}