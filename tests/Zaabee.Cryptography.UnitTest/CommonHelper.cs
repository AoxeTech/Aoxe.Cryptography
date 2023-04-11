namespace Zaabee.Cryptography.UnitTest;

public static class CommonHelper
{
    internal static IEnumerable<byte> HexToBytes(string str)
    {
        var arr = str.Split('-');
        var array = new byte[arr.Length];
        for (var i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);
        return array;
    }
}