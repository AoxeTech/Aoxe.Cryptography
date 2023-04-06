namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static string GetSha256HashString(
        string str,
        Encoding? encoding = null) =>
        GetSha256HashString((encoding ?? Encoding).GetBytes(str));

    public static string GetSha256HashString(byte[] bytes)
    {
        var hashBytes = GetSha256HashBytes(bytes);
        return BitConverter.ToString(hashBytes).Replace("-",string.Empty);
    }
}