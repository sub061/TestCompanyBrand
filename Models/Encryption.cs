using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CompanyBranding.Models
{
    public static class Encryption
    {
        static TripleDES CreateDES()
        {
            string key = ConfigurationManager.AppSettings["encryptionkey"];
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }


        public static string Encode(string plainText)
        {
            // first we convert the plain text into a byte array
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);

            // use a memory stream to hold the bytes
            MemoryStream myStream = new MemoryStream();

            // create the key and initialization vector using the password
            TripleDES des = CreateDES();

            // create the encoder that will write to the memory stream
            CryptoStream cryptStream = new CryptoStream(myStream, des.CreateEncryptor(), CryptoStreamMode.Write);

            // we now use the crypto stream to write our byte array to the memory stream
            cryptStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptStream.FlushFinalBlock();

            // change the encrypted stream to a printable version of our encrypted string
            return Convert.ToBase64String(myStream.ToArray());
        }

        public static string Decode(string encryptedText)
        {
            // convert our encrypted string to a byte array
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            // create a memory stream to hold the bytes
            MemoryStream myStream = new MemoryStream();

            // create the key and initialization vector using the password
            TripleDES des = CreateDES();

            // create our decoder to write to the stream
            CryptoStream decryptStream = new CryptoStream(myStream, des.CreateDecryptor(), CryptoStreamMode.Write);

            // we now use the crypto stream to the byte array
            decryptStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            decryptStream.FlushFinalBlock();

            // convert our stream to a string value
            return Encoding.Unicode.GetString(myStream.ToArray());
        }


    }
}