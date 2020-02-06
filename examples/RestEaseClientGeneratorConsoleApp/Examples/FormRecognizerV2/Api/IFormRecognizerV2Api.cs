using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Api
{
    /// <summary>
    /// Form Recognizer extracts information from forms and images into structured data.  It includes the following options:* Custom - Extracts information from forms (PDFs and images) into structured data based on a model created from a set of representative training forms. Form Recognizer learns the structure of your forms to intelligently extract text and data. It ingests text from forms, applies machine learning technology to identify keys, tables, and fields, and then outputs structured data that includes the relationships within the original file.* Prebuilt Receipt - Detects and extracts data from receipts using optical character recognition (OCR) and our receipt model, enabling you to easily extract structured data from receipts such as merchant name, merchant phone number, transaction date, transaction total, and more.* Layout - Extracts text and table structure from documents using optical character recognition (OCR).This API is currently available in:* West Europe - westeurope.api.cognitive.microsoft.com* West US 2 - westus2.api.cognitive.microsoft.com
    /// </summary>
    public interface IFormRecognizerV2Api
    {
        [Query("subscription-key")]
        string SubscriptionKey { get; set; }

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
        Task<Models.Models> GetCustomModelsAsync([Query] Op op);

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
        /// <param name="contentType">The Content-Type</param>
        /// <param name="modelId">Format - uuid. Model identifier.</param>
        /// <param name="content">Url to source data.</param>
        /// <param name="includeTextDetails">Include text lines and element references in the result.  Default: false.</param>
        [Post("/custom/models/{modelId}/analyze")]
        Task<AnalyzeOperationResult> AnalyzeWithCustomFormAsync([Header("Content-Type")] string contentType, [Path] string modelId, [Body] SourcePath content, [Query] bool? includeTextDetails);
    }
}
