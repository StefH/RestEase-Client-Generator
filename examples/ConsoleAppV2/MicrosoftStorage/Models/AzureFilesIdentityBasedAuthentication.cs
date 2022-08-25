using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Settings for Azure Files identity based authentication.
    /// </summary>
    public class AzureFilesIdentityBasedAuthentication
    {
        /// <summary>
        /// Indicates the directory service used.
        /// </summary>
        public string DirectoryServiceOptions { get; set; }

        /// <summary>
        /// Settings properties for Active Directory (AD).
        /// </summary>
        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }

        /// <summary>
        /// Default share permission for users using Kerberos authentication if RBAC role is not assigned.
        /// </summary>
        public string DefaultSharePermission { get; set; }
    }
}