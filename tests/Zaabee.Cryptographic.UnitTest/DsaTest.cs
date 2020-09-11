using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class DsaTest
    {
        [Fact]
        public void Test()
        {
            DsaHelper.Encoding = Encoding.UTF8;
            Assert.Equal(DsaHelper.Encoding, Encoding.UTF8);
        }
        
        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesTest(string original)
        {
            var (privateKey, publicKey) = DsaHelper.GenerateParameters();
            var originalBytes = Encoding.UTF8.GetBytes(original);
            var signature = DsaHelper.CreateSignature(originalBytes, privateKey);
            Assert.True(DsaHelper.VerifySignature(originalBytes, signature, publicKey));
        }
        
        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringTest(string original)
        {
            var (privateKey, publicKey) = DsaHelper.GenerateParameters();
            var signature = DsaHelper.CreateSignature(original, privateKey);
            Assert.True(DsaHelper.VerifySignature(original, signature, publicKey));
        }
    }
}