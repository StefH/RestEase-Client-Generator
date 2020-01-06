using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Api
{
    public interface ISpeechServicesApi
    {
        /// <summary>
        /// Gets the list of accuracy tests for the authenticated subscription.
        /// </summary>
        [Get("/api/speechtotext/v2.0/accuracytests")]
        Task<Test[]> GetAccuracyTestsAsync();

        /// <summary>
        /// Creates a new accuracy test.
        /// </summary>
        /// <param name="content">The details of the new accuracy test.</param>
        [Post("/api/speechtotext/v2.0/accuracytests")]
        [Header("Content-Type", "application/json")]
        Task CreateAccuracyTestAsync([Body] TestDefinition content);

        /// <summary>
        /// Gets the accuracy test identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the accuracy test.</param>
        [Get("/api/speechtotext/v2.0/accuracytests/{id}")]
        Task<Test> GetAccuracyTestAsync([Path] string id);

        /// <summary>
        /// Deletes the accuracy test identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the accuracy test.</param>
        [Delete("/api/speechtotext/v2.0/accuracytests/{id}")]
        Task DeleteAccuracyTestAsync([Path] string id);

        /// <summary>
        /// Updates the mutable details of the test identified by its id.
        /// </summary>
        /// <param name="id">The identifier of the accuracy test.</param>
        /// <param name="content">The object containing the updated fields of the test.</param>
        [Patch("/api/speechtotext/v2.0/accuracytests/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Test> UpdateAccuracyTestAsync([Path] string id, [Body] TestUpdate content);

        /// <summary>
        /// Gets a list of datasets for the authenticated subscription.
        /// </summary>
        [Get("/api/speechtotext/v2.0/datasets")]
        Task<Dataset[]> GetDatasetsAsync();

        /// <summary>
        /// Gets the dataset identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the dataset.</param>
        [Get("/api/speechtotext/v2.0/datasets/{id}")]
        Task<Dataset> GetDatasetAsync([Path] string id);

        /// <summary>
        /// Deletes the specified dataset.
        /// </summary>
        /// <param name="id">The identifier of the dataset.</param>
        [Delete("/api/speechtotext/v2.0/datasets/{id}")]
        Task DeleteDatasetAsync([Path] string id);

        /// <summary>
        /// Updates the mutable details of the dataset identified by its ID.
        /// </summary>
        /// <param name="id">The identifier of the dataset.</param>
        /// <param name="content">The updated values for the dataset.</param>
        [Patch("/api/speechtotext/v2.0/datasets/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Dataset> UpdateDatasetAsync([Path] string id, [Body] DatasetUpdate content);

        /// <summary>
        /// Gets a list of supported locales for data imports.
        /// </summary>
        [Get("/api/speechtotext/v2.0/datasets/locales")]
        Task<DatasetLocales> GetSupportedLocalesForDatasetsAsync();

        /// <summary>
        /// Uploads data and creates a new dataset.
        /// </summary>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/api/speechtotext/v2.0/datasets/upload")]
        [Header("Content-Type", "multipart/form-data")]
        Task UploadDatasetAsync([Body] HttpContent content);

        /// <summary>
        /// Gets the list of endpoints for the authenticated subscription.
        /// </summary>
        [Get("/api/speechtotext/v2.0/endpoints")]
        Task<Endpoint[]> GetEndpointsAsync();

        /// <summary>
        /// Creates a new endpoint.
        /// </summary>
        /// <param name="content">The details of the endpoint.</param>
        [Post("/api/speechtotext/v2.0/endpoints")]
        [Header("Content-Type", "application/json")]
        Task CreateEndpointAsync([Body] SpeechEndpointDefinition content);

        /// <summary>
        /// Gets the endpoint identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the endpoint.</param>
        [Get("/api/speechtotext/v2.0/endpoints/{id}")]
        Task<Endpoint> GetEndpointAsync([Path] string id);

        /// <summary>
        /// Deletes the endpoint identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the endpoint.</param>
        [Delete("/api/speechtotext/v2.0/endpoints/{id}")]
        Task DeleteEndpointAsync([Path] string id);

        /// <summary>
        /// Updates the metadata of the endpoint identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the endpoint.</param>
        /// <param name="content">The updated values for the endpoint.</param>
        [Patch("/api/speechtotext/v2.0/endpoints/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Endpoint> UpdateEndpointAsync([Path] string id, [Body] EndpointMetadataUpdate content);

        /// <summary>
        /// Gets a list of supported locales for endpoint creations.
        /// </summary>
        [Get("/api/speechtotext/v2.0/endpoints/locales")]
        Task<string[]> GetSupportedLocalesForEndpointsAsync();

        /// <summary>
        /// Gets the list of endpoint data export tasks for the authenticated user.
        /// </summary>
        /// <param name="endpointId">The identifier of the endpoint.</param>
        [Get("/api/speechtotext/v2.0/endpoints/{endpointId}/data")]
        Task<EndpointData[]> GetEndpointDataExportsAsync([Path] string endpointId);

        /// <summary>
        /// Create a new endpoint data export task.
        /// </summary>
        /// <param name="endpointId">The identifier of the endpoint.</param>
        /// <param name="content">The details of the new endpoint data export.</param>
        [Post("/api/speechtotext/v2.0/endpoints/{endpointId}/data")]
        [Header("Content-Type", "application/json")]
        Task CreateEndpointDataExportAsync([Path] string endpointId, [Body] EndpointDataDefinition content);

        /// <summary>
        /// Deletes the transcriptions and captured audio files associated with the endpoint identified by the given ID.
        /// </summary>
        /// <param name="endpointId">The identifier of the endpoint.</param>
        [Delete("/api/speechtotext/v2.0/endpoints/{endpointId}/data")]
        Task DeleteEndpointDataAsync([Path] string endpointId);

        /// <summary>
        /// Gets the specified endpoint data export task for the authenticated user.
        /// </summary>
        /// <param name="endpointId">The identifier of the endpoint.</param>
        /// <param name="id">The identifier of the data export.</param>
        [Get("/api/speechtotext/v2.0/endpoints/{endpointId}/data/{id}")]
        Task<EndpointData> GetEndpointDataExportAsync([Path] string endpointId, [Path] string id);

        /// <summary>
        /// Deletes the endpoint data export task identified by the given ID.
        /// </summary>
        /// <param name="endpointId">The identifier of the endpoint.</param>
        /// <param name="id">The identifier of the endpoint data export.</param>
        [Delete("/api/speechtotext/v2.0/endpoints/{endpointId}/data/{id}")]
        Task DeleteEndpointDataExportAsync([Path] string endpointId, [Path] string id);

        /// <summary>
        /// Gets the list of models for the authenticated subscription.
        /// </summary>
        [Get("/api/speechtotext/v2.0/models")]
        Task<Model[]> GetModelsAsync();

        /// <summary>
        /// Creates a new model.
        /// </summary>
        /// <param name="content">The details of the new model.</param>
        [Post("/api/speechtotext/v2.0/models")]
        [Header("Content-Type", "application/json")]
        Task CreateModelAsync([Body] SpeechModelDefinition content);

        /// <summary>
        /// Gets the model identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the model.</param>
        [Get("/api/speechtotext/v2.0/models/{id}")]
        Task<Model> GetModelAsync([Path] string id);

        /// <summary>
        /// Deletes the model identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the model.</param>
        [Delete("/api/speechtotext/v2.0/models/{id}")]
        Task DeleteModelAsync([Path] string id);

        /// <summary>
        /// Updates the metadata of the model identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the model.</param>
        /// <param name="content">The updated values for the model.</param>
        [Patch("/api/speechtotext/v2.0/models/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Model> UpdateModelAsync([Path] string id, [Body] ModelUpdate content);

        /// <summary>
        /// Gets a list of supported locales for model adaptation.
        /// </summary>
        [Get("/api/speechtotext/v2.0/models/locales")]
        Task<GetSupportedLocalesForModelsResult> GetSupportedLocalesForModelsAsync();

        /// <summary>
        /// Gets the transcription identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the transcription.</param>
        [Get("/api/speechtotext/v2.0/transcriptions/{id}")]
        Task<Transcription> GetTranscriptionAsync([Path] string id);

        /// <summary>
        /// Deletes the specified transcription task.
        /// </summary>
        /// <param name="id">The identifier of the transcription.</param>
        [Delete("/api/speechtotext/v2.0/transcriptions/{id}")]
        Task DeleteTranscriptionAsync([Path] string id);

        /// <summary>
        /// Updates the mutable details of the transcription identified by its ID.
        /// </summary>
        /// <param name="id">The identifier of the transcription.</param>
        /// <param name="content">The updated values for the transcription.</param>
        [Patch("/api/speechtotext/v2.0/transcriptions/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Transcription> UpdateTranscriptionAsync([Path] string id, [Body] TranscriptionUpdate content);

        /// <summary>
        /// Gets a list of supported locales for offline transcriptions.
        /// </summary>
        [Get("/api/speechtotext/v2.0/transcriptions/locales")]
        Task<string[]> GetSupportedLocalesForTranscriptionsBBaAsync();

        /// <summary>
        /// Gets a list of transcriptions for the authenticated subscription.
        /// </summary>
        /// <param name="xyz">Dummy</param>
        /// <param name="skip">Number of transcriptions that will be skipped.</param>
        /// <param name="take">Number of transcriptions that will be included after skipping.</param>
        [Get("/api/speechtotext/v2.0/transcriptions")]
        Task<Transcription[]> GetTranscriptionsAsync([Query] int xyz, [Query] int? skip, [Query] int? take);

        /// <summary>
        /// Creates a new transcription.
        /// </summary>
        /// <param name="content">The details of the new transcription.</param>
        [Post("/api/speechtotext/v2.0/transcriptions")]
        [Header("Content-Type", "application/json")]
        Task CreateTranscriptionAsync([Body] TranscriptionDefinition content);

        /// <summary>
        /// The action returns the health of the different components of the serivce.
        /// </summary>
        [Get("/api/common/v2.0/healthstatus")]
        Task<HealthStatusResponse> GetHealthStatusAsync();

        /// <summary>
        /// Gets all voice datasets.
        /// </summary>
        [Get("/api/texttospeech/v2.0/datasets")]
        Task<Dataset[]> GetVoiceDatasetsAsync();

        /// <summary>
        /// Gets a list of supported locales for custom voice data imports.
        /// </summary>
        [Get("/api/texttospeech/v2.0/datasets/locales")]
        Task<string[]> GetSupportedLocalesForVoiceDatasetsAsync();

        /// <summary>
        /// Uploads data and creates a new voice data object.
        /// </summary>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/api/texttospeech/v2.0/datasets/upload")]
        [Header("Content-Type", "multipart/form-data")]
        Task UploadVoiceDatasetAsync([Body] HttpContent content);

        /// <summary>
        /// Deletes the voice dataset with the given id.
        /// </summary>
        /// <param name="id">The identifier of the voice dataset.</param>
        [Delete("/api/texttospeech/v2.0/datasets/{id}")]
        Task DeleteVoiceDatasetAsync([Path] string id);

        /// <summary>
        /// Updates the mutable details of the voice dataset identified by its ID.
        /// </summary>
        /// <param name="id">The identifier of the voice dataset.</param>
        /// <param name="content">The updated values for the voice dataset.</param>
        [Patch("/api/texttospeech/v2.0/datasets/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Dataset> UpdateVoiceDatasetAsync([Path] string id, [Body] DatasetUpdate content);

        /// <summary>
        /// Gets a list of voice endpoint details.
        /// </summary>
        [Get("/api/texttospeech/v2.0/endpoints")]
        Task<Endpoint[]> GetVoiceDeploymentsAsync();

        /// <summary>
        /// Creates a new voice endpoint object.
        /// </summary>
        /// <param name="content"></param>
        [Post("/api/texttospeech/v2.0/endpoints")]
        [Header("Content-Type", "application/json")]
        Task CreateVoiceDeploymentAsync([Body] EndpointDefinition content);

        /// <summary>
        /// Gets the details of a custom voice endpoint.
        /// </summary>
        /// <param name="id"></param>
        [Get("/api/texttospeech/v2.0/endpoints/{id}")]
        Task<Endpoint> GetVoiceDeploymentAsync([Path] string id);

        /// <summary>
        /// Delete the specified voice endpoint.
        /// </summary>
        /// <param name="id">The id of voice endpoint.</param>
        [Delete("/api/texttospeech/v2.0/endpoints/{id}")]
        Task DeleteDeploymentAsync([Path] string id);

        /// <summary>
        /// Updates the name and description of the endpoint identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the endpoint.</param>
        /// <param name="content">The updated values for the endpoint.</param>
        [Patch("/api/texttospeech/v2.0/endpoints/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Endpoint> UpdateVoiceEndpointAsync([Path] string id, [Body] EndpointMetadataUpdate content);

        /// <summary>
        /// Gets a list of supported locales for custom voice endpoints.
        /// </summary>
        [Get("/api/texttospeech/v2.0/endpoints/locales")]
        Task<string[]> GetSupportedLocalesForVoiceEndpointsAsync();

        /// <summary>
        /// Gets a list of voice model details.
        /// </summary>
        [Get("/api/texttospeech/v2.0/models")]
        Task<Model[]> GetVoiceModelsAsync();

        /// <summary>
        /// Creates a new voice model object.
        /// </summary>
        /// <param name="content"></param>
        [Post("/api/texttospeech/v2.0/models")]
        [Header("Content-Type", "application/json")]
        Task CreateVoiceModelAsync([Body] IModelDefinitionV2 content);

        /// <summary>
        /// Gets specified voice model details.
        /// </summary>
        /// <param name="id"></param>
        [Get("/api/texttospeech/v2.0/models/{id}")]
        Task<Model> GetVoiceModelAsync([Path] string id);

        /// <summary>
        /// Deletes the voice model with the given id.
        /// </summary>
        /// <param name="id">The identifier of the voice model.</param>
        [Delete("/api/texttospeech/v2.0/models/{id}")]
        Task DeleteVoiceModelAsync([Path] string id);

        /// <summary>
        /// Updates the metadata of the voice model identified by the given ID.
        /// </summary>
        /// <param name="id">The identifier of the voice model.</param>
        /// <param name="content">The updated values for the voice model.</param>
        [Patch("/api/texttospeech/v2.0/models/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Model> UpdateVoiceModelAsync([Path] string id, [Body] ModelUpdate content);

        /// <summary>
        /// Gets a list of supported locales for custom voice models.
        /// </summary>
        [Get("/api/texttospeech/v2.0/models/locales")]
        Task<string[]> GetSupportedLocalesForVoiceModelsAsync();

        /// <summary>
        /// Gets details of all voice test under the selected subscription.
        /// </summary>
        [Get("/api/texttospeech/v2.0/tests")]
        Task<VoiceTest[]> GetVoiceTestsAsync();

        /// <summary>
        /// Creates a new voice test.
        /// </summary>
        /// <param name="content"></param>
        [Post("/api/texttospeech/v2.0/tests")]
        [Header("Content-Type", "application/json")]
        Task CreateVoiceTestAsync([Body] VoiceTestDefinition content);

        /// <summary>
        /// Gets detail of the specified voice test.
        /// </summary>
        /// <param name="id">The identifier of the voice test.</param>
        [Get("/api/texttospeech/v2.0/tests/{id}")]
        Task<VoiceTest> GetVoiceTestAsync([Path] string id);

        /// <summary>
        /// Deletes the specified voice test.
        /// </summary>
        /// <param name="id">The identifier of the voice test.</param>
        [Delete("/api/texttospeech/v2.0/tests/{id}")]
        Task DeleteVoiceTestAsync([Path] string id);

        /// <summary>
        /// Gets details of the specified model's voice test.
        /// </summary>
        /// <param name="id">The identifier of the voice test.</param>
        [Get("/api/texttospeech/v2.0/tests/model/{id}")]
        Task<VoiceTest[]> GetVoiceTestsForModelAsync([Path] string id);
    }
}
