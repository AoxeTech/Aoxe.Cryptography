namespace Zaabee.Cryptography.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha256(this Stream inputStream) =>
        ShaHelper.ComputeSha256(inputStream);
}