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
