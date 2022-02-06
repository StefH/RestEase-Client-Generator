using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// The IIS handler mappings used to define which handler processes HTTP requests with certain extension. For example, it is used to configure php-cgi.exe process to handle all HTTP requests with *.php extension.
    /// </summary>
    public class HandlerMapping
    {
        /// <summary>
        /// Requests with this extension will be handled using the specified FastCGI application.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// The absolute path to the FastCGI application.
        /// </summary>
        public string ScriptProcessor { get; set; }

        /// <summary>
        /// Command-line arguments to be passed to the script processor.
        /// </summary>
        public string Arguments { get; set; }
    }
}