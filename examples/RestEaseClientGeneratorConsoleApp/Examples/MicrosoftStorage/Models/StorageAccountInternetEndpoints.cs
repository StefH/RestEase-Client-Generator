using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, file, web or dfs object via a internet routing endpoint.
    /// </summary>
    public class StorageAccountInternetEndpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        public string Blob { get; set; }

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