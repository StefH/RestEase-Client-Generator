namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
    /// </summary>
    public static class KeySourceConstants
    {
        public const string MicrosoftStorage = "Microsoft.Storage";

        public const string MicrosoftKeyvault = "Microsoft.Keyvault";
    }
}
