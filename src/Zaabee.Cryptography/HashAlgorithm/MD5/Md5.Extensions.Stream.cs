namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
    public static byte[] ToMd5(this Stream inputStream) =>
        HashAlgorithm.MD5.Md5Helper.ComputeMd5(inputStream);
}