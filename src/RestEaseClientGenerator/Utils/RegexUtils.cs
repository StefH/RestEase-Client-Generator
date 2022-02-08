using System.Text.RegularExpressions;

namespace RestEaseClientGenerator.Utils;

internal static class RegexUtils
{
    // https://stackoverflow.com/questions/38738558/extract-values-within-single-curly-braces
    private static readonly Regex Curly = new("(?<=\\{)[^\\}]+", RegexOptions.Compiled);

    public static IEnumerable<string> GetParameterNamesFromPath(string path)
    {
        foreach (Match match in Curly.Matches(path))
        {
            yield return match.Value;
        }
    }
}