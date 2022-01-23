using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container probe, for liveness or readiness
    /// </summary>
    public class ContainerProbe
    {
        /// <summary>
        /// not-used
        /// </summary>
        public ContainerExec Exec { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ContainerHttpGet HttpGet { get; set; }

        /// <summary>
        /// The initial delay seconds.
        /// </summary>
        public int InitialDelaySeconds { get; set; }

        /// <summary>
        /// The period seconds.
        /// </summary>
        public int PeriodSeconds { get; set; }

        /// <summary>
        /// The failure threshold.
        /// </summary>
        public int FailureThreshold { get; set; }

        /// <summary>
        /// The success threshold.
        /// </summary>
        public int SuccessThreshold { get; set; }

        /// <summary>
        /// The timeout seconds.
        /// </summary>
        public int TimeoutSeconds { get; set; }
    }
}