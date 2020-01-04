using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Api
{
    public static class SpeechServicesApiExtensions
    {
        /// <summary>
        /// Uploads data and creates a new dataset.
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="name">The name of this data import (always add this string for any import).</param>
        /// <param name="description">Optional description of this data import.</param>
        /// <param name="locale">The locale of this data import (always add this string for any import).</param>
        /// <param name="dataImportKind">The kind of the data import (always add this string for any import).</param>
        /// <param name="properties">Optional properties of this data import (json serialized object with key/values, where all values must be strings)</param>
        /// <param name="audiodata">A zip file containing the audio data (this and the audio archive file for acoustic data imports).</param>
        /// <param name="transcriptions">A text file containing the transcriptions for the audio data (this and the transcriptions file for acoustic data imports).</param>
        /// <param name="languagedata">A text file containing the language or pronunciation data (only this file for language data imports).</param>
        public static Task UploadDatasetAsync(this ISpeechServicesApi api, string name, string description, string locale, string dataImportKind, string properties, byte[] audiodata, byte[] transcriptions, byte[] languagedata)
        {
            var content = new MultipartFormDataContent();

            var audiodataContent = new ByteArrayContent(audiodata);
            content.Add(audiodataContent);

            var transcriptionsContent = new ByteArrayContent(transcriptions);
            content.Add(transcriptionsContent);

            var languagedataContent = new ByteArrayContent(languagedata);
            content.Add(languagedataContent);

            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("name", name.ToString()),
                new KeyValuePair<string, string>("description", description.ToString()),
                new KeyValuePair<string, string>("locale", locale.ToString()),
                new KeyValuePair<string, string>("dataImportKind", dataImportKind.ToString()),
                new KeyValuePair<string, string>("properties", properties.ToString())
            });

            content.Add(formUrlEncodedContent);
            return api.UploadDatasetAsync(content);
        }

        /// <summary>
        /// Uploads data and creates a new voice data object.
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="projectId">The optional string representation of a project ID. If set, the dataset will be associated with that project.</param>
        /// <param name="name">The name of this data import (always add this string for any import).</param>
        /// <param name="description">Optional description of this data import.</param>
        /// <param name="locale">The locale of this data import (always add this string for any import).</param>
        /// <param name="dataImportKind">The kind of the data import (always add this string for any import).</param>
        /// <param name="properties">Optional properties of this data import (json serialized object with key/values, where all values must be strings)</param>
        /// <param name="audiodata">A zip file containing the audio data.</param>
        /// <param name="transcriptions">The transcriptions text file of the audio data.</param>
        public static Task UploadVoiceDatasetAsync(this ISpeechServicesApi api, string projectId, string name, string description, string locale, string dataImportKind, string properties, byte[] audiodata, byte[] transcriptions)
        {
            var content = new MultipartFormDataContent();

            var audiodataContent = new ByteArrayContent(audiodata);
            content.Add(audiodataContent);

            var transcriptionsContent = new ByteArrayContent(transcriptions);
            content.Add(transcriptionsContent);

            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("projectId", projectId.ToString()),
                new KeyValuePair<string, string>("name", name.ToString()),
                new KeyValuePair<string, string>("description", description.ToString()),
                new KeyValuePair<string, string>("locale", locale.ToString()),
                new KeyValuePair<string, string>("dataImportKind", dataImportKind.ToString()),
                new KeyValuePair<string, string>("properties", properties.ToString())
            });

            content.Add(formUrlEncodedContent);
            return api.UploadVoiceDatasetAsync(content);
        }
    }
}
