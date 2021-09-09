using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using WireMockOrg.Models;

namespace WireMockOrg.Api
{
    /// <summary>
    /// WireMockOrg
    /// </summary>
    public interface IWireMockOrgApi
    {
        /// <summary>
        /// Get all stub mappings
        /// </summary>
        /// <param name="limit">The maximum number of results to return</param>
        /// <param name="offset">The start index of the results to return</param>
        [Get("/__admin/mappings")]
        Task<GetAdminMappingsResult> GetAdminMappingsAsync([Query] int? limit, [Query] int? offset);

        /// <summary>
        /// Create a new stub mapping
        /// </summary>
        [Post("/__admin/mappings")]
        [Header("Content-Type", "application/json")]
        Task<PostAdminMappingsResult> PostAdminMappingsAsync();

        /// <summary>
        /// Delete all stub mappings
        /// </summary>
        [Delete("/__admin/mappings")]
        Task DeleteAdminMappingsAsync();

        /// <summary>
        /// Reset stub mappings
        /// </summary>
        [Post("/__admin/mappings/reset")]
        Task PostAdminMappingsResetAsync();

        /// <summary>
        /// Persist stub mappings
        /// </summary>
        [Post("/__admin/mappings/save")]
        Task PostAdminMappingsSaveAsync();

        /// <summary>
        /// Get stub mapping by ID
        /// </summary>
        [Get("/__admin/mappings/{stubMappingId}")]
        Task<GetAdminMappingsByStubMappingIdResult> GetAdminMappingsByStubMappingIdAsync();

        /// <summary>
        /// Update a stub mapping
        /// </summary>
        [Put("/__admin/mappings/{stubMappingId}")]
        [Header("Content-Type", "application/json")]
        Task<PutAdminMappingsByStubMappingIdResult> PutAdminMappingsByStubMappingIdAsync();

        /// <summary>
        /// Delete a stub mapping
        /// </summary>
        [Delete("/__admin/mappings/{stubMappingId}")]
        Task DeleteAdminMappingsByStubMappingIdAsync();

        /// <summary>
        /// PostAdminMappingsFindByMetadata (/__admin/mappings/find-by-metadata)
        /// </summary>
        [Post("/__admin/mappings/find-by-metadata")]
        [Header("Content-Type", "application/json")]
        Task<PostAdminMappingsFindByMetadataResult> PostAdminMappingsFindByMetadataAsync();

        /// <summary>
        /// Delete stub mappings matching metadata
        /// </summary>
        [Post("/__admin/mappings/remove-by-metadata")]
        [Header("Content-Type", "application/json")]
        Task PostAdminMappingsRemoveByMetadataAsync();

        /// <summary>
        /// Get all requests in journal
        /// </summary>
        /// <param name="limit">The maximum number of results to return</param>
        /// <param name="since">Only return logged requests after this date</param>
        [Get("/__admin/requests")]
        Task GetAdminRequestsAsync([Query] string limit, [Query] string since);

        /// <summary>
        /// Delete all requests in journal
        /// </summary>
        [Delete("/__admin/requests")]
        Task DeleteAdminRequestsAsync();

        /// <summary>
        /// Get request by ID
        /// </summary>
        /// <param name="requestId">The UUID of the logged request</param>
        [Get("/__admin/requests/{requestId}")]
        Task GetAdminRequestsByRequestIdAsync([Path] string requestId);

        /// <summary>
        /// Delete request by ID
        /// </summary>
        /// <param name="requestId">The UUID of the logged request</param>
        [Delete("/__admin/requests/{requestId}")]
        Task DeleteAdminRequestsByRequestIdAsync([Path] string requestId);

        /// <summary>
        /// Empty the request journal
        /// </summary>
        [Post("/__admin/requests/reset")]
        Task PostAdminRequestsResetAsync();

        /// <summary>
        /// Count requests by criteria
        /// </summary>
        [Post("/__admin/requests/count")]
        [Header("Content-Type", "application/json")]
        Task<PostAdminRequestsCountResult> PostAdminRequestsCountAsync();

        /// <summary>
        /// Remove requests by criteria
        /// </summary>
        [Post("/__admin/requests/remove")]
        [Header("Content-Type", "application/json")]
        Task PostAdminRequestsRemoveAsync();

        /// <summary>
        /// Delete requests mappings matching metadata
        /// </summary>
        [Post("/__admin/requests/remove-by-metadata")]
        [Header("Content-Type", "application/json")]
        Task PostAdminRequestsRemoveByMetadataAsync();

        /// <summary>
        /// Find requests by criteria
        /// </summary>
        [Post("/__admin/requests/find")]
        [Header("Content-Type", "application/json")]
        Task PostAdminRequestsFindAsync();

        /// <summary>
        /// Find unmatched requests
        /// </summary>
        [Get("/__admin/requests/unmatched")]
        Task GetAdminRequestsUnmatchedAsync();

        /// <summary>
        /// GetAdminRequestsUnmatchedNearMisses (/__admin/requests/unmatched/near-misses)
        /// </summary>
        [Get("/__admin/requests/unmatched/near-misses")]
        Task<GetAdminRequestsUnmatchedNearMissesResult> GetAdminRequestsUnmatchedNearMissesAsync();

        /// <summary>
        /// Find near misses matching specific request
        /// </summary>
        [Post("/__admin/near-misses/request")]
        [Header("Content-Type", "application/json")]
        Task<PostAdminNearMissesRequestResult> PostAdminNearMissesRequestAsync();

        /// <summary>
        /// Find near misses matching request pattern
        /// </summary>
        [Post("/__admin/near-misses/request-pattern")]
        [Header("Content-Type", "application/json")]
        Task<PostAdminNearMissesRequestPatternResult> PostAdminNearMissesRequestPatternAsync();

        /// <summary>
        /// Start recording
        /// </summary>
        [Post("/__admin/recordings/start")]
        [Header("Content-Type", "application/json")]
        Task PostAdminRecordingsStartAsync();

        /// <summary>
        /// Stop recording
        /// </summary>
        [Post("/__admin/recordings/stop")]
        Task<PostAdminRecordingsStopResult> PostAdminRecordingsStopAsync();

        /// <summary>
        /// Get recording status
        /// </summary>
        [Get("/__admin/recordings/status")]
        Task<GetAdminRecordingsStatusResult> GetAdminRecordingsStatusAsync();

        /// <summary>
        /// Take a snapshot recording
        /// </summary>
        [Post("/__admin/recordings/snapshot")]
        [Header("Content-Type", "application/json")]
        Task<PostAdminRecordingsSnapshotResult> PostAdminRecordingsSnapshotAsync();

        /// <summary>
        /// Get all scenarios
        /// </summary>
        [Get("/__admin/scenarios")]
        Task<GetAdminScenariosResult> GetAdminScenariosAsync();

        /// <summary>
        /// Reset the state of all scenarios
        /// </summary>
        [Post("/__admin/scenarios/reset")]
        Task PostAdminScenariosResetAsync();

        /// <summary>
        /// Update global settings
        /// </summary>
        [Post("/__admin/settings")]
        [Header("Content-Type", "application/json")]
        Task PostAdminSettingsAsync();

        /// <summary>
        /// Reset mappings and request journal
        /// </summary>
        [Post("/__admin/reset")]
        Task PostAdminResetAsync();

        /// <summary>
        /// PostAdminShutdown (/__admin/shutdown)
        /// </summary>
        [Post("/__admin/shutdown")]
        Task PostAdminShutdownAsync();
    }
}