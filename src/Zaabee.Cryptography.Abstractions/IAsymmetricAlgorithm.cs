namespace Zaabee.Cryptography.Abstractions;

public interface IAsymmetricAlgorithm
{
}

public interface IAsymmetricAlgorithmEncryption : IAsymmetricAlgorithm
{
    byte[] Encrypt(byte[] bytes, byte[] publicKey);
    byte[] Encrypt(Stream inputStream, byte[] publicKey);
    ValueTask<byte[]> EncryptAsync(Stream inputStream, byte[] publicKey);
    byte[] Decrypt(byte[] bytes, byte[] privateKey);
    byte[] Decrypt(Stream inputStream, byte[] privateKey);
    ValueTask<byte[]> DecryptAsync(Stream inputStream, byte[] privateKey);
}

public interface IAsymmetricAlgorithmSignature : IAsymmetricAlgorithm
{
    byte[] SignData(byte[] data, byte[] privateKey, HashAlgorithmName? hashAlgorithmName = null);
    bool VerifyData(byte[] data, byte[] signature, byte[] publicKey, HashAlgorithmName? hashAlgorithmName = null);
    byte[] SignHash(byte[] hash, byte[] privateKey);
    bool VerifyHash(byte[] hash, byte[] signature, byte[] publicKey);
}

public interface IAsymmetricAlgorithmKeyAgreement : IAsymmetricAlgorithm
{
}