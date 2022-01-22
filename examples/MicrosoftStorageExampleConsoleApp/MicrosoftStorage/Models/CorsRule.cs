using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class CorsRule
    {
        public string[] AllowedOrigins { get; set; }

        public string[] AllowedMethods { get; set; }

        public int MaxAgeInSeconds { get; set; }

        public string[] ExposedHeaders { get; set; }

        public string[] AllowedHeaders { get; set; }
    }
}