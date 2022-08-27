using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Details of a REST API operation, returned from the Resource Provider Operations API
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// The name of the operation, as per Resource-Based Access Control (RBAC). Examples: "Microsoft.Compute/virtualMachines/write", "Microsoft.Compute/virtualMachines/capture/action"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the operation applies to data-plane. This is "true" for data-plane operations and "false" for ARM/control-plane operations.
        /// </summary>
        public bool IsDataAction { get; set; }

        /// <summary>
        /// Localized display information for this particular operation.
        /// </summary>
        public Display Display { get; set; }

        /// <summary>
        /// The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is "user,system"
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
        /// </summary>
        public string ActionType { get; set; }
    }
}