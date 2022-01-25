namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Restart policy for all containers within the container group. - `Always` Always restart- `OnFailure` Restart on failure- `Never` Never restart
    /// </summary>
    public static class ContainerGroupPropertiesRestartPolicyConstants
    {
        public const string Always = "Always";

        public const string OnFailure = "OnFailure";

        public const string Never = "Never";
    }
}
