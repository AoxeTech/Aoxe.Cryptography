namespace Zaabee.Cryptography.UnitTest;

public class SymmetricAlgorithmTest
{
    [Fact]
    public async Task NullAlgorithmTestAsync()
    {
        await Tests(new NullSymmetricAlgorithm());
    }

    [Fact]
    public async Task AesAlgorithmTestAsync()
    {
        await Tests(new AesAlgorithm());
    }

    [Fact]
    public async Task DesAlgorithmTestAsync()
    {
        await Tests(new DesAlgorithm());
    }

    [Fact]
    public async Task Rc2AlgorithmTestAsync()
    {
        await Tests(new Rc2Algorithm());
    }

    [Fact]
    public async Task TripleDesAlgorithmTestAsync()
    {
        await Tests(new TripleDesAlgorithm());
    }

    private static async Task Tests(ISymmetricAlgorithm symmetricAlgorithm)
    {
        GenerateKeyTest(symmetricAlgorithm);
        GenerateVectorTest(symmetricAlgorithm);
        GenerateKeyAndVectorTest(symmetricAlgorithm);
        BytesTest(symmetricAlgorithm);
        StreamTest(symmetricAlgorithm);
        await StreamAsyncTest(symmetricAlgorithm);
    }

    private static void BytesTest(ISymmetricAlgorithm symmetricAlgorithm)
    {
        const string str = "Zaabee";
        var bytes = str.GetUtf8Bytes();
        var (key, vector) = symmetricAlgorithm.GenerateKeyAndVector();
        var encryptedBytes = symmetricAlgorithm.Encrypt(bytes, key, vector);
        var decryptedBytes = symmetricAlgorithm.Decrypt(encryptedBytes, key, vector);
        var decryptedStr = decryptedBytes.GetStringByUtf8();
        Assert.Equal(str, decryptedStr);
    }

    private static void StreamTest(ISymmetricAlgorithm symmetricAlgorithm)
    {
        const string str = "Zaabee";
        var ms = new MemoryStream(str.GetUtf8Bytes());
        var (key, vector) = symmetricAlgorithm.GenerateKeyAndVector();
        var encryptedStream = symmetricAlgorithm.Encrypt(ms, key, vector);
        var decryptedStream = symmetricAlgorithm.Decrypt(encryptedStream, key, vector);
        var decryptedStr = decryptedStream.ToArray().GetStringByUtf8();
        Assert.Equal(str, decryptedStr);
    }

    private static async Task StreamAsyncTest(ISymmetricAlgorithm symmetricAlgorithm)
    {
        const string str = "Zaabee";
        var ms = new MemoryStream(str.GetUtf8Bytes());
        var (key, vector) = symmetricAlgorithm.GenerateKeyAndVector();
        var encryptedStream = await symmetricAlgorithm.EncryptAsync(ms, key, vector);
        var decryptedStream = await symmetricAlgorithm.DecryptAsync(encryptedStream, key, vector);
        var decryptedStr = decryptedStream.ToArray().GetStringByUtf8();
        Assert.Equal(str, decryptedStr);
    }

    private static void GenerateKeyAndVectorTest(ISymmetricAlgorithm symmetricAlgorithm)
    {
        var (key, vector) = symmetricAlgorithm.GenerateKeyAndVector();
        Assert.NotNull(key);
        Assert.NotNull(vector);
    }

    private static void GenerateKeyTest(ISymmetricAlgorithm symmetricAlgorithm)
    {
        var key = symmetricAlgorithm.GenerateKey();
        Assert.NotNull(key);
    }

    private static void GenerateVectorTest(ISymmetricAlgorithm symmetricAlgorithm)
    {
        var vector = symmetricAlgorithm.GenerateVector();
        Assert.NotNull(vector);
    }
}