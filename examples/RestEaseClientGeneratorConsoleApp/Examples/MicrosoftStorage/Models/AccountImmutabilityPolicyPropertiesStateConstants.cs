namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The ImmutabilityPolicy state defines the mode of the policy. Disabled state disables the policy, Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property, Locked state only allows the increase of the immutability retention time. A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states. Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted.
    /// </summary>
    public static class AccountImmutabilityPolicyPropertiesStateConstants
    {
        public const string Unlocked = "Unlocked";

        public const string Locked = "Locked";

        public const string Disabled = "Disabled";
    }
}
