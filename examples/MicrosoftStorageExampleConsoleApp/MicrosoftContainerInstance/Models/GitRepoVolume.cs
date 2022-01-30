using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Represents a volume that is populated with the contents of a git repository
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class GitRepoVolume
    {
        /// <summary>
        /// Target directory name. Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the git repository.  Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Repository URL
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Commit hash for the specified revision.
        /// </summary>
        public string Revision { get; set; }
    }
}