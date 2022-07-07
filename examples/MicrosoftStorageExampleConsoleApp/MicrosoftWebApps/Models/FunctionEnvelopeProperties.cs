using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// FunctionEnvelope resource specific properties
    /// </summary>
    public class FunctionEnvelopeProperties
    {
        /// <summary>
        /// Function App ID.
        /// </summary>
        public string FunctionAppId { get; set; }

        /// <summary>
        /// Script root path URI.
        /// </summary>
        public string ScriptRootPathHref { get; set; }

        /// <summary>
        /// Script URI.
        /// </summary>
        public string ScriptHref { get; set; }

        /// <summary>
        /// Config URI.
        /// </summary>
        public string ConfigHref { get; set; }

        /// <summary>
        /// Test data URI.
        /// </summary>
        public string TestDataHref { get; set; }

        /// <summary>
        /// Secrets file URI.
        /// </summary>
        public string SecretsFileHref { get; set; }

        /// <summary>
        /// Function URI.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Config information.
        /// </summary>
        public object Config { get; set; }

        /// <summary>
        /// File list.
        /// </summary>
        public Dictionary<string, string> Files { get; set; }

        /// <summary>
        /// Test data used when testing via the Azure Portal.
        /// </summary>
        public string TestData { get; set; }

        /// <summary>
        /// The invocation URL
        /// </summary>
        public string InvokeUrlTemplate { get; set; }

        /// <summary>
        /// The function language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the function is disabled
        /// </summary>
        public bool IsDisabled { get; set; }
    }
}