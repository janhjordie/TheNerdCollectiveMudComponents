using System.Text.RegularExpressions;

namespace TheNerdCollective.Helpers.Extensions;

/// <summary>
/// Extension methods for string transformations.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string to PascalCase.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string converted to PascalCase.</returns>
    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        // Replace underscores and hyphens with spaces
        var text = Regex.Replace(input, @"[_\-]", " ");

        // Split on spaces and/or camelCase boundaries
        var words = Regex.Split(text, @"\s+|(?=[A-Z])");

        // Process each word
        var pascalCaseWords = words
            .Where(w => !string.IsNullOrWhiteSpace(w))
            .Select(w =>
            {
                // Handle acronyms (all caps followed by lowercase)
                if (Regex.IsMatch(w, @"^[A-Z]{2,}(?=[A-Z][a-z]|\b)"))
                    return w;

                // Capitalize first letter, lowercase rest
                return char.ToUpperInvariant(w[0]) + (w.Length > 1 ? w[1..].ToLowerInvariant() : "");
            });

        return string.Concat(pascalCaseWords);
    }
}
