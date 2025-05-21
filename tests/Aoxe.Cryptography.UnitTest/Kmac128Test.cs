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
    public void BytesToKmac128StringTest(
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

        Assert.Equal(bytes.ToKmac128String(keyBytes, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void ReadOnlySpanToKmac128StringWithBytesKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var customizationBytes = customization.GetUtf8Bytes();

        Assert.Equal(
            readOnlySpan.ToKmac128String(keyBytes, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void ReadOnlySpanToKmac128StringWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var customizationBytes = customization.GetUtf8Bytes();

        Assert.Equal(
            readOnlySpan.ToKmac128String(keySpan, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void StreamToKmac128StringWithBytesKeyTest(
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

        Assert.Equal(ms.ToKmac128String(keyBytes, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void StreamToKmac128StringWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        Assert.Equal(ms.ToKmac128String(keySpan, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void StringToKmac128StringTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();

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
    public async Task StreamToKmac128BytesWithBytesKeyAsyncTest(
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
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public async Task StreamToKmac128StringWithBytesKeyAsyncTest(
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
            await ms.ToKmac128StringAsync(keyBytes, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public async Task StreamToKmac128MemoryWithBytesKeyAsyncTest(
        string source,
        string key,
        string customization,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var memory = new Memory<byte>(new byte[32]);
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToKmac128Async(keyBytes, memory, customizationBytes);
        Assert.Equal(memory.ToArray().ToHexString(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public async Task StreamToKmac128BytesWithMemoryKeyAsyncTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keyMemory = new ReadOnlyMemory<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        Assert.Equal(
            (await ms.ToKmac128Async(keyMemory, outputLength, customizationBytes)).ToHexString(),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public async Task StreamToKmac128StringWithMemoryKeyAsyncTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keyMemory = new ReadOnlyMemory<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        Assert.Equal(
            await ms.ToKmac128StringAsync(keyMemory, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public async Task StreamToKmac128MemoryWithMemoryKeyAsyncTest(
        string source,
        string key,
        string customization,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var keyMemory = new ReadOnlyMemory<byte>(keyBytes);

        var customizationBytes = customization.GetUtf8Bytes();

        var memorySpan = new Memory<byte>(new byte[32]);
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToKmac128Async(keyMemory, memorySpan, customizationBytes);
        Assert.Equal(memorySpan.ToArray().ToHexString(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void BytesToKmac128BytesWithBytesKeyTest(
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
        var hash = result.FromHexToBytes();

        Assert.True(
            bytes.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void ReadOnlySpanToKmac128BytesWithBytesKeyTest(
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
        var hash = result.FromHexToBytes();

        Assert.True(
            readOnlySpan.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void StreamToKmac128BytesWithBytesKeyTest(
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
        var hash = result.FromHexToBytes();

        Assert.True(ms.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void StringToKmac128BytesWithBytesKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var hash = result.FromHexToBytes();

        Assert.True(
            source.ToKmac128(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void ReadOnlySpanToKmac128BytesWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var hash = result.FromHexToBytes();

        Assert.True(
            readOnlySpan.ToKmac128(keySpan, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        32,
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void StreamToKmac128BytesWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexToBytes();

        Assert.True(ms.ToKmac128(keySpan, outputLength, customizationBytes).SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128SpanFillWithBytesKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);

        var keyBytes = key.GetUtf8Bytes();

        var readOnlySpanResultWitBytesKey = new Span<byte>(new byte[32]);

        readOnlySpan.ToKmac128(keyBytes, readOnlySpanResultWitBytesKey);

        var hash = result.FromHexToBytes();

        Assert.Equal(readOnlySpanResultWitBytesKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128StreamFillWithBytesKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var msResultWitBytesKey = new Span<byte>(new byte[32]);

        ms.ToKmac128(keyBytes, msResultWitBytesKey);

        var hash = result.FromHexToBytes();

        Assert.Equal(msResultWitBytesKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128StringFillWithBytesKeyTest(string source, string key, string result)
    {
        var keyBytes = key.GetUtf8Bytes();
        var stringResultWitBytesKey = new Span<byte>(new byte[32]);
        source.ToKmac128(keyBytes, stringResultWitBytesKey);

        var hash = result.FromHexToBytes();

        Assert.Equal(stringResultWitBytesKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128SpanFillWithSpanKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);

        var readOnlySpanResultBySpanKey = new Span<byte>(new byte[32]);

        readOnlySpan.ToKmac128(keySpan, readOnlySpanResultBySpanKey);

        var hash = result.FromHexToBytes();

        Assert.Equal(readOnlySpanResultBySpanKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128StreamFillWithSpanKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);

        var msResultBySpanKey = new Span<byte>(new byte[32]);
        ms.ToKmac128(keySpan, msResultBySpanKey);

        var hash = result.FromHexToBytes();

        Assert.Equal(msResultBySpanKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "3CAAFDCE3A7C7E0FE10F1DCDF0177B66CE8E617B3AF624CB0E6B9257376EA270"
    )]
    public void Kmac128StringFillWithSpanKeyTest(string source, string key, string result)
    {
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);

        var stringResultBySpanKey = new Span<byte>(new byte[32]);

        source.ToKmac128(keySpan, stringResultBySpanKey);

        var hash = result.FromHexToBytes();

        Assert.Equal(stringResultBySpanKey.ToArray(), hash);
    }
}
#endif
