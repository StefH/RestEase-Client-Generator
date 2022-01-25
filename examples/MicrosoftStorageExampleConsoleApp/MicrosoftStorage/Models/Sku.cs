using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The resource model definition representing SKU
    /// </summary>
    public class Sku
    {
        /// <summary>
        /// The name of the SKU. Ex - P3. It is typically a letter+number code
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code. 
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted.
        /// </summary>
        public int Capacity { get; set; }
    }
}