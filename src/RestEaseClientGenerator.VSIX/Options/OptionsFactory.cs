using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.VSIX.Options.RestEase;

namespace RestEaseClientGenerator.VSIX.Options
{
    public class OptionsFactory : IOptionsFactory
    {
        private readonly JsonSerializerSettings _deserializeSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public IRestEaseOptions Create<TDialogPage>() => VsPackage.Instance.GetDialogPage(typeof(TDialogPage)) as IRestEaseOptions;

        public RestEaseUserOptions Deserialize(string value)
        {
            var x =  JsonConvert.DeserializeObject<RestEaseUserOptions>(value, _deserializeSettings);
            return x;
        }

        public string Serialize(IRestEaseOptions options)
        {
            var stringBuilder = new StringBuilder();

            using (var textWriter = new JsonTextWriter(new StringWriter(stringBuilder)))
            {
                textWriter.Formatting = Formatting.Indented;

                textWriter.WriteStartObject();
                textWriter.WriteComment("Use this file to overrule the RestEase Client Generator Options");

                var properties = typeof(RestEaseOptionsPage)
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(p => new { Property = p, Comment = p.GetCustomAttribute<DescriptionAttribute>()?.Description })
                    .Where(p => p.Property.Name != "UseUserOptions" && !string.IsNullOrEmpty(p.Comment))
                    .OrderBy(p => p.Property.Name)
                    .ToArray();

                foreach (var property in properties)
                {
                    textWriter.WritePropertyName(property.Property.Name);

                    var value = property.Property.GetValue(options);
                    if (value is Enum @enum)
                    {
                        textWriter.WriteValue(@enum.GetDescription());
                        textWriter.WriteComment($"{property.Comment} {GetEnumComment(value.GetType())}");
                    }
                    else
                    {
                        textWriter.WriteValue(value);
                        textWriter.WriteComment(property.Comment);
                    }
                }

                textWriter.WriteEndObject();
            }

            return stringBuilder.ToString();
        }

        private void WriteEnumComment<T>(JsonTextWriter writer)
        {
            WriteEnumComment(typeof(T), writer);
        }

        private void WriteEnumComment(Type type, JsonTextWriter writer)
        {
            writer.WriteComment(GetEnumComment(type));
        }

        private string GetEnumComment(Type type)
        {
            var descriptions = new List<string>();
            foreach (Enum value in Enum.GetValues(type))
            {
                descriptions.Add($"'{value.GetDescription()}'");
            }

            return $"Possible values are: {string.Join(", ", descriptions)}.";
        }
    }
}