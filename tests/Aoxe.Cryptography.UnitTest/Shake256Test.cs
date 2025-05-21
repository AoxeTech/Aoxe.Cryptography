#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Shake256Test
{
    [Theory]
    [InlineData(
        "aoxe",
        64,
        "68556DFFE1D215107DDB642DA5EE495D8F886DB29147B921EBDA3CF112EF38C6C09492E6626870B5BF3A723214601E3E93BB2E6749A784628C92C3402B54459B"
    )]
    public void Shake256StringTest(string str, int outputLength, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToShake256String(outputLength), result);
        Assert.Equal(readOnlySpan.ToShake256String(outputLength), result);
        Assert.Equal(ms.ToShake256String(outputLength), result);
        Assert.Equal(str.ToShake256String(outputLength), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        64,
        "68556DFFE1D215107DDB642DA5EE495D8F886DB29147B921EBDA3CF112EF38C6C09492E6626870B5BF3A723214601E3E93BB2E6749A784628C92C3402B54459B"
    )]
    public async Task Shake256AsyncTest(string str, int outputLength, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal((await ms.ToShake256Async(outputLength)).ToHexString(), result);
        ms.TrySeek(0, SeekOrigin.Begin);
        Assert.Equal(await ms.ToShake256StringAsync(outputLength), result);
        var memory = new Memory<byte>();
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToShake256Async(memory);
        Assert.Empty(memory.ToArray());
    }

    [Theory]
    [InlineData(
        "aoxe",
        64,
        "68556DFFE1D215107DDB642DA5EE495D8F886DB29147B921EBDA3CF112EF38C6C09492E6626870B5BF3A723214601E3E93BB2E6749A784628C92C3402B54459B"
    )]
    public void Shake256BytesTest(string str, int outputLength, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexToBytes();
        Assert.True(bytes.ToShake256(outputLength).SequenceEqual(hash));
        Assert.True(readOnlySpan.ToShake256(outputLength).SequenceEqual(hash));
        Assert.True(ms.ToShake256(outputLength).SequenceEqual(hash));
        Assert.True(str.ToShake256(outputLength).SequenceEqual(hash));
    }

    [Theory]
    [InlineData("aoxe")]
    public void Shake256FillTest(string str)
    {
        var bytes = str.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);

        var readOnlySpanResult = new Span<byte>();
        var msResult = new Span<byte>();
        var stringResult = new Span<byte>();

        readOnlySpan.ToShake256(readOnlySpanResult);
        ms.ToShake256(msResult);
        str.ToShake256(stringResult);

        Assert.Empty(readOnlySpanResult.ToArray());
        Assert.Empty(msResult.ToArray());
        Assert.Empty(stringResult.ToArray());
    }
}
#endif
