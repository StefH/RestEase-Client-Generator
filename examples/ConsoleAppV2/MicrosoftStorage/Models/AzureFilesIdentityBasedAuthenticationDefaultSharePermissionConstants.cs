namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Default share permission for users using Kerberos authentication if RBAC role is not assigned.
    /// </summary>
    public static class AzureFilesIdentityBasedAuthenticationDefaultSharePermissionConstants
    {
        public const string None = "None";

        public const string StorageFileDataSmbShareReader = "StorageFileDataSmbShareReader";

        public const string StorageFileDataSmbShareContributor = "StorageFileDataSmbShareContributor";

        public const string StorageFileDataSmbShareElevatedContributor = "StorageFileDataSmbShareElevatedContributor";

        public const string StorageFileDataSmbShareOwner = "StorageFileDataSmbShareOwner";
    }
}
