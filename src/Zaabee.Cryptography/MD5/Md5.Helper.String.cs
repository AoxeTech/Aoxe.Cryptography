namespace Zaabee.Cryptography.MD5;

public static partial class Md5Helper
{
    public static string ComputeMd5(
        string str,
        Encoding? encoding = null)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return md5.ToHashString(str, encoding);
    }
}