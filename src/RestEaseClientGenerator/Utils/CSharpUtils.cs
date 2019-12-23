using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using RestEaseClientGenerator.Extensions;

namespace RestEaseClientGenerator.Utils
{
    /// <summary>
    /// See also https://stackoverflow.com/questions/25139734/how-can-i-generate-a-safe-class-name-from-a-file-name
    /// </summary>
    internal static class CSharpUtils
    {
        private static readonly CodeDomProvider CodeProvider = CodeDomProvider.CreateProvider("C#");
        private static readonly Regex Regex = new Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");

        public static string CreateValidIdentifier(string identifier, bool applyCamelCase = false)
        {
            string camelCasedIdentifier = applyCamelCase ? identifier.ToCamelCase() : identifier;
            bool isValid = CodeProvider.IsValidIdentifier(camelCasedIdentifier);

            if (!isValid)
            {
                // File name contains invalid chars, remove them
                camelCasedIdentifier = Regex.Replace(camelCasedIdentifier, string.Empty);

                // Class name doesn't begin with a letter, insert an underscore
                if (!char.IsLetter(camelCasedIdentifier, 0))
                {
                    camelCasedIdentifier = camelCasedIdentifier.Insert(0, "_");
                }
            }

            return CodeProvider.CreateValidIdentifier(camelCasedIdentifier.Replace(" ", string.Empty));
        }
    }
}