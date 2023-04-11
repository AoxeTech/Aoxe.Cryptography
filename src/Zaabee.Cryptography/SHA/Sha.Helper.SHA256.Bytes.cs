using System.Text;

namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static byte[] GetSha256HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha256HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha256HashBytes(byte[] bytes)
    {
#if NETSTANDARD2_0
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(bytes);
#else
        return SHA256.HashData(bytes);
#endif
    }
}