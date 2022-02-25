using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Response for network dependencies, always empty list.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class NetworkDependenciesResponse
    {
        [Newtonsoft.Json.JsonProperty("NetworkDependenciesResponse")]
        public string[] NetworkDependenciesResponse_ { get; set; }
    }
}