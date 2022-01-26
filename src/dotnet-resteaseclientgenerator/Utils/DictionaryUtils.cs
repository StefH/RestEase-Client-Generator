using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotNetRestEaseClientGenerator.Utils;

internal static class DictionaryUtils
{
    /// <summary>
    /// https://github.com/commandlineparser/commandline/issues/19
    /// </summary>
    internal static Dictionary<string, string> ToDictionary(IEnumerable<string> list)
    {
        const string KEY_VALUE1 = @"([\w|\-]*)\=([\w|\-]*)";
        const string KEY_VALUE2 = @"([\w|\-]*)\=\""([.|\""]+)\""";

        var result = new Dictionary<string, string>();
        foreach (var item in list)
        {
            bool matchKeyValue1 = Regex.IsMatch(item, KEY_VALUE1);
            bool matchKeyValue2 = Regex.IsMatch(item, KEY_VALUE2);
            if (!(matchKeyValue1 || matchKeyValue1))
            {
                throw new Exception($"Parameter {item} does not match the requirements.");
            }

            string regexElected = matchKeyValue2 ? KEY_VALUE2 : matchKeyValue1 ? KEY_VALUE1 : string.Empty;
            
            string key = Regex.Match(item, regexElected).Groups[1].Value;
            string value = Regex.Match(item, regexElected).Groups[2].Value;
            result.Add(key, value);
        }

        return result;
    }
}