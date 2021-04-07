# Zaabee.Cryptographic

The wraps and extension methods of AES/MD5/SHA/RSA/DSA/ECDSA/DES/TripleDES

## Quick Start

### MD5

The result length must be an even number and greater than 0 and less than or equal to 32.

```CSharp
var apple = "apple";
//1F3870BE274F6C49B3E31A0C6728957F
var result0 = apple.ToMd5();
//1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F
var result1 = apple.ToMd5(isUpper:true, isIncludeHyphen:true);
//274F6C49B3E31A0C
var result0 = apple.ToMd5(resultLength:16);
//27-4f-6c-49-b3-e3-1a-0c
var result1 = apple.ToMd5(isUpper:false, isIncludeHyphen:true, resultLength:16);
```

### SHA

Also the extension methods have params which named "isUpper" and "isIncludeHyphen" like the Md5 extension methods.

```CSharp
var apple = "apple";
//D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940
var sha1 = apple.ToSha1();
//3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B
var sha256 = apple.ToSha256();
//3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F
var sha384 = apple.ToSha384();
//844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2
var sha512 = apple.ToSha512();
```

### AES

```CSharp
var original = "Here is some data to encrypt!";
//The key will be resized to 32 size when encrypting or decrypting.
var key = "0123456789";
//The vector will be resized to 16 size when encrypting or decrypting.
var vector = "abcdefg";
//Default cipher mode is CBC
var encrypt = original.EncryptByAes(key, vector);
var decrypt = encrypt.DecryptByAes(key, vector);
//Or you can use ECB
var ecbEncrypt = original.EncryptByAes(key, cipherMode: CipherMode.ECB);
var ecbDecrypt = encrypt.DecryptByAes(key, cipherMode: CipherMode.ECB);
```

### DES

```CSharp
var original = "Here is some data to encrypt!";
//The key will be resized to 8 size when encrypting or decrypting.
var key = "0123456789";
//The vector will be resized to 8 size when encrypting or decrypting.
var vector = "abcdefg";
//Default cipher mode is CBC
var encrypt = original.EncryptByDes(key, vector);
var decrypt = encrypt.DecryptByDes(key, vector);
//Or you can use ECB
var ecbEncrypt = original.EncryptByDes(key, cipherMode: CipherMode.ECB);
var ecbDecrypt = encrypt.DecryptByDes(key, cipherMode: CipherMode.ECB);
```

### TripleDES

```CSharp
var original = "Here is some data to encrypt!";
//The key will be resized to 24 size when encrypting or decrypting.
var key = "0123456789";
//The vector will be resized to 8 size when encrypting or decrypting.
var vector = "abcdefg";
//Default cipher mode is CBC
var encrypt = original.EncryptByTripleDes(key, vector);
var decrypt = encrypt.DecryptByTripleDes(key, vector);
//Or you can use ECB
var ecbEncrypt = original.EncryptByTripleDes(key, cipherMode: CipherMode.ECB);
var ecbDecrypt = encrypt.DecryptByTripleDes(key, cipherMode: CipherMode.ECB);
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
