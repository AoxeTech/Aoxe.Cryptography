namespace Zaabee.Cryptography.UnitTest;

public class Md5Test
{
    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public void ComputeHashStringTest(string str, string result)
    {
        Assert.Equal(str.ToMd5(), result);
    }

    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void ComputeHashBytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToMd5().SequenceEqual(HexToBytes(result)));
        Assert.True(bytes.ToMd5(0, bytes.Length).SequenceEqual(HexToBytes(result)));
    }

    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void ComputeHashStreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToMd5().SequenceEqual(HexToBytes(result)));
    }

#if !NET48
    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public async Task ComputeHashStreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var md5Bytes = await memoryStream.ToMd5Async();
        Assert.True(md5Bytes.SequenceEqual(HexToBytes(result)));
    }
#endif

    private static IEnumerable<byte> HexToBytes(string str)
    {
        var arr = str.Split('-');
        var array = new byte[arr.Length];
        for (var i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);
        return array;
    }
}