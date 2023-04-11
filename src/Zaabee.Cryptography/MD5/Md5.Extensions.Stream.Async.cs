namespace Zaabee.Cryptography.MD5;

public static partial class Md5Extensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToMd5Async(this Stream inputStream) =>
        Md5Helper.ComputeMd5Async(inputStream);
#endif
}