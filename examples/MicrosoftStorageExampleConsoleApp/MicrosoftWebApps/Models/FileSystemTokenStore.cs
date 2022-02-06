using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the storage of the tokens if a file system is used.
    /// </summary>
    public class FileSystemTokenStore
    {
        /// <summary>
        /// The directory in which the tokens will be stored.
        /// </summary>
        public string Directory { get; set; }
    }
}