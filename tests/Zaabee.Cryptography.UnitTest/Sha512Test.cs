namespace Zaabee.Cryptography.UnitTest;

public class Sha512Test
{
    [Theory]
    [InlineData("apple",
        "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
    public void Sha512StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha512(), result);
    }

    [Theory]
    [InlineData("apple",
        "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
    public void Sha512BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha512().SequenceEqual(CommonHelper.HexToBytes(result)));
        Assert.True(bytes.ToSha512(0, bytes.Length).SequenceEqual(CommonHelper.HexToBytes(result)));
    }

    [Theory]
    [InlineData("apple",
        "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
    public void Sha512StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha512().SequenceEqual(CommonHelper.HexToBytes(result)));
    }

#if !NET48
    [Theory]
    [InlineData("apple",
        "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
    public async Task Sha512StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var sha512Bytes = await memoryStream.ToSha512Async();
        Assert.True(sha512Bytes.SequenceEqual(CommonHelper.HexToBytes(result)));
    }
#endif
}