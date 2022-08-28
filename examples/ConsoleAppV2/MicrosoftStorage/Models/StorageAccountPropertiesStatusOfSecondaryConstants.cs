namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS.
    /// </summary>
    public static class StorageAccountPropertiesStatusOfSecondaryConstants
    {
        public const string Available = "available";

        public const string Unavailable = "unavailable";
    }
}
