using System;
using System.Net;
using System.IO.Compression;

public class Program3
{
    public static void UnzipFileSafe(ZipArchive archive, string destDirectory)
    {
        foreach (var entry in archive.Entries)
        {
            string file = GetRelativePath(entry.FullName);
            if (!string.IsNullOrEmpty(file))
            {
                string destFileName = Path.Combine(destDirectory, file);
                entry.ExtractToFile(destFileName, true);

            }
        }
    }

    public static string GetRelativePath(string path)
    {
        string basePath;
        string filePath;
        try
        {
            basePath = Path.GetFullPath(".") + Path.DirectorySeparatorChar;
            filePath = Path.GetFullPath(path);
        }
        catch (IOException e)
        {
            throw new ArgumentException("Potential directory traversal attempt", e);
        }
        if (filePath.StartsWith(basePath))
        {
            return filePath;
        }
        else
        {
            throw new ArgumentException("Potential directory traversal attempt");
        }
    }
}
