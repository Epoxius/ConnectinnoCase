using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Enumerable = System.Linq.Enumerable;


public static class AppData
{
    public static string GetAbsolutePath(string relativePath)
    {
        return Path.Combine(Application.streamingAssetsPath, relativePath);
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

    public static string ReadText(string relativePath)
    {
        return FileIO.ReadText(GetAbsolutePath(relativePath));
    }

    public static string ReadStreamingAssets(string relativePath)
    {
        return BetterStreamingAssets.ReadAllText(relativePath);
    }


    public static void WriteText(string relativePath, string data)
    {
        FileIO.WriteText(GetAbsolutePath(relativePath), data);
    }
}