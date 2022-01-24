using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Sets the CORS rules. You can include up to five CorsRule elements in the request. 
    /// </summary>
    public class CorsRules
    {
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request. 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("CorsRules")]
        public CorsRule[] CorsRules_ { get; set; }
    }
}