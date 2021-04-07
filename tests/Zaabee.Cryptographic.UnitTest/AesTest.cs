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
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "Here is the aes vector.", CipherMode.CBC)]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "Here is the aes vector.", CipherMode.ECB)]
        public void AesStringTest(string original, string key, string vector, CipherMode cipherMode)
        {
            var encrypt = original.EncryptByAes(key, vector, cipherMode);
            var decrypt = encrypt.DecryptByAes(key, vector, cipherMode);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "Here is the aes vector.", CipherMode.CBC)]
        [InlineData("Here is some data to encrypt!", "Here is the aes key.", "Here is the aes vector.", CipherMode.ECB)]
        public void AesBytesTest(string original, string key, string vector, CipherMode cipherMode)
        {
            var bKey = AesHelper.Encoding.GetBytes(key);
            var bVector = AesHelper.Encoding.GetBytes(vector);
            var encrypt = original.EncryptByAes(bKey, bVector, cipherMode);
            var decrypt = encrypt.DecryptByAes(bKey, bVector, cipherMode);
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