using System.Text.RegularExpressions;

namespace Domain.Common.Result;

/// <summary>
/// Value Object for IMDB ID with built-in validation.
/// Reusable pattern for all string-based identifiers.
/// </summary>
public static partial class ImdbId
{
    private static readonly Regex ImdbIdRegex = new(@"^tt\d{7,8}$", RegexOptions.Compiled);

    public static bool IsValid(string id)
    {
        return !string.IsNullOrWhiteSpace(id) && ImdbIdRegex.IsMatch(id.Trim());
    }
}