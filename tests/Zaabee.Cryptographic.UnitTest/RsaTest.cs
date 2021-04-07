using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class RsaTest
    {
        [Fact]
        public void Test()
        {
            RsaHelper.Encoding = Encoding.UTF8;
            RsaHelper.Padding = RSAEncryptionPadding.OaepSHA256;
            Assert.Equal(RsaHelper.Encoding, Encoding.UTF8);
            Assert.Equal(RsaHelper.Padding, RSAEncryptionPadding.OaepSHA256);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesTest(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var originalBytes = RsaHelper.Encoding.GetBytes(original);
            var encryptBytes = originalBytes.EncryptByRsa(publicKey);
            var decryptBytes = encryptBytes.DecryptByRsa(privateKey);
            Assert.True(Equal(originalBytes, decryptBytes));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringTest(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var encryptBytes = original.EncryptByRsa(publicKey);
            var decrypt = encryptBytes.DecryptToStringByRsa(privateKey);
            Assert.Equal(original, decrypt);
        }

        private static bool Equal(byte[] first, byte[] second)
        {
            if (first is null || second is null) return false;
            if (first.Length != second.Length) return false;
            return !first.Where((t, i) => t != second[i]).Any();
        }
    }
}