namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
    /// </summary>
    public static class KeyTypeConstants
    {
        public const string Service = "Service";

        public const string Account = "Account";
    }
}
