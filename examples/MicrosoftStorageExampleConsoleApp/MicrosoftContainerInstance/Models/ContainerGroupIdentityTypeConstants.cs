namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the container group.
    /// </summary>
    public static class ContainerGroupIdentityTypeConstants
    {
        public const string SystemAssigned = "SystemAssigned";
        public const string UserAssigned = "UserAssigned";
        public const string SystemAssignedUserAssigned = "SystemAssigned, UserAssigned";
        public const string None = "None";
    }
}
