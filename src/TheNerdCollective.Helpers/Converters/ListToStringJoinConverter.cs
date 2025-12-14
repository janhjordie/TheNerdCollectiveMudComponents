using Newtonsoft.Json;

namespace TheNerdCollective.Helpers.Converters;

/// <summary>
/// JSON converter that serializes a list of strings as a semicolon-delimited string.
/// </summary>
public class ListToStringJoinConverter : JsonConverter<List<string>>
{
    /// <summary>
    /// Writes a list of strings as a semicolon-delimited string.
    /// </summary>
    public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
    {
        var joined = value != null ? string.Join(";", value) : string.Empty;
        writer.WriteValue(joined);
    }

    /// <summary>
    /// Reads a semicolon-delimited string and converts it to a list of strings.
    /// </summary>
    public override List<string> ReadJson(JsonReader reader, Type objectType, List<string>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
            return new List<string>();

        var stringValue = reader.Value.ToString() ?? string.Empty;
        return stringValue.Split(';').ToList();
    }
}
