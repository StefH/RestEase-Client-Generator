using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container Http Get settings, for liveness or readiness probe
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class ContainerHttpGet
    {
        /// <summary>
        /// The path to probe.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The port number to probe.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The scheme.
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// The HTTP headers.
        /// </summary>
        public HttpHeader[] HttpHeaders { get; set; }
    }
}