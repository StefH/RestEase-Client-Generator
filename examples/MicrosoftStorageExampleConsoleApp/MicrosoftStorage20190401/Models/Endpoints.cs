using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    /// </summary>
    public class Endpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        public string Blob { get; set; }

        /// <summary>
        /// Gets the queue endpoint.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Gets the table endpoint.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Gets the file endpoint.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Gets the web endpoint.
        /// </summary>
        public string Web { get; set; }

        /// <summary>
        /// Gets the dfs endpoint.
        /// </summary>
        public string Dfs { get; set; }
    }
}