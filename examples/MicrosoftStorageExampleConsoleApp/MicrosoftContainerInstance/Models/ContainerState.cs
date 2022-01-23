using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container instance state.
    /// </summary>
    public class ContainerState
    {
        /// <summary>
        /// The state of the container instance.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The date-time when the container instance state started.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        public int ExitCode { get; set; }

        /// <summary>
        /// The date-time when the container instance state finished.
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// The human-readable status of the container instance state.
        /// </summary>
        public string DetailStatus { get; set; }
    }
}