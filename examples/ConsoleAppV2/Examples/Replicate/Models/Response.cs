using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.Replicate.Models
{
    /// <summary>
    /// The response body for a prediction
    /// </summary>
    public class Response
    {
        public string Error { get; set; }

        public string[] Output { get; set; }

        /// <summary>
        /// An enumeration.
        /// </summary>
        public string Status { get; set; }
    }
}