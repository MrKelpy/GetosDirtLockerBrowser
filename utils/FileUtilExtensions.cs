using System;
using System.Drawing;
using System.IO;
using GetosDirtLockerBrowser.Properties;

namespace GetosDirtLockerBrowser.utils;

/// <summary>
/// This class provides a wide variety of methods for quick and easy writing/reading from files until I decide
/// to update the library.
/// </summary>
public static class FileUtilExtensions
{
    /// <summary>
    /// Returns a bit-by-bit copy of the file at the specified path made from the file stream.
    /// </summary>
    /// <param name="path">The path of the file to copy</param>
    /// <returns>The Image copy of the file</returns>
    public static Image GetImageFromFileStream(string path)
    {
        try
        {
            path = path.Replace('{', ' ').Replace('}', ' ');
            byte[] bytes = File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }
        
        // If there's an issue with the file, return the default image.
        catch (Exception)
        { return Resources.nuhuh; }
    }
    
}