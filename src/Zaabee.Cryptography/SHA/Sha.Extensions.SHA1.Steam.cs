namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha1(this Stream inputStream) =>
        ShaHelper.ComputeSha1(inputStream);
}