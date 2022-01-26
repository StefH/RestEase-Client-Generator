using System.Text;
using System.Text.RegularExpressions;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Extensions;

/// <summary>
/// Some code copied from https://raw.githubusercontent.com/andeart/CaseConversions/master/CaseConversions/CaseConversion.cs
/// </summary>
public static class StringExtensions
{
    internal static string ToValidIdentifier(this string value, CasingType casingType = CasingType.None)
    {
        return CSharpUtils.CreateValidIdentifier(value, casingType);
    }

    public static string? StripHtml(this string? text)
    {
        return text == null ?
            null :
            Regex.Replace(text, "<.*?>|\r\n|\r|\n", string.Empty);
    }

    /// <summary>
    /// Converts text to camelCase.
    /// </summary>
    /// <param name="text">The text to be converted.</param>
    public static string ToCamelCase(this string text)
    {
        text = text.Trim();

        // Remove all non-alphanumerics with following characters, and capitalise their following character.
        text = Regex.Replace(text, @"([^a-zA-Z\d]+[a-zA-Z])", RemoveAllButLastCapitalised);

        // Remove any remaining non-alphanumerics (i.e. ones that don't have any following characters).
        text = Regex.Replace(text, @"([^a-zA-Z\d])", string.Empty);

        // Un-capitalise first character.
        text = UncapitaliseFirstChar(text);

        return text;
    }

    /// <summary>
    /// Converts text to PascalCase.
    /// </summary>
    /// <param name="text">The text to be converted.</param>
    public static string ToPascalCase(this string text)
    {
        text = text.Trim();

        // Remove all non-alphanumerics with following characters, and capitalise their following character.
        text = Regex.Replace(text, @"([^a-zA-Z\d]+[a-zA-Z])", RemoveAllButLastCapitalised);

        // Remove any remaining non-alphanumerics (i.e. ones that don't have any following characters).
        text = Regex.Replace(text, @"([^a-zA-Z\d])", string.Empty);

        // Capitalise first character.
        text = CapitaliseFirstChar(text);

        return text;
    }

    public static string ToPascalCasedddd(this string original)
    {
        Regex invalidCharsRgx = new Regex("[^_a-zA-Z0-9]");
        Regex whiteSpace = new Regex(@"(?<=\s)");
        Regex startsWithLowerCaseChar = new Regex("^[a-z]");
        Regex firstCharFollowedByUpperCasesOnly = new Regex("(?<=[A-Z])[A-Z0-9]+$");
        Regex lowerCaseNextToNumber = new Regex("(?<=[0-9])[a-z]");
        Regex upperCaseInside = new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))");

        // replace white spaces with undescore, then replace all invalid chars with empty string
        var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(original, "_"), string.Empty)
            // split by underscores
            .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
            // set first letter to uppercase
            .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
            // replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
            .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
            // set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
            .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
            // lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
            .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

        return string.Concat(pascalCase);
    }

    public static string ToPascalCase3(this string initial)
        => Regex.Replace(initial,
            // (Match any non punctuation) & then ignore any punctuation
            @"([^\p{Pc}]+)[\p{Pc}]*",
            new MatchEvaluator(mtch =>
            {
                var word = mtch.Groups[1].Value.ToLower();

                return $"{Char.ToUpper(word[0])}{word.Substring(1)}";
            }));

    public static string ToPascalCase32(this string s)
    {
        // Find word parts using the following rules:
        // 1. all lowercase starting at the beginning is a word
        // 2. all caps is a word.
        // 3. first letter caps, followed by all lowercase is a word
        // 4. the entire string must decompose into words according to 1,2,3.
        // Note that 2&3 together ensure MPSUser is parsed as "MPS" + "User".

        var m = Regex.Match(s, "^(?<word>^[a-z]+|[A-Z]+|[A-Z][a-z]+)+$");
        var g = m.Groups["word"];

        // Take each word and convert individually to TitleCase
        // to generate the final output.  Note the use of ToLower
        // before ToTitleCase because all caps is treated as an abbreviation.
        var t = Thread.CurrentThread.CurrentCulture.TextInfo;
        var sb = new StringBuilder();
        foreach (var c in g.Captures.Cast<Capture>())
            sb.Append(t.ToTitleCase(c.Value.ToLower()));

        return sb.ToString();
    }

    /// <summary>
    /// Converts text to lower_snake_case.
    /// </summary>
    /// <param name="text">The text to be converted.</param>
    public static string ToLowerSnakeCase(this string text)
    {
        text = text.Trim();

        // Replace all upper-case characters with underscore and a lower-case version of the same character.
        text = Regex.Replace(text, @"\.?([A-Z])", "_$1");

        // Replace all non-alphanumerics with underscores.
        text = Regex.Replace(text, @"([^a-zA-Z\d]+)", "_");

        // Remove vestigial leading underscore that may be created from previous steps.
        text = Regex.Replace(text, @"^_", string.Empty);

        // Remove vestigial trailing underscore that may be created from previous steps.
        text = Regex.Replace(text, @"_$", string.Empty);

        // Convert all characters to lower-case.
        text = text.ToLowerInvariant();

        return text;
    }

    /// <summary>
    /// Converts text to _underscoreCamelCase.
    /// </summary>
    /// <param name="text">The text to be converted.</param>
    public static string ToUnderscoreCamelCase(this string text)
    {
        text = text.Trim();

        // Remove all non-alphanumerics with following characters, and capitalise their following character.
        text = Regex.Replace(text, @"([^a-zA-Z\d]+[a-zA-Z])", RemoveAllButLastCapitalised);

        // Remove any remaining non-alphanumerics (i.e. ones that don't have any following characters).
        text = Regex.Replace(text, @"([^a-zA-Z\d])", string.Empty);

        // Un-capitalise first character.
        text = UncapitaliseFirstChar(text);

        text = string.Concat("_", text);

        return text;
    }

    private static string RemoveAllButLastCapitalised(Match match)
    {
        return RemoveAllButLastCapitalised(match.Groups[1].Value);
    }

    private static string RemoveAllButLastCapitalised(string text)
    {
        text = text.Substring(text.Length - 1);
        text = text.ToUpperInvariant();
        return text;
    }

    private static string CapitaliseFirstChar(string nonSpacedText)
    {
        if (string.IsNullOrEmpty(nonSpacedText))
        {
            return string.Empty;
        }

        if (char.IsUpper(nonSpacedText[0]))
        {
            return nonSpacedText;
        }

        return Regex.Replace(nonSpacedText, @"(^.)", EvaluateCapitaliseString);
    }

    private static string EvaluateCapitaliseString(Match match)
    {
        return match.Groups[1].Value.ToUpperInvariant();
    }

    private static string UncapitaliseFirstChar(string nonSpacedText)
    {
        nonSpacedText = Regex.Replace(nonSpacedText, @"(^.)", EvaluateUncapitaliseString);
        return nonSpacedText;
    }

    private static string EvaluateUncapitaliseString(Match match)
    {
        return match.Groups[1].Value.ToLowerInvariant();
    }
}