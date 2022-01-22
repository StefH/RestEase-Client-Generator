using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class CorsRules
    {
        [Newtonsoft.Json.JsonProperty("CorsRules")]
        public CorsRule[] CorsRules_ { get; set; }
    }
}