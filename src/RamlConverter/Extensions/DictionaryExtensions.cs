using System;
using System.Collections.Generic;

namespace RamlConverter.Extensions
{
    internal static class DictionaryExtensions
    {
        public static string Get(this IDictionary<object, object> d, string key)
        {
            return Get<string>(d, key);
        }

        public static T Get<T>(this IDictionary<object, object> d, string key)
        {
            return d.ContainsKey(key) ? (T) Convert.ChangeType(d[key], typeof(T)): default(T);
        }
    }
}