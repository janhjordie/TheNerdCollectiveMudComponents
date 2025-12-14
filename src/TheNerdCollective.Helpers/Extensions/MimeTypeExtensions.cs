namespace TheNerdCollective.Helpers.Extensions;

/// <summary>
/// Enumeration of common document file types.
/// </summary>
public enum DocumentFileType
{
    Unknown,
    Pdf,
    Png,
    Csv,
    Tsv,
    Parquet,
    Jpg,
    Docx,
    Xlsx,
    Gif
}

/// <summary>
/// Extension methods for MIME type detection and file type identification.
/// </summary>
public static class MimeTypeExtensions
{
    /// <summary>
    /// Gets the MIME type for a given file extension.
    /// </summary>
    /// <param name="extension">The file extension (with or without leading dot).</param>
    /// <returns>The MIME type string.</returns>
    public static string GetMimeTypeForFileExtension(string extension)
    {
        var ext = extension.StartsWith(".") ? extension : $".{extension}";
        return ext.ToLowerInvariant() switch
        {
            ".pdf" => "application/pdf",
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".gif" => "image/gif",
            ".csv" => "text/csv",
            ".tsv" => "text/tab-separated-values",
            ".parquet" => "application/octet-stream",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            _ => "application/octet-stream"
        };
    }

    /// <summary>
    /// Gets the document file type for a given file extension.
    /// </summary>
    /// <param name="extension">The file extension (with or without leading dot).</param>
    /// <returns>The DocumentFileType enumeration value.</returns>
    public static DocumentFileType GetDocumentFileTypeForFileExtension(string extension)
    {
        var ext = extension.StartsWith(".") ? extension : $".{extension}";
        return ext.ToLowerInvariant() switch
        {
            ".pdf" => DocumentFileType.Pdf,
            ".png" => DocumentFileType.Png,
            ".csv" => DocumentFileType.Csv,
            ".tsv" => DocumentFileType.Tsv,
            ".parquet" => DocumentFileType.Parquet,
            ".jpg" or ".jpeg" => DocumentFileType.Jpg,
            ".docx" => DocumentFileType.Docx,
            ".xlsx" => DocumentFileType.Xlsx,
            ".gif" => DocumentFileType.Gif,
            _ => DocumentFileType.Unknown
        };
    }
}
