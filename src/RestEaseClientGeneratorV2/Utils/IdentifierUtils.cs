using System.Text.RegularExpressions;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Types.Internal;

namespace RestEaseClientGenerator.Utils;

/// <summary>
/// Based on https://gist.github.com/FabienDehopre/5245476
/// </summary>
internal static class IdentifierUtils
{
    // definition of a valid C# identifier: http://msdn.microsoft.com/en-us/library/aa664670(v=vs.71).aspx
    private const string FORMATTING_CHARACTER = @"\p{Cf}";
    private const string CONNECTING_CHARACTER = @"\p{Pc}";
    private const string DECIMAL_DIGIT_CHARACTER = @"\p{Nd}";
    private const string COMBINING_CHARACTER = @"\p{Mn}|\p{Mc}";
    private const string LETTER_CHARACTER = @"\p{Lu}|\p{Ll}|\p{Lt}|\p{Lm}|\p{Lo}|\p{Nl}";

    private const string IDENTIFIER_PART_CHARACTER = LETTER_CHARACTER + "|" +
                                                     DECIMAL_DIGIT_CHARACTER + "|" +
                                                     CONNECTING_CHARACTER + "|" +
                                                     COMBINING_CHARACTER + "|" +
                                                     FORMATTING_CHARACTER;

    private const string IDENTIFIER_PART_CHARACTERS = "(" + IDENTIFIER_PART_CHARACTER + ")+";
    private const string IDENTIFIER_START_CHARACTER = "(" + LETTER_CHARACTER + "|_)";

    private const string IDENTIFIER_OR_KEYWORD = IDENTIFIER_START_CHARACTER + "(" +
                                                 IDENTIFIER_PART_CHARACTERS + ")*";

    // C# keywords: http://msdn.microsoft.com/en-us/library/x53a06bb(v=vs.71).aspx
    private static readonly string[] Keywords =
    {
        "abstract",  "event",      "new",        "struct",
        "as",        "explicit",   "null",       "switch",
        "base",      "extern",     "object",     "this",
        "bool",      "false",      "operator",   "throw",
        "break",     "finally",    "out",        "true",
        "byte",      "fixed",      "override",   "try",
        "case",      "float",      "params",     "typeof",
        "catch",     "for",        "private",    "uint",
        "char",      "foreach",    "protected",  "ulong",
        "checked",   "goto",       "public",     "unchecked",
        "class",     "if",         "readonly",   "unsafe",
        "const",     "implicit",   "ref",        "ushort",
        "continue",  "in",         "return",     "using",
        "decimal",   "int",        "sbyte",      "virtual",
        "default",   "interface",  "sealed",     "volatile",
        "delegate",  "internal",   "short",      "void",
        "do",        "is",         "sizeof",     "while",
        "double",    "lock",       "stackalloc",
        "else",      "long",       "static",
        "enum",      "namespace",  "string",

        // contextual keywords 
        //"add",       "alias",      "ascending",  "async",
        //"await",     "by",         "descending", "dynamic",
        //"equals",    "from",       "get",        "global",
        //"group",     "into",       "join",       "let",
        //"nameof",    "on",         "orderby",    "partial",
        //"remove",    "select",     "set",        "value",
        //"var",       "when",       "where",      "yield"
    };

    private static readonly Dictionary<string, string> Specials = new()
    {
        { "@", "At" },
        { "-", "Minus" },
        { "+", "Plus" },
        { "=", "Equal" },
        { "!", "Not" },
        { "!=", "NotEqual" },
        { ">", "GreaterThan" },
        { "<", "LessThan" },
        { ">=", "GreaterThanEqual" },
        { "<=", "LessThanEqual" },
        { "~", "Approximately" },
        { "~=", "Translingual" }
    };

    private static readonly Regex Regex = new(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");

    private static readonly Regex ValidIdentifierRegex = new("^" + IDENTIFIER_OR_KEYWORD + "$", RegexOptions.Compiled);

    private static readonly string[] ReservedClassName;

    static IdentifierUtils()
    {
        ReservedClassName = typeof(Version).Assembly.GetTypes().OrderBy(t => t.Name).Select(t => t.Name).ToArray();
    }

    public static bool IsReserved(string className)
    {
        return ReservedClassName.Contains(className);
    }

    public static bool IsValidIdentifier(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
        {
            return false;
        }

        var normalizedIdentifier = identifier.Normalize();

        // 1. check if the identifier starts with special --> invalid
        if (Specials.Keys.Any(k => normalizedIdentifier.StartsWith(k)))
        {
            return false;
        }

        // 2. check that the identifier match the ValidIdentifierRegex and it's not a C# keyword
        if (ValidIdentifierRegex.IsMatch(normalizedIdentifier) && !Keywords.Contains(normalizedIdentifier))
        {
            return true;
        }

        // 3. it's not a valid identifier
        return false;
    }

    public static string CreateValidIdentifier(string identifier, CasingType casingType = CasingType.None)
    {
        string casedIdentifier;
        switch (casingType)
        {
            case CasingType.Camel:
                casedIdentifier = identifier.ToCamelCase();
                break;

            case CasingType.Pascal:
                casedIdentifier = identifier.ToPascalCase();
                break;

            default:
                casedIdentifier = identifier;
                break;
        }

        bool isValid = IsValidIdentifier(casedIdentifier);

        if (!isValid)
        {
            // File name contains invalid chars, remove them
            casedIdentifier = Regex.Replace(casedIdentifier, string.Empty);

            // Class name doesn't begin with a letter, insert an underscore
            if (!char.IsLetter(casedIdentifier, 0))
            {
                casedIdentifier = casedIdentifier.Insert(0, "_");
            }
        }

        return casedIdentifier.Replace(" ", string.Empty);
    }

    public static string CreateValidEnumMember(string value)
    {
        foreach (var special in Specials)
        {
            value = value.Replace(special.Key, special.Value);
        }

        return CreateValidIdentifier(value, CasingType.Pascal);
    }
}