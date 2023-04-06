namespace Zaabee.Cryptography.MD5;

public static partial class Md5Helper
{
    public static string GetMd5String(
        string str,
        Encoding? encoding = null) =>
        GetMd5String(str.GetBytes(encoding ?? Encoding));

    public static byte[] GetMd5Bytes(
        string str,
        Encoding? encoding = null) =>
        GetMd5Bytes(str.GetBytes(encoding ?? Encoding));
}