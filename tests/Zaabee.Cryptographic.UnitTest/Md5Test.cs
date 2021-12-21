namespace Zaabee.Cryptographic.UnitTest;

public class Md5Test
{
    [Fact]
    public void Test()
    {
        Md5Helper.Encoding = Encoding.UTF8;
        Assert.Equal(Md5Helper.Encoding, Encoding.UTF8);
    }

    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void ComputeHashStringTest(string str, string result)
    {
        Assert.Equal(str.ToMd5String(), result);
    }

    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void ComputeHashBytesTest(string str, string result)
    {
        Assert.True(str.ToMd5Bytes().SequenceEqual(HexToBytes(result)));
    }

    [Fact]
    public void NullTest()
    {
        string str = null;
        byte[] bytes = null;
            
        Assert.Throws<ArgumentNullException>(() => str.ToMd5String());
        Assert.Throws<ArgumentNullException>(() => bytes.ToMd5String());
            
        Assert.Throws<ArgumentNullException>(() => str.ToMd5Bytes());
        Assert.Throws<ArgumentNullException>(() => bytes.ToMd5Bytes());
    }

    private static IEnumerable<byte> HexToBytes(string str)
    {
        var arr = str.Split('-');
        var array = new byte[arr.Length];
        for (var i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);
        return array;
    }
}