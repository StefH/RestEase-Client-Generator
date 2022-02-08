using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ApiKVReference resource specific properties
    /// </summary>
    public class ApiKVReferenceProperties
    {
        public string Reference { get; set; }

        public string Status { get; set; }

        public string VaultName { get; set; }

        public string SecretName { get; set; }

        public string SecretVersion { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ManagedServiceIdentity IdentityType { get; set; }

        public string Details { get; set; }

        public string Source { get; set; }

        public string ActiveVersion { get; set; }
    }
}