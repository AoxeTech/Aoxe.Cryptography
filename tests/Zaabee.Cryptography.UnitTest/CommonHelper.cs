namespace Zaabee.Cryptography.UnitTest;

public static class CommonHelper
{
    internal static IEnumerable<byte> HexToBytes(string hex)
    {
        var numberChars = hex.Length;
        var bytes = new byte[numberChars / 2];
        for (var i = 0; i < numberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        return bytes;
    }
}