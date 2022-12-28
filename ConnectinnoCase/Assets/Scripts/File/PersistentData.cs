using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;


public static class PersistentData
{
    public static string GetAbsolutePath(string relativePath)
    {
        return Path.Combine(Application.persistentDataPath, relativePath);
    }

    public static byte[] ReadBinary(string relativePath)
    {
        return FileIO.ReadBinary(GetAbsolutePath(relativePath));
    }
    

    public static bool ReadBinary(string relativePath, long fileOffset, byte[] buffer, int bufferOffset,
        int numberOfBytes)
    {
        return FileIO.ReadBinary(GetAbsolutePath(relativePath), fileOffset, buffer, bufferOffset, numberOfBytes);
    }

    public static void WriteBinary(string relativePath, byte[] data)
    {
        FileIO.WriteBinary(GetAbsolutePath(relativePath), data);
    }

    public static string ReadText(string relativePath)
    {
        return FileIO.ReadText(GetAbsolutePath(relativePath));
    }

    public static string ReadText(string relativePath, bool decrypt)
    {
        return EncryptDecrypt(FileIO.ReadText(GetAbsolutePath(relativePath)));
    }


    public static void WriteText(string relativePath, string data)
    {
        FileIO.WriteText(GetAbsolutePath(relativePath), data);
    }

    public static void WriteText(string relativePath, string data, bool encrypt)
    {
        FileIO.WriteText(GetAbsolutePath(relativePath), EncryptDecrypt(data));
    }

    private static readonly string keyWord = "1361315";

    private static string EncryptDecrypt(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyWord[i % keyWord.Length]);
        }

        return result;
    }

    /*
    public static string Encrypt(string Text)
    {
        var publicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCouX";
        // RSA Public Key'i buraya yazmalısınız.
        // Yukarıda verdiğim linkte görebilirsiniz.
        var testData = Encoding.UTF8.GetBytes(Text);
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            try
            {
                var aa = rsa.ToXmlString(true);
                var encryptedData = rsa.Encrypt(testData, true);
                var base64Encrypted = Convert.ToBase64String(encryptedData);
                return base64Encrypted;
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }
    public static string Decrypt(string Text)
    {
        string BOS = "çözülmedi";
        try
        {
            var privateKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCouX";
            // buraya gizli key'inizi yazmalısınız.
            var testData = Encoding.UTF8.GetBytes(Text);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    var base64Encrypted = Text;
                    rsa.FromXmlString(privateKey);
                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        catch
        {
            return BOS;
        } // şifre çözülemedi ise "BOS" cevabı dönecek
    }
    
    */
}