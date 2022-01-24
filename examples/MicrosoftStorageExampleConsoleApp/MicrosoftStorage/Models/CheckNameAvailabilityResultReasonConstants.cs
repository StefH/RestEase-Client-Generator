namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false.
    /// </summary>
    public static class CheckNameAvailabilityResultReasonConstants
    {
        public const string AccountNameInvalid = "AccountNameInvalid";

        public const string AlreadyExists = "AlreadyExists";
    }
}
