using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class GitRepoVolume
    {
        public string Directory { get; set; }

        public string Repository { get; set; }

        public string Revision { get; set; }
    }
}