namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
    /// </summary>
    public static class SkuNameConstants
    {
        public const string StandardLRS = "Standard_LRS";

        public const string StandardGRS = "Standard_GRS";

        public const string StandardRAGRS = "Standard_RAGRS";

        public const string StandardZRS = "Standard_ZRS";

        public const string PremiumLRS = "Premium_LRS";

        public const string PremiumZRS = "Premium_ZRS";

        public const string StandardGZRS = "Standard_GZRS";

        public const string StandardRAGZRS = "Standard_RAGZRS";
    }
}
