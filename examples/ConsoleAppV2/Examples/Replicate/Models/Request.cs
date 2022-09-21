using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.Replicate.Models
{
    /// <summary>
    /// The request body for a prediction
    /// </summary>
    public class Request
    {
        public Input Input { get; set; }

        public string OutputFilePrefix { get; set; }
    }
}