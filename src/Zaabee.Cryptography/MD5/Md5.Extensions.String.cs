namespace Zaabee.Cryptography.MD5;

public static partial class Md5Extensions
{
    public static string ToMd5String(this byte[] bytes) =>
        Md5Helper.GetMd5String(bytes);

    public static byte[] ToMd5Bytes(this byte[] bytes) =>
        Md5Helper.GetMd5Bytes(bytes);
}