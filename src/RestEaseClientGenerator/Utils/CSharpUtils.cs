using System.CodeDom.Compiler;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RestEaseClientGenerator.Utils
{
    /// <summary>
    /// See also https://stackoverflow.com/questions/25139734/how-can-i-generate-a-safe-class-name-from-a-file-name
    /// </summary>
    internal static class CSharpUtils
    {
        private static readonly CodeDomProvider CodeProvider = CodeDomProvider.CreateProvider("C#");
        private static readonly Regex Regex = new Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");

        public static string CreateValidIdentifier(string identifier, bool applyCamelCase = true)
        {
            string validIdentifier = applyCamelCase ? identifier.ToCamelCase() : identifier;
            bool isValid = CodeProvider.IsValidIdentifier(validIdentifier);

            if (!isValid)
            {
                // File name contains invalid chars, remove them
                validIdentifier = Regex.Replace(validIdentifier, string.Empty);

                // Class name doesn't begin with a letter, insert an underscore
                if (!char.IsLetter(validIdentifier, 0))
                {
                    validIdentifier = validIdentifier.Insert(0, "_");
                }
            }

            return validIdentifier.Replace(" ", string.Empty);
        }
    }
}