using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GetosDirtLocker.utils;

/// <summary>
/// This class provides a wide variety of methods for quick and easy writing/reading from files until I decide
/// to update the library.
/// </summary>
public static class FileUtilExtensions
{
    
    /// <summary>
    /// Writes all the given byte data in bulk, as binary information, into the specified filepath.
    /// </summary>
    /// <param name="path">The path to write into</param>
    /// <param name="data">The primitive values to write into the file.</param>
    public static void DumpBytesToFileBinary(string path, List<byte[]> data)
    {
        using BinaryWriter s = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write));

        foreach (var bytearr in data)
        {
            s.Write(bytearr.Length);
            s.Write(bytearr);
        }
    }
        
    /// <summary>
    /// Reads the data in the specified filepath and returns it in the form of a list with
    /// all the values as strings.
    /// </summary>
    /// <param name="path">The filepath to read the data from</param>
    /// <returns>The primitive values in a list of strings</returns>
    public static List<byte[]> ReadBytesFromBinary(string path)
    {
        List<byte[]> values = new List<byte[]>();
        using BinaryReader s = new BinaryReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

        try
        {
            while (s.PeekChar() != -1)
            {
                int size = s.ReadInt32();
                values.Add(s.ReadBytes(size));
            }
        }
        catch (ArgumentException)
        {
            return null;
        }

        return values;
    }
    
    /// <summary>
    /// Returns a bit-by-bit copy of the file at the specified path made from the file stream.
    /// </summary>
    /// <param name="path">The path of the file to copy</param>
    /// <returns>The Image copy of the file</returns>
    public static Image GetImageFromFileStream(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        MemoryStream ms = new MemoryStream(bytes);
        return Image.FromStream(ms);
    }
    
}