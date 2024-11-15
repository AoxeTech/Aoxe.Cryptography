namespace Aoxe.Cryptography.UnitTest;

public class Sha384Test
{
    [Theory]
    [InlineData(
        "aoxe",
        "DEC379C8285F01CFE9C07568888D133392299EC25439DC831EE941041FD899DBEB005DCDE56140B7A8CCE578D4A8EE30"
    )]
    public void Sha384StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha384String(), result);
        Assert.Equal(bytes.ToSha384String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha384String(), result);
        Assert.Equal(str.ToSha384String(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "DEC379C8285F01CFE9C07568888D133392299EC25439DC831EE941041FD899DBEB005DCDE56140B7A8CCE578D4A8EE30"
    )]
    public void Sha384BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToSha384().SequenceEqual(hash));
        Assert.True(bytes.ToSha384(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha384().SequenceEqual(hash));
        Assert.True(str.ToSha384().SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "DEC379C8285F01CFE9C07568888D133392299EC25439DC831EE941041FD899DBEB005DCDE56140B7A8CCE578D4A8EE30"
    )]
    public async Task Sha384StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha384Bytes = await memoryStream.ToSha384Async();
        Assert.True(sha384Bytes.SequenceEqual(result.FromHex()));

        var sha384String = await memoryStream.ToSha384StringAsync();
        Assert.Equal(result, sha384String);
    }
}
