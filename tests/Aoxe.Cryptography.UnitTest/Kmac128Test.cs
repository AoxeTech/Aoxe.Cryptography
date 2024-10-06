#if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Kmac128Test
{
    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128StringTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToKmac128String(keyBytes, outputLength, customizationBytes), result);
        Assert.Equal(
            readOnlySpan.ToKmac128String(keyBytes, outputLength, customizationBytes),
            result
        );
        Assert.Equal(ms.ToKmac128String(keyBytes, outputLength, customizationBytes), result);
        Assert.Equal(source.ToKmac128String(keyBytes, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public async Task Kmac128AsyncTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(
            (await ms.ToKmac128Async(keyBytes, outputLength, customizationBytes)).ToHexString(),
            result
        );
        ms.TrySeek(0, SeekOrigin.Begin);
        Assert.Equal(
            await ms.ToKmac128StringAsync(keyBytes, outputLength, customizationBytes),
            result
        );
        var memory = new Memory<byte>();
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToKmac128Async(keyBytes, memory, customizationBytes);
        Assert.Empty(memory.ToArray());
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128BytesTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(
            bytes.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
        Assert.True(
            readOnlySpan.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
        Assert.True(ms.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash));
        Assert.True(
            source.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData("aoxe", "this is a key")]
    public void Kmac128FillTest(string source, string key)
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);

        var readOnlySpanResult = new Span<byte>();
        var msResult = new Span<byte>();
        var stringResult = new Span<byte>();

        readOnlySpan.ToKmac128(keyBytes, readOnlySpanResult);
        ms.ToKmac128(keyBytes, msResult);
        source.ToKmac128(keyBytes, stringResult);

        Assert.Empty(readOnlySpanResult.ToArray());
        Assert.Empty(msResult.ToArray());
        Assert.Empty(stringResult.ToArray());
    }
}
#endif
