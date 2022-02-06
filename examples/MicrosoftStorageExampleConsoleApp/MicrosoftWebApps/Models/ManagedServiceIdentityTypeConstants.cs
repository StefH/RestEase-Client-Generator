namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Type of managed service identity.
    /// </summary>
    public static class ManagedServiceIdentityTypeConstants
    {
        public const string SystemAssigned = "SystemAssigned";

        public const string UserAssigned = "UserAssigned";

        public const string SystemAssignedUserAssigned = "SystemAssigned, UserAssigned";

        public const string None = "None";
    }
}
