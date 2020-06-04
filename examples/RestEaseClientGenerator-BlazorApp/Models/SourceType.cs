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
        Url = 1,

        [Description("File")]
        File = 2
    }
}