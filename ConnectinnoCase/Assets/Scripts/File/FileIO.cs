using System;
using System.IO;
using System.Text;
using UnityEngine;


public static class FileIO
{
    public const string LogCategory = "FileIO";

    public static byte[] ReadBinary(string absolutePath)
    {
        try
        {
#if UNITY_WSA
                return UnityEngine.Windows.File.ReadAllBytes(absolutePath);
#else
            return File.ReadAllBytes(absolutePath);
#endif
        }
        catch (Exception e)
        {
//            Debug.LogError(e.Message);
            return null;
        }
    }
    

    public static bool ReadBinary(string absolutePath, long fileOffset, byte[] buffer, int bufferOffset,
        int numberOfBytes)
    {
        try
        {
            using (FileStream fs = File.OpenRead(absolutePath))
            {
                if (fileOffset > 0)
                {
                    fs.Seek(fileOffset, SeekOrigin.Begin);
                }

                fs.Read(buffer, bufferOffset, numberOfBytes);
                fs.Close();
            }

            return true;
        }
        catch (Exception e)
        {
                Debug.LogError(e.Message);
        }

        return false;
    }

    public static void WriteBinary(string absolutePath, byte[] data)
    {
        try
        {
#if UNITY_WSA
                UnityEngine.Windows.File.WriteAllBytes(absolutePath, data);
#else
            File.WriteAllBytes(absolutePath, data);
#endif
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public static string ReadText(string absolutePath)
    {
        try
        {
            return Encoding.UTF8.GetString(ReadBinary(absolutePath));
        }
        catch (Exception e)
        {
          //  Debug.LogError(e.Message);
            return string.Empty;
        }
    }

    public static void WriteText(string absolutePath, string data)
    {
        try
        {
            WriteBinary(absolutePath, Encoding.UTF8.GetBytes(data));
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}