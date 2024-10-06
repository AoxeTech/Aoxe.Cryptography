#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Shake128Test
{
    [Theory]
    [InlineData("aoxe", 32, "081AEBBD51DF796DE62D0A3041B6D9508055FD55018A16B50E64468C86ABC40A")]
    public void Shake128StringTest(string str, int outputLength, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToShake128String(outputLength), result);
        Assert.Equal(readOnlySpan.ToShake128String(outputLength), result);
        Assert.Equal(ms.ToShake128String(outputLength), result);
        Assert.Equal(str.ToShake128String(outputLength), result);
    }

    [Theory]
    [InlineData("aoxe", 32, "081AEBBD51DF796DE62D0A3041B6D9508055FD55018A16B50E64468C86ABC40A")]
    public async Task Shake128AsyncTest(string str, int outputLength, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal((await ms.ToShake128Async(outputLength)).ToHexString(), result);
        ms.TrySeek(0, SeekOrigin.Begin);
        Assert.Equal(await ms.ToShake128StringAsync(outputLength), result);
        var memory = new Memory<byte>();
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToShake128Async(memory);
        Assert.Empty(memory.ToArray());
    }

    [Theory]
    [InlineData("aoxe", 32, "081AEBBD51DF796DE62D0A3041B6D9508055FD55018A16B50E64468C86ABC40A")]
    public void Shake128BytesTest(string str, int outputLength, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToShake128(outputLength).SequenceEqual(hash));
        Assert.True(readOnlySpan.ToShake128(outputLength).SequenceEqual(hash));
        Assert.True(ms.ToShake128(outputLength).SequenceEqual(hash));
        Assert.True(str.ToShake128(outputLength).SequenceEqual(hash));
    }

    [Theory]
    [InlineData("aoxe")]
    public void Shake128FillTest(string str)
    {
        var bytes = str.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);

        var readOnlySpanResult = new Span<byte>();
        var msResult = new Span<byte>();
        var stringResult = new Span<byte>();

        readOnlySpan.ToShake128(readOnlySpanResult);
        ms.ToShake128(msResult);
        str.ToShake128(stringResult);

        Assert.Empty(readOnlySpanResult.ToArray());
        Assert.Empty(msResult.ToArray());
        Assert.Empty(stringResult.ToArray());
    }
}
#endif
