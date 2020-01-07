using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Api
{
    public interface IComputerVisionApi
    {
        [Header("Ocp-Apim-Subscription-Key")]
        string OcpApimSubscriptionKey { get; set; }

        /// <summary>
        /// Analyze Image
        /// </summary>
        /// <param name="visualFeatures">A string indicating what visual feature types to return. Multiple values should be comma-separated. Valid visual feature types include:	Adult - detects if the image is pornographic in nature (depicts nudity or a sex act), or is gory (depicts extreme violence or blood). Sexually suggestive content (aka racy content) is also detected.Brands - detects various brands within an image, including the approximate location. The Brands argument is only available in English.Categories - categorizes image content according to a taxonomy defined in documentation. Color - determines the accent color, dominant color, and whether an image is black&white.Description - describes the image content with a complete sentence in supported languages. Faces - detects if faces are present. If present, generate coordinates, gender and age. ImageType - detects if image is clipart or a line drawing.Objects - detects various objects within an image, including the approximate location. The Objects argument is only available in English.Tags - tags the image with a detailed list of words related to the image content. </param>
        /// <param name="details">A string indicating which domain-specific details to return. Multiple values should be comma-separated. Valid visual feature types include:	Celebrities - identifies celebrities if detected in the image.Landmarks - identifies landmarks if detected in the image.</param>
        /// <param name="language">A string indicating which language to return. The service will return recognition results in specified language. If this parameter is not specified, the default value is &quot;en&quot;.Supported languages:en - English, Default.es - Spanish.ja - Japanese.pt - Portuguese.zh - Simplified Chinese.</param>
        [Post("/analyze")]
        [Header("Content-Type", "application/json")]
        Task PostAnalyzeAsync([Query] string visualFeatures, [Query] string details, [Query] string language);

        /// <summary>
        /// Batch Read File
        /// </summary>
        [Post("/read/core/asyncBatchAnalyze")]
        [Header("Content-Type", "application/json")]
        Task PostReadCoreAsyncBatchAnalyzeAsync();

        /// <summary>
        /// Describe Image
        /// </summary>
        /// <param name="maxCandidates">Maximum number of candidate descriptions to be returned.  The default is 1.</param>
        /// <param name="language">A string indicating the language in which the service will return a description of the image. If this parameter is not specified, the default value is &quot;en&quot;.Supported languages:en - English, Default.es - Spanish.ja - Japanese.pt - Portuguese.zh - Simplified Chinese.</param>
        [Post("/describe")]
        [Header("Content-Type", "application/json")]
        Task PostDescribeAsync([Query] string maxCandidates, [Query] string language);

        /// <summary>
        /// Detect Objects
        /// </summary>
        [Post("/detect")]
        [Header("Content-Type", "application/json")]
        Task PostDetectAsync();

        /// <summary>
        /// Get Area of Interest
        /// </summary>
        [Post("/areaOfInterest")]
        [Header("Content-Type", "application/json")]
        Task B156d0f5e11e492d9f64418dAsync();

        /// <summary>
        /// Get Recognize Text Operation Result
        /// </summary>
        /// <param name="operationId">Id of the text operation returned in the response of the Recognize Text interface.</param>
        [Get("/textOperations/{operationId}")]
        Task GetTextOperationsByOperationIdAsync([Path] string operationId);

        /// <summary>
        /// Get Thumbnail
        /// </summary>
        /// <param name="width">Width of the thumbnail.  It must be between 1 and 1024. Recommended minimum of 50.</param>
        /// <param name="height">Height of the thumbnail. It must be between 1 and 1024. Recommended minimum of 50.</param>
        /// <param name="smartCropping">Boolean flag for enabling smart cropping.</param>
        [Post("/generateThumbnail")]
        [Header("Content-Type", "application/json")]
        Task PostGenerateThumbnailAsync([Query] double width, [Query] double height, [Query] bool? smartCropping);

        /// <summary>
        /// List Domain Specific Models
        /// </summary>
        [Get("/models")]
        Task GetModelsAsync();

        /// <summary>
        /// OCR
        /// </summary>
        /// <param name="language">The BCP-47 language code of the text to be detected in the image.The default value is &quot;unk&quot;, then the service will auto detect the language of the text in the image.        Supported languages:    <ul style="margin-left:.375in;direction:ltr;unicode-bidi:embed; margin-top:0in;margin-bottom:0in" type="disc">        unk (AutoDetect)        zh-Hans (ChineseSimplified)        zh-Hant (ChineseTraditional)        cs (Czech)        da (Danish)        nl (Dutch)        en (English)        fi (Finnish)        fr (French)        de (German)        el (Greek)        hu (Hungarian)        it (Italian)        ja (Japanese)        ko (Korean)        nb (Norwegian)        pl (Polish)        pt (Portuguese,        ru (Russian)        es (Spanish)        sv (Swedish)        tr (Turkish)        ar (Arabic)        ro (Romanian)        sr-Cyrl (SerbianCyrillic)        sr-Latn (SerbianLatin)        sk (Slovak)</param>
        /// <param name="detectOrientation">Whether detect the text orientation in the image. With detectOrientation=true the OCR service tries to detect the image orientation and correct it before further processing (e.g. if it's upside-down).</param>
        [Post("/ocr")]
        [Header("Content-Type", "application/json")]
        Task PostOcrAsync([Query] string language, [Query] bool? detectOrientation);

        /// <summary>
        /// Get Read Operation Result
        /// </summary>
        /// <param name="operationId">Id of read operation returned in the response of the Batch Read File interface.</param>
        [Get("/read/operations/{operationId}")]
        Task GetReadOperationsByOperationIdAsync([Path] string operationId);

        /// <summary>
        /// Recognize Domain Specific Content
        /// </summary>
        /// <param name="model">The domain-specific content to recognize.</param>
        /// <param name="language">A string indicating the language in which to return analysis results, if supported. If this parameter is not specified, the default value is &quot;en&quot;.Possible language values:en - English, Default.es - Spanish.ja - Japanese.pt - Portuguese.zh - Simplified Chinese.</param>
        [Post("/models/{model}/analyze")]
        [Header("Content-Type", "application/json")]
        Task PostModelsByModelAnalyzeAsync([Path] string model, [Query] string language);

        /// <summary>
        /// Recognize Text
        /// </summary>
        /// <param name="mode">If this parameter is set to "Printed", printed text recognition is performed. If "Handwritten" is specified, handwriting recognition is performed. (Note: This parameter is case sensitive.) This is a required parameter and cannot be empty.​</param>
        [Post("/recognizeText")]
        [Header("Content-Type", "application/json")]
        Task PostRecognizeTextAsync([Query] string mode);

        /// <summary>
        /// Tag Image
        /// </summary>
        /// <param name="language">A string indicating the language in which to return tags. If this parameter is not specified, the default value is &quot;en&quot;.Supported languages:en - English, Default.es - Spanish.ja - Japanese.pt - Portuguese.zh - Simplified Chinese.</param>
        [Post("/tag")]
        [Header("Content-Type", "application/json")]
        Task PostTagAsync([Query] string language);
    }
}
