namespace Zaabee.Cryptographic.UnitTest;

public class TripleDesTest
{
    [Fact]
    public void Test()
    {
        TripleDesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(TripleDesHelper.Encoding, Encoding.UTF8);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "Here is the triple des key.", "Here is the triple des vector.",
        CipherMode.CBC)]
    [InlineData("Here is some data to encrypt!", "Here is the triple des key.", "Here is the triple des vector.",
        CipherMode.ECB)]
    public void TripleDesStringTest(string original, string key, string vector, CipherMode cipherMode)
    {
        var encrypt = original.EncryptByTripleDes(key, vector, cipherMode);
        var decrypt = encrypt.DecryptByTripleDes(key, vector, cipherMode);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "Here is the triple des key.", "Here is the triple des vector.",
        CipherMode.CBC)]
    [InlineData("Here is some data to encrypt!", "Here is the triple des key.", "Here is the triple des vector.",
        CipherMode.ECB)]
    public void TripleDesBytesTest(string original, string key, string vector, CipherMode cipherMode)
    {
        var bKey = TripleDesHelper.Encoding.GetBytes(key);
        var bVector = TripleDesHelper.Encoding.GetBytes(vector);
        var encrypt = original.EncryptByTripleDes(bKey, bVector, cipherMode);
        var decrypt = encrypt.DecryptByTripleDes(bKey, bVector, cipherMode);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "Here is the triple des key.", "01234567890123456789",
        new byte[] { })]
    public void TripleDesStringNullTest(string original, string key, string vector, byte[] encrypted)
    {
        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Encrypt(null, key, vector));
        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Encrypt(original, null, vector));

        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Decrypt(null, key, vector));
        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Decrypt(encrypted, null, vector));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", new byte[] { }, new byte[] { }, new byte[] { })]
    public void TripleDesByteNullTest(string original, byte[] key, byte[] vector, byte[] encrypted)
    {
        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Encrypt(null, key, vector));
        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Encrypt(original, null, vector));

        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Decrypt(null, key, vector));
        Assert.Throws<ArgumentNullException>(() => TripleDesHelper.Decrypt(encrypted, null, vector));
    }
}