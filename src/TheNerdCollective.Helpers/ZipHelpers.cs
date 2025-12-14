using System.IO.Compression;

namespace TheNerdCollective.Helpers;

/// <summary>
/// ZIP compression and decompression helper methods.
/// </summary>
public abstract class ZipHelpers
{
    /// <summary>
    /// Compresses data using GZIP compression.
    /// </summary>
    /// <param name="data">The data to compress.</param>
    /// <returns>The compressed data, or null if compression fails.</returns>
    public static byte[]? Compress(byte[] data)
    {
        if (data == null || data.Length == 0)
            return null;

        try
        {
            using var memoryStream = new MemoryStream();
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                gzipStream.Write(data, 0, data.Length);
            }

            return memoryStream.ToArray();
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Decompresses GZIP-compressed data.
    /// </summary>
    /// <param name="compressedData">The compressed data.</param>
    /// <returns>The decompressed data.</returns>
    public static byte[] Decompress(byte[] compressedData)
    {
        if (compressedData == null || compressedData.Length == 0)
            return Array.Empty<byte>();

        using var memoryStream = new MemoryStream(compressedData);
        using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
        using var resultStream = new MemoryStream();
        gzipStream.CopyTo(resultStream);
        return resultStream.ToArray();
    }
}
