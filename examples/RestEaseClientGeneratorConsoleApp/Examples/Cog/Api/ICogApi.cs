using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.Cog.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.Cog.Api
{
    /// <summary>
    /// Personalization Service is an Azure Cognitive Service that makes it easy to target content and experiences without complex pre-analysis or cleanup of past data. Given a context and featurized content, the Personalization Service returns your content in a ranked list. As rewards are sent in response to the ranked list, the reinforcement learning algorithm will improve the model and improve performance of future rank calls.
    /// </summary>
    public interface ICogApi
    {
        [Header("Ocp-Apim-Subscription-Key")]
        string OcpApimSubscriptionKey { get; set; }

        /// <summary>
        /// Report reward to allocate to the top ranked action for the specified event.
        /// </summary>
        /// <param name="eventId">The event id this reward applies to.</param>
        /// <param name="content">Reward given to a rank response.</param>
        [Post("/personalization/v1.0/events/{eventId}/reward")]
        [Header("Content-Type", "application/json")]
        Task RewardAsync([Path] string eventId, [Body] RewardRequest content);

        /// <summary>
        /// Report that the specified event was actually displayed to the user and a reward should be expected for it.
        /// </summary>
        /// <param name="eventId">The event id this activation applies to.</param>
        [Post("/personalization/v1.0/events/{eventId}/activate")]
        Task ActivateAsync([Path] string eventId);

        /// <summary>
        /// A personalization rank request.
        /// </summary>
        /// <param name="content">Request a set of actions to be ranked by the personalization service.</param>
        [Post("/personalization/v1.0/rank")]
        [Header("Content-Type", "application/json")]
        Task<RankResponse> RankAsync([Body] RankRequest content);

        /// <summary>
        /// StatusGet (/status)
        /// </summary>
        [Get("/status")]
        Task<ContainerStatus> StatusGetAsync();
    }
}
