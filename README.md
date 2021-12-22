# Zaabee.Cryptographic

The wraps and extension methods of AES/MD5/SHA/RSA/DSA/ECDSA/DES/TripleDES

## Quick Start

### MD5

```CSharp
var apple = "apple";
var md5String = apple.ToMd5String();
var md5Bytes = apple.ToMd5Bytes();
```

### SHA

```CSharp
var apple = "apple";
//D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40
var sha1String = apple.ToSha1String();
var sha1Bytes = apple.ToSha1Bytes();
//3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B
var sha256String = apple.ToSha256String();
var sha256Bytes = apple.ToSha256Bytes();
//3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F
var sha384String = apple.ToSha384String();
var sha384Bytes = apple.ToSha384Bytes();
//84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2
var sha512String = apple.ToSha512String();
var sha512Bytes = apple.ToSha512Bytes();
```

### AES

```CSharp
var original = "Here is some data to encrypt!";
//The key will be resized to 32 size when encrypting or decrypting.
var key = "Here is the key.";
//The vector will be resized to 16 size when encrypting or decrypting.
var vector = "Here is the vector.";
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByAes(key, vector);
var decrypt = encrypt.DecryptByAes(key, vector);
```

### DES

```CSharp
var original = "Here is some data to encrypt!";
//The key will be resized to 8 size when encrypting or decrypting.
var key = "Here is the key.";
//The vector will be resized to 8 size when encrypting or decrypting.
var vector = "abcdefg";
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByDes(key, vector);
var decrypt = encrypt.DecryptByDes(key, vector);
```

### TripleDES

```CSharp
var original = "Here is some data to encrypt!";
//The key will be resized to 24 size when encrypting or decrypting.
var key = "Here is the key.";
//The vector will be resized to 8 size when encrypting or decrypting.
var vector = "Here is the vector.";
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByTripleDes(key, vector);
var decrypt = encrypt.DecryptByTripleDes(key, vector);
```

### RSA

The default padding is OaepSHA256 and the default encoding is utf8.

```CSharp
var original = "Here is some data to encrypt!";
var (privateKey, publicKey) = RsaHelper.GenerateParameters();
var encryptBytes = original.EncryptByRsa(publicKey);
var decryptBytes = encryptBytes.DecryptByRsa(privateKey);
var decrypt = RsaHelper.Encoding.GetString(decryptBytes);
//True
var result = original == decrypt;
```

### ECDSA

The default encoding is utf8.

```CSharp
var original = "Here is some data to encrypt!";
```

```CSharp
//SignData
var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
var originalBytes = EcdsaHelper.Encoding.GetBytes(original);
var signBytes = originalBytes.SignDataByEcdsa(privateKey, hashAlgorithm);
//True
var result = originalBytes.VerifyDataByEcdsa(signBytes, publicKey, hashAlgorithm);
```

```CSharp
//SignHash
var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
var originalBytes = EcdsaHelper.Encoding.GetBytes(original);
var signBytes = originalBytes.SignHashByEcdsa(privateKey);
//True
var result = originalBytes.VerifyHashByEcdsa(signBytes, publicKey);
```

### DSA

The default encoding is utf8.

```CSharp
var (privateKey, publicKey) = DsaHelper.GenerateParameters();
var originalBytes = DsaHelper.Encoding.GetBytes(original);
var signature = originalBytes.CreateSignatureByDsa(privateKey);
//True
var result = originalBytes.VerifySignatureByDsa(signature, publicKey);
```
