namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha256(this Stream inputStream) =>
        ShaHelper.ComputeSha256(inputStream);
}