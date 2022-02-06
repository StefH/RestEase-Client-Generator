using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Azure proxy only resource. This resource is not tracked by Azure Resource Manager.
    /// </summary>
    public class ProxyOnlyResource
    {
        /// <summary>
        /// Resource Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Resource Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Kind of resource.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        public string Type { get; set; }
    }
}