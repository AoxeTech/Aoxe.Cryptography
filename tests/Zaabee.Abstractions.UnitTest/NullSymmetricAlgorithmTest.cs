namespace Zaabee.Abstractions.UnitTest;

public class NullSymmetricAlgorithmTest
{
    [Fact]
    public void Encrypt_ByteArray_ShouldReturnClone()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Arrange
        var originalData = new byte[] { 1, 2, 3, 4 };
        var key = new byte[] { };
        var iv = new byte[] { };

        // Act
        var encryptedData = encryption.Encrypt(originalData, key, iv);

        // Assert
        Assert.NotNull(encryptedData);
        Assert.Equal(originalData.Length, encryptedData.Length);
        for (var i = 0; i < originalData.Length; i++)
        {
            Assert.Equal(originalData[i], encryptedData[i]);
        }
    }

    [Fact]
    public void Encrypt_Stream_ShouldReturnMemoryStream()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Arrange
        var originalData = new byte[] { 1, 2, 3, 4 };
        using (var inputStream = new MemoryStream(originalData))
        {
            var key = new byte[] { };
            var iv = new byte[] { };

            // Act
            var encryptedStream = encryption.Encrypt(inputStream, key, iv);

            // Assert
            Assert.NotNull(encryptedStream);
            encryptedStream.Position = 0;
            var encryptedData = new byte[originalData.Length];
            _ = encryptedStream.Read(encryptedData, 0, encryptedData.Length);
            for (var i = 0; i < originalData.Length; i++)
            {
                Assert.Equal(originalData[i], encryptedData[i]);
            }
        }
    }

    [Fact]
    public async Task EncryptAsync_Stream_ShouldReturnMemoryStream()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Arrange
        var originalData = new byte[] { 1, 2, 3, 4 };
        using (var inputStream = new MemoryStream(originalData))
        {
            var key = new byte[] { };
            var iv = new byte[] { };

            // Act
            var encryptedStream = await encryption.EncryptAsync(inputStream, key, iv);

            // Assert
            Assert.NotNull(encryptedStream);
            encryptedStream.Position = 0;
            var encryptedData = new byte[originalData.Length];
            _ = encryptedStream.Read(encryptedData, 0, encryptedData.Length);
            for (var i = 0; i < originalData.Length; i++)
            {
                Assert.Equal(originalData[i], encryptedData[i]);
            }
        }
    }

    // Add similar tests for Decrypt methods...

    [Fact]
    public void GenerateKey_ShouldReturnEmptyArray()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Act
        var key = encryption.GenerateKey();

        // Assert
        Assert.NotNull(key);
        Assert.Empty(key);
    }

    [Fact]
    public void GenerateVector_ShouldReturnEmptyArray()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Act
        var vector = encryption.GenerateVector();

        // Assert
        Assert.NotNull(vector);
        Assert.Empty(vector);
    }

    [Fact]
    public void GenerateKeyAndVector_ShouldReturnEmptyArrays()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Act
        var (key, vector) = encryption.GenerateKeyAndVector();

        // Assert
        Assert.NotNull(key);
        Assert.Empty(key);
        Assert.NotNull(vector);
        Assert.Empty(vector);
    }

    [Fact]
    public void Decrypt_ByteArray_ShouldReturnClone()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Arrange
        var originalData = new byte[] { 1, 2, 3, 4 };
        var key = new byte[] { };
        var iv = new byte[] { };

        // Act
        var decryptedData = encryption.Decrypt(originalData, key, iv);

        // Assert
        Assert.NotNull(decryptedData);
        Assert.Equal(originalData.Length, decryptedData.Length);
        for (var i = 0; i < originalData.Length; i++)
        {
            Assert.Equal(originalData[i], decryptedData[i]);
        }
    }

    [Fact]
    public void Decrypt_Stream_ShouldDecryptCorrectly()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Arrange
        var originalData = new byte[] { 1, 2, 3, 4 };
        using (var inputStream = new MemoryStream(originalData))
        {
            var key = new byte[] { };
            var iv = new byte[] { };

            // Act
            var encryptedStream = encryption.Decrypt(inputStream, key, iv);

            // Assert
            Assert.NotNull(encryptedStream);
            encryptedStream.Position = 0;
            var encryptedData = new byte[originalData.Length];
            _ = encryptedStream.Read(encryptedData, 0, encryptedData.Length);
            for (var i = 0; i < originalData.Length; i++)
            {
                Assert.Equal(originalData[i], encryptedData[i]);
            }
        }
    }

    [Fact]
    public async Task DecryptAsync_Stream_ShouldDecryptCorrectly()
    {
        var encryption = new NullSymmetricAlgorithm();

        // Arrange
        var originalData = new byte[] { 1, 2, 3, 4 };
        using (var inputStream = new MemoryStream(originalData))
        {
            var key = new byte[] { };
            var iv = new byte[] { };

            // Act
            var encryptedStream = await encryption.DecryptAsync(inputStream, key, iv);

            // Assert
            Assert.NotNull(encryptedStream);
            encryptedStream.Position = 0;
            var encryptedData = new byte[originalData.Length];
            _ = encryptedStream.Read(encryptedData, 0, encryptedData.Length);
            for (var i = 0; i < originalData.Length; i++)
            {
                Assert.Equal(originalData[i], encryptedData[i]);
            }
        }
    }
}