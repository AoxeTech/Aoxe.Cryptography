using System.Text;

namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha256Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha256HashBytes(str, encoding);

    public static byte[] ToSha256Bytes(this byte[] bytes) =>
        ShaHelper.GetSha256HashBytes(bytes);
}