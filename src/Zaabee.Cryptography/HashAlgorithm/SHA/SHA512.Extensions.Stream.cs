namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaExtensions
{
    public static byte[] ToSha512(this Stream inputStream) =>
        ShaHelper.ComputeSha512(inputStream);
}