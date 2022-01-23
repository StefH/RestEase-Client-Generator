using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class LogAnalytics
    {
        public string WorkspaceId { get; set; }

        public string WorkspaceKey { get; set; }

        public string LogType { get; set; }

        public Metadata Metadata { get; set; }

        public string WorkspaceResourceId { get; set; }
    }
}