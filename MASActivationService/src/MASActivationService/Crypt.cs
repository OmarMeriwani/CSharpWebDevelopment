using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.IO;
using System.Security.Cryptography;
namespace MASActivationService
{
    public class Crypt
    {
        //public static System.Security.Cryptography.MD5CryptoServiceProvider hashmd5;
        //public static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public static string encrypt(string word)
        {

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: word,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
            return hashed;
        }
        public static string passwordEncrypt(string inText, string key)
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Dispose();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }
        //Decrypting a string
        public static string passwordDecrypt(string cryptTxt, string key)
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Dispose();
                    }
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }
        //public static string FunForEncrypt(string objText, string objKeycode)
        //{
        //    byte[] objInitVectorBytes = Encoding.UTF8.GetBytes("HR$2pIjHR$2pIj12");
        //    byte[] objPlainTextBytes = Encoding.UTF8.GetBytes(objText);
        //    //PasswordDeriveBytes objPassword = new PasswordDeriveBytes(objKeycode, null);
        //    byte[] objKeyBytes = objKeycode.GetBytes(256 / 8);
        //    RijndaelManaged objSymmetricKey = new RijndaelManaged();
        //    objSymmetricKey.Mode = CipherMode.CBC;
        //    ICryptoTransform objEncryptor = objSymmetricKey.CreateEncryptor(objKeyBytes, objInitVectorBytes);
        //    MemoryStream objMemoryStream = new MemoryStream();
        //    CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objEncryptor, CryptoStreamMode.Write);
        //    objCryptoStream.Write(objPlainTextBytes, 0, objPlainTextBytes.Length);
        //    objCryptoStream.FlushFinalBlock();
        //    byte[] objEncrypted = objMemoryStream.ToArray();
        //    objMemoryStream.Close();
        //    objCryptoStream.Close();
        //    return Convert.ToBase64String(objEncrypted);
        //}

        //public static string FunForDecrypt(string EncryptedText, string Key)
        //{
        //    byte[] objInitVectorBytes = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");
        //    byte[] objDeEncryptedText = Convert.FromBase64String(EncryptedText);
        //    PasswordDeriveBytes objPassword = new PasswordDeriveBytes(Key, null);
        //    byte[] objKeyBytes = objPassword.GetBytes(256 / 8);
        //    RijndaelManaged objSymmetricKey = new RijndaelManaged();
        //    objSymmetricKey.Mode = CipherMode.CBC;
        //    ICryptoTransform objDecryptor = objSymmetricKey.CreateDecryptor(objKeyBytes, objInitVectorBytes);
        //    MemoryStream objMemoryStream = new MemoryStream(objDeEncryptedText);
        //    CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDecryptor, CryptoStreamMode.Read);
        //    byte[] objPlainTextBytes = new byte[objDeEncryptedText.Length];
        //    int objDecryptedByteCount = objCryptoStream.Read(objPlainTextBytes, 0, objPlainTextBytes.Length);
        //    objMemoryStream.Close();
        //    objCryptoStream.Close();
        //    return Encoding.UTF8.GetString(objPlainTextBytes, 0, objDecryptedByteCount);
        //}

        //public static byte[] pwdhash;
        //public static string Encrypt(string OriginalString)
        //{
        //    try
        //    {
        //        des.Mode = CipherMode.ECB;
        //        hashmd5 = new MD5CryptoServiceProvider();
        //        pwdhash = hashmd5.ComputeHash(ASCIIEncoding.GetEncoding(720).GetBytes("omarsirwan"));
        //        des.Key = pwdhash;

        //        byte[] buff = ASCIIEncoding.GetEncoding(720).GetBytes(OriginalString);
        //        return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
        //    }
        //    catch (Exception ex)
        //    {
        //        return "error";
        //    }

        //}
        //public static string Decrypt(string EncryptedString)
        //{

        //    des.Mode = CipherMode.ECB;
        //    hashmd5 = new MD5CryptoServiceProvider();
        //    pwdhash = hashmd5.ComputeHash(ASCIIEncoding.GetEncoding(720).GetBytes("omarsirwan"));
        //    des.Key = pwdhash;

        //    byte[] buff = Convert.FromBase64String(EncryptedString);
        //    try
        //    {
        //        return ASCIIEncoding.GetEncoding(720).GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
        //    }
        //    catch (Exception CryptographicException)
        //    {
        //        return "error";
        //    }
        //}




        //public static string Encrypt(string text, string keyString)
        //{
        //    try
        //    {
        //        using (var md5 = MD5.Create())
        //        {
        //            var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
        //            return Encoding.ASCII.GetString(result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    try
        //    {
        //        //var key = Encoding.UTF8.GetBytes(keyString);
        //        //using (var aesAlg = Aes.Create())
        //        //{
        //        //    using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
        //        //    {
        //        //        using (var msEncrypt = new MemoryStream())
        //        //        {
        //        //            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //        //            using (var swEncrypt = new StreamWriter(csEncrypt))
        //        //            {
        //        //                swEncrypt.Write(text);
        //        //            }
        //        //            var iv = aesAlg.IV;
        //        //            var decryptedContent = msEncrypt.ToArray();
        //        //            var result = new byte[iv.Length + decryptedContent.Length];
        //        //            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        //        //            Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
        //        //            return Convert.ToBase64String(result);
        //        //        }
        //        //    }
        //        //}
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static string Decrypt(string cipherText, string keyString)
        {
            //try
            //{
            //    var fullCipher = Convert.FromBase64String(cipherText);
            //    var iv = new byte[16];
            //    var cipher = new byte[16];
            //    Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            //    Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            //    var key = Encoding.UTF8.GetBytes(keyString);
            //    using (var aesAlg = Aes.Create())
            //    {
            //        using (var decryptor = aesAlg.CreateDecryptor(key, iv))
            //        {
            //            string result;
            //            using (var msDecrypt = new MemoryStream(cipher))
            //            {
            //                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            //                {
            //                    using (var srDecrypt = new StreamReader(csDecrypt))
            //                    {
            //                        result = srDecrypt.ReadToEnd();
            //                    }
            //                }
            //            }
            //            return result;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return "";
        }

    }
}
