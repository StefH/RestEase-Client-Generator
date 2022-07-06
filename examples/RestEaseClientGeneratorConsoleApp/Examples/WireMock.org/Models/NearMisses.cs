using System;
using System.Collections.Generic;

namespace WireMockOrg.Models
{
    public class NearMisses
    {
        /// <summary>
        /// The HTTP request method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The path and query to match exactly against
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The full URL to match against
        /// </summary>
        public string AbsoluteUrl { get; set; }

        /// <summary>
        /// Header patterns to match against in the : { "": "" } form
        /// </summary>
        public NearMissesHeaders Headers { get; set; }

        /// <summary>
        /// Cookie patterns to match against in the : { "": "" } form
        /// </summary>
        public NearMissesCookies Cookies { get; set; }

        /// <summary>
        /// Body string to match against
        /// </summary>
        public string Body { get; set; }
    }
}