using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class DesTest
    {
        [Fact]
        public void Test()
        {
            DesHelper.Encoding = Encoding.UTF8;
            Assert.Equal(DesHelper.Encoding, Encoding.UTF8);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the des key.", "Here is the des vector.", CipherMode.CBC)]
        [InlineData("Here is some data to encrypt!", "Here is the des key.", "Here is the des vector.", CipherMode.ECB)]
        public void DesStringTest(string original, string key, string vector, CipherMode cipherMode)
        {
            var encrypt = original.EncryptByDes(key, vector, cipherMode);
            var decrypt = encrypt.DecryptByDes(key, vector, cipherMode);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the des key.", "Here is the des vector.", CipherMode.CBC)]
        [InlineData("Here is some data to encrypt!", "Here is the des key.", "Here is the des vector.", CipherMode.ECB)]
        public void DesBytesTest(string original, string key, string vector, CipherMode cipherMode)
        {
            var bKey = DesHelper.Encoding.GetBytes(key);
            var bVector = DesHelper.Encoding.GetBytes(vector);
            var encrypt = original.EncryptByDes(bKey, bVector, cipherMode);
            var decrypt = encrypt.DecryptByDes(bKey, bVector, cipherMode);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "Here is the des key.", "01234567890123456789", new byte[] { })]
        public void DesStringNullTest(string original, string key, string vector, byte[] encrypted)
        {
            Assert.Throws<ArgumentNullException>(() => DesHelper.Encrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => DesHelper.Encrypt(original, null, vector));

            Assert.Throws<ArgumentNullException>(() => DesHelper.Decrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => DesHelper.Decrypt(encrypted, null, vector));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", new byte[] { }, new byte[] { }, new byte[] { })]
        public void DesByteNullTest(string original, byte[] key, byte[] vector, byte[] encrypted)
        {
            Assert.Throws<ArgumentNullException>(() => DesHelper.Encrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => DesHelper.Encrypt(original, null, vector));

            Assert.Throws<ArgumentNullException>(() => DesHelper.Decrypt(null, key, vector));
            Assert.Throws<ArgumentNullException>(() => DesHelper.Decrypt(encrypted, null, vector));
        }
    }
}