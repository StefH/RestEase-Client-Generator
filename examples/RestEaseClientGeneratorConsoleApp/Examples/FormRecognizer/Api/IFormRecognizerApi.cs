using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Api
{
    public interface IFormRecognizerApi
    {
        /// <summary>
        /// Get Analyze Form Result
        /// </summary>
        /// <param name="modelId">Format - uuid. Model identifier.</param>
        /// <param name="resultId">Format - uuid. Analyze operation result identifier.</param>
        [Get("/custom/models/{modelId}/analyzeResults/{resultId}")]
        Task<AnalyzeOperationResult> GetAnalyzeFormResultAsync([Path] string modelId, [Path] string resultId);

        /// <summary>
        /// Analyze Layout
        /// </summary>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="content">Url to source data.</param>
        [Post("/layout/analyze")]
        Task<AnalyzeOperationResult> AnalyzeLayoutAsync([Header("Content-Type")] string contentType, [Body] SourcePath content);

        /// <summary>
        /// Analyze Receipt
        /// </summary>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="content">Url to source data.</param>
        /// <param name="includeTextDetails">Include text lines and element references in the result.  Default: false.</param>
        [Post("/prebuilt/receipt/analyze")]
        Task<AnalyzeOperationResult> AnalyzeReceiptAsync([Header("Content-Type")] string contentType, [Body] SourcePath content, [Query] bool? includeTextDetails);

        /// <summary>
        /// Get Analyze Receipt Result
        /// </summary>
        /// <param name="resultId">Format - uuid. Analyze operation result identifier.</param>
        [Get("/prebuilt/receipt/analyzeResults/{resultId}")]
        Task<AnalyzeOperationResult> GetAnalyzeReceiptResultAsync([Path] string resultId);

        /// <summary>
        /// Get Custom Model
        /// </summary>
        /// <param name="modelId">Format - uuid. Model identifier.</param>
        /// <param name="includeKeys">Include list of extracted keys in model information.</param>
        [Get("/custom/models/{modelId}")]
        Task<Model> GetCustomModelAsync([Path] string modelId, [Query] bool? includeKeys);

        /// <summary>
        /// Delete Custom Model
        /// </summary>
        /// <param name="modelId">Format - uuid. Model identifier.</param>
        [Delete("/custom/models/{modelId}")]
        Task DeleteCustomModelAsync([Path] string modelId);

        /// <summary>
        /// Get Analyze Layout Result
        /// </summary>
        /// <param name="resultId">Format - uuid. Analyze operation result identifier.</param>
        [Get("/layout/analyzeResults/{resultId}")]
        Task<AnalyzeOperationResult> GetAnalyzeLayoutResultAsync([Path] string resultId);

        /// <summary>
        /// List Custom Models
        /// </summary>
        /// <param name="op">Specify whether to return summary or full list of models.</param>
        [Get("/custom/models")]
        Task<Models.Models> GetCustomModelsAsync([Query] string op);

        /// <summary>
        /// Train Custom Model
        /// </summary>
        /// <param name="content">Request parameter to train a new custom model.</param>
        [Post("/custom/models")]
        [Header("Content-Type", "application/json")]
        Task TrainCustomModelAsync([Body] TrainRequest content);

        /// <summary>
        /// Analyze Form
        /// </summary>
        /// <param name="modelId">Format - uuid. Model identifier.</param>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="content">Url to source data.</param>
        /// <param name="includeTextDetails">Include text lines and element references in the result.  Default: false.</param>
        [Post("/custom/models/{modelId}/analyze")]
        Task<AnalyzeOperationResult> AnalyzeWithCustomFormAsync([Path] string modelId, [Header("Content-Type")] string contentType, [Body] SourcePath content, [Query] bool? includeTextDetails);
    }
}
