using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using AzureMachineLearning.Models;

namespace AzureMachineLearning.Api
{
    /// <summary>
    /// API specification for the Azure Machine Learning service predict-rentals
    /// </summary>
    public interface IAzureMachineLearningApi
    {
        /// <summary>
        /// ServiceHealthCheck (/)
        /// </summary>
        [Get("/")]
        Task<AnyOf<string, ErrorResponse>> ServiceHealthCheckAsync();

        /// <summary>
        /// RunMLService (/score)
        /// </summary>
        /// <param name="content">The input payload for executing the real-time machine learning service.</param>
        [Post("/score")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<long[], ErrorResponse>> RunMLServiceAsync([Body] ServiceInput content);
    }
}
