using System.Text;

namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha512Bytes(
        this string str,
        Encoding? encoding = null) =>
        ShaHelper.GetSha512HashBytes(str, encoding);

    public static byte[] ToSha512Bytes(this byte[] bytes) =>
        ShaHelper.GetSha512HashBytes(bytes);
}