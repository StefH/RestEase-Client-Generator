using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class CorsRules
    {
        [Newtonsoft.Json.JsonProperty("CorsRules")]
        public object[] CorsRules_ { get; set; }
    }
}