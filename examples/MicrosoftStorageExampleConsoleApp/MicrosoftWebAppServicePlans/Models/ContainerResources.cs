using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App container resource requirements.
    /// </summary>
    public class ContainerResources
    {
        /// <summary>
        /// Required CPU in cores, e.g. 0.5
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// Required memory, e.g. "250Mb"
        /// </summary>
        public string Memory { get; set; }
    }
}