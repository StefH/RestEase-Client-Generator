using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The HTTP header.
    /// </summary>
    public class HttpHeader
    {
        /// <summary>
        /// The header name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The header value.
        /// </summary>
        public string Value { get; set; }
    }
}