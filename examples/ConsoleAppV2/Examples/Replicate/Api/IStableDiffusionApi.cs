using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using ConsoleAppV2.Examples.Replicate.Models;

namespace ConsoleAppV2.Examples.Replicate.Api
{
    /// <summary>
    /// Summary: StableDiffusion
    /// Title  : Cog
    /// Version: 0.1.0
    /// </summary>
    public interface IStableDiffusionApi
    {
        /// <summary>
        /// Root
        ///
        /// RootGet (/)
        /// </summary>
        [Get("/")]
        Task<object> RootGetAsync();

        /// <summary>
        /// Predict
        ///
        /// PredictPredictionsPost (/predictions)
        /// </summary>
        /// <param name="content">The request body for a prediction</param>
        [Post("/predictions")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Response, HTTPValidationError>>> PredictPredictionsPostAsync([Body] Request content);
    }
}