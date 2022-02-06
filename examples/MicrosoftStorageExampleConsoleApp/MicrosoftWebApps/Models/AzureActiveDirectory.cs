using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Active directory provider.
    /// </summary>
    public class AzureActiveDirectory
    {
        /// <summary>
        /// false if the Azure Active Directory provider should not be enabled despite the set registration; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the Azure Active Directory app registration.
        /// </summary>
        public AzureActiveDirectoryRegistration Registration { get; set; }

        /// <summary>
        /// The configuration settings of the Azure Active Directory login flow.
        /// </summary>
        public AzureActiveDirectoryLogin Login { get; set; }

        /// <summary>
        /// The configuration settings of the Azure Active Directory token validation flow.
        /// </summary>
        public AzureActiveDirectoryValidation Validation { get; set; }

        /// <summary>
        /// Gets a value indicating whether the Azure AD configuration was auto-provisioned using 1st party tooling.This is an internal flag primarily intended to support the Azure Management Portal. Users should notread or write to this property.
        /// </summary>
        public bool IsAutoProvisioned { get; set; }
    }
}