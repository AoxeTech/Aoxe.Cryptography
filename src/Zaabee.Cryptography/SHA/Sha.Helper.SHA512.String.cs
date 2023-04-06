namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static string GetSha512HashString(
        string str,
        Encoding? encoding = null) =>
        GetSha512HashString((encoding ?? Encoding).GetBytes(str));

    public static string GetSha512HashString(byte[] bytes)
    {
        var hashBytes = GetSha512HashBytes(bytes);
        return BitConverter.ToString(hashBytes).Replace("-",string.Empty);
    }
}