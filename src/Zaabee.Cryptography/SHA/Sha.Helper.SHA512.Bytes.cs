using System.Text;

namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
    public static byte[] GetSha512HashBytes(
        string str,
        Encoding? encoding = null) =>
        GetSha512HashBytes((encoding ?? Encoding).GetBytes(str));

    public static byte[] GetSha512HashBytes(byte[] bytes)
    {
#if NETSTANDARD2_0
        using var sha512 = SHA512.Create();
        return sha512.ComputeHash(bytes);
#else
        return SHA512.HashData(bytes);
#endif
    }
}