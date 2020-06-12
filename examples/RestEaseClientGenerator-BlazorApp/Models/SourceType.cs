using System;
using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGeneratorBlazorApp.Models
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    [Flags]
    public enum SourceType
    {
        [Description("Url")]
        Url = 0,

        [Description("File")]
        File = 1,

        [Description("Example")]
        Example = 2
    }
}