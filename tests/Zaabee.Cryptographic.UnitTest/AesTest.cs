using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class AesTest
    {
        [Fact]
        public void Test()
        {
            AesHelper.Encoding = Encoding.UTF8;
            Assert.Equal(AesHelper.Encoding, Encoding.UTF8);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "Here is the aes vector.")]
        [InlineData("Here is some data to encrypt!", "", "Here is the aes vector.")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key which length more than 32.",
            "Here is the aes vector.")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.",
            "Here is the aes vector which length more than 16.")]
        public void AesStringTest(string original, string key, string vector)
        {
            var encrypt = AesHelper.Encrypt(original, key, vector);
            var decrypt = AesHelper.Decrypt(encrypt, key, vector);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.")]
        [InlineData("Here is some data to encrypt!", "")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key which length more than 32.")]
        public void AesEcbStringTest(string original, string key)
        {
            var encrypt = AesHelper.Encrypt(original, key, null, CipherMode.ECB);
            var decrypt = AesHelper.Decrypt(encrypt, key, null, CipherMode.ECB);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "Here is the aes vector.")]
        [InlineData("Here is some data to encrypt!", "", "Here is the aes vector.")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key which length more than 32.",
            "Here is the aes vector.")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.",
            "Here is the aes vector which length more than 16.")]
        public void AesBytesTest(string original, string key, string vector)
        {
            var bKey = Encoding.UTF8.GetBytes(key);
            var bVector = Encoding.UTF8.GetBytes(vector);
            var encrypt = AesHelper.Encrypt(original, bKey, bVector);
            var decrypt = AesHelper.Decrypt(encrypt, bKey, bVector);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.")]
        [InlineData("Here is some data to encrypt!", "")]
        [InlineData("Here is some data to encrypt!", "Here is the aes key which length more than 32.")]
        public void AesEcbBytesTest(string original, string key)
        {
            var bKey = Encoding.UTF8.GetBytes(key);
            var encrypt = AesHelper.Encrypt(original, bKey, null, CipherMode.ECB);
            var decrypt = AesHelper.Decrypt(encrypt, bKey, null, CipherMode.ECB);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "01234567890123456789", new byte[] { })]
        public void AesStringNullTest(string original, string key, string vector, byte[] encrypted)
        {
            Assert.Throws<ArgumentNullException>(() => AesHelper.Encrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => AesHelper.Encrypt(original, null, vector));

            Assert.Throws<ArgumentNullException>(() => AesHelper.Decrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => AesHelper.Decrypt(encrypted, null, vector));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", new byte[] { }, new byte[] { }, new byte[] { })]
        public void AesByteNullTest(string original, byte[] key, byte[] vector, byte[] encrypted)
        {
            Assert.Throws<ArgumentNullException>(() => AesHelper.Encrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => AesHelper.Encrypt(original, null, vector));

            Assert.Throws<ArgumentNullException>(() => AesHelper.Decrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => AesHelper.Decrypt(encrypted, null, vector));
        }
    }
}