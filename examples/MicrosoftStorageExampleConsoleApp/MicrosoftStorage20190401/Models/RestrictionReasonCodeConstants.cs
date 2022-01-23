namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC.
    /// </summary>
    public static class RestrictionReasonCodeConstants
    {
        public const string QuotaId = "QuotaId";
        public const string NotAvailableForSubscription = "NotAvailableForSubscription";
    }
}
