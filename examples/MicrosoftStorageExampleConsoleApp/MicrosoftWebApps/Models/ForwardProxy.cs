using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of a forward proxy used to make the requests.
    /// </summary>
    public class ForwardProxy
    {
        /// <summary>
        /// The convention used to determine the url of the request made.
        /// </summary>
        public string Convention { get; set; }

        /// <summary>
        /// The name of the header containing the host of the request.
        /// </summary>
        public string CustomHostHeaderName { get; set; }

        /// <summary>
        /// The name of the header containing the scheme of the request.
        /// </summary>
        public string CustomProtoHeaderName { get; set; }
    }
}