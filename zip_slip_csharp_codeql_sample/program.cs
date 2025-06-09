using System;
using System.Net;
using System.IO.Compression;

public class Program
{
    public static void Main(string[] args)
    {
        using (ZipArchive zip = ZipFile.Open("C:\\Users\\user\\Desktop\\file.zip", ZipArchiveMode.Read))
        {
            UnzipFile(zip, "C:\\Users\\user\\Desktop\\unzipped");
            Program2.UnzipFile(zip, "C:\\Users\\user\\Desktop\\unzipped2");
            Program3.UnzipFileSafe(zip, "C:\\Users\\user\\Desktop\\unzipped_safe");
        }

    }

    public static void UnzipFile(ZipArchive archive, string destDirectory)
    {
        foreach (var entry in archive.Entries)
        {
            string file = entry.FullName;
            if (!string.IsNullOrEmpty(file))
            {
                string destFileName = Path.Combine(destDirectory, file);
                entry.ExtractToFile(destFileName, true);

            }
        }
    }
}
