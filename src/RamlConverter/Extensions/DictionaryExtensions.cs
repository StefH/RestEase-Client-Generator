using System;
using System.Collections.Generic;

namespace RamlToOpenApiConverter.Extensions
{
    internal static class DictionaryExtensions
    {
        public static string Get(this IDictionary<object, object> d, object key)
        {
            return Get<string>(d, key);
        }

        public static T Get<T>(this IDictionary<object, object> d, object key)
        {
            return d.ContainsKey(key) ? (T)Convert.ChangeType(d[key], typeof(T)) : default(T);
        }

        public static IDictionary<object, object> GetAsDictionary(this IDictionary<object, object> d, object key)
        {
            if (d.TryGetValue(key, out object value))
            {
                return value as IDictionary<object, object>;
            }

            return null;
        }
    }
}