using RestEase;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Api
{
    /// <summary>
    /// The Azure Storage Management API.
    /// </summary>
    public interface IMicrosoftStorageApiWithSubscriptionId : IMicrosoftStorageApi
    {
        [Path("subscriptionId")]
        public string SubscriptionId { get; set; }
    }
}