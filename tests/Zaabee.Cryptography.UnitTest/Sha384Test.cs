namespace Zaabee.Cryptography.UnitTest;

public class Sha384Test
{
    [Theory]
    [InlineData("apple",
        "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
    public void Sha384StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha384(), result);
    }

    [Theory]
    [InlineData("apple",
        "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
    public void Sha384BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha384().SequenceEqual(CommonHelper.HexToBytes(result)));
        Assert.True(bytes.ToSha384(0, bytes.Length).SequenceEqual(CommonHelper.HexToBytes(result)));
    }

    [Theory]
    [InlineData("apple",
        "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
    public void Sha384StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha384().SequenceEqual(CommonHelper.HexToBytes(result)));
    }

#if !NET48
    [Theory]
    [InlineData("apple",
        "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
    public async Task Sha384StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var sha384Bytes = await memoryStream.ToSha384Async();
        Assert.True(sha384Bytes.SequenceEqual(CommonHelper.HexToBytes(result)));
    }
#endif
}