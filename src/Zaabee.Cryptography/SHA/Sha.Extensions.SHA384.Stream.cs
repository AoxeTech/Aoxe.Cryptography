namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha384(this Stream inputStream) =>
        ShaHelper.ComputeSha384(inputStream);
}