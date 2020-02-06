using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Api
{
    /// <summary>
    /// The Computer Vision API provides state-of-the-art algorithms to process images and return information.  For example, it can be used to determine if an image contains mature content, or it can be used to find all the faces in an image.  It also has other features like estimating dominant and accent colors, categorizing the content of images, and describing an image with complete English sentences.  Additionally, it can also intelligently generate images thumbnails for displaying large images effectively.This API is currently available in:* Australia East - australiaeast.api.cognitive.microsoft.com* Brazil South - brazilsouth.api.cognitive.microsoft.com* Canada Central - canadacentral.api.cognitive.microsoft.com* Central India - centralindia.api.cognitive.microsoft.com* Central US - centralus.api.cognitive.microsoft.com* East Asia - eastasia.api.cognitive.microsoft.com* East US - eastus.api.cognitive.microsoft.com* East US 2 - eastus2.api.cognitive.microsoft.com* France Central - francecentral.api.cognitive.microsoft.com* Japan East - japaneast.api.cognitive.microsoft.com* Japan West - japanwest.api.cognitive.microsoft.com* Korea Central - koreacentral.api.cognitive.microsoft.com* North Central US - northcentralus.api.cognitive.microsoft.com* North Europe - northeurope.api.cognitive.microsoft.com* South Africa North - southafricanorth.api.cognitive.microsoft.com* South Central US - southcentralus.api.cognitive.microsoft.com* Southeast Asia - southeastasia.api.cognitive.microsoft.com* UK South - uksouth.api.cognitive.microsoft.com* West Central US - westcentralus.api.cognitive.microsoft.com* West Europe - westeurope.api.cognitive.microsoft.com* West US - westus.api.cognitive.microsoft.com* West US 2 - westus2.api.cognitive.microsoft.com
    /// </summary>
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
        Task PostAnalyzeAsync([Query] VisualFeatures visualFeatures, [Query] Details details, [Query] Language language);

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
        Task PostDescribeAsync([Query] MaxCandidates maxCandidates, [Query] Language language);

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
        Task PostOcrAsync([Query] Language1 language, [Query] bool? detectOrientation);

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
        Task PostModelsByModelAnalyzeAsync([Path] string model, [Query] Language language);

        /// <summary>
        /// Recognize Text
        /// </summary>
        /// <param name="mode">If this parameter is set to "Printed", printed text recognition is performed. If "Handwritten" is specified, handwriting recognition is performed. (Note: This parameter is case sensitive.) This is a required parameter and cannot be empty.​</param>
        [Post("/recognizeText")]
        [Header("Content-Type", "application/json")]
        Task PostRecognizeTextAsync([Query] Mode mode);

        /// <summary>
        /// Tag Image
        /// </summary>
        /// <param name="language">A string indicating the language in which to return tags. If this parameter is not specified, the default value is &quot;en&quot;.Supported languages:en - English, Default.es - Spanish.ja - Japanese.pt - Portuguese.zh - Simplified Chinese.</param>
        [Post("/tag")]
        [Header("Content-Type", "application/json")]
        Task PostTagAsync([Query] Language language);
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models
{
    public enum VisualFeatures
    {
        Adult,
        Brands,
        Categories,
        Color,
        Description,
        Faces,
        ImageType,
        Objects,
        Tags
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models
{
    public enum Details
    {
        Celebrities,
        Landmarks
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models
{
    public enum Language
    {
        en,
        es,
        ja,
        pt,
        zh
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models
{
    public enum MaxCandidates
    {
        a1
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models
{
    public enum Language1
    {
        unk,
        zh_Hans,
        zh_Hant,
        cs,
        da,
        nl,
        en,
        fi,
        fr,
        de,
        el,
        hu,
        it,
        ja,
        ko,
        nb,
        pl,
        pt,
        ru,
        es,
        sv,
        tr,
        ar,
        ro,
        sr_Cyrl,
        sr_Latn,
        sk
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.ComputerVision.Models
{
    public enum Mode
    {
        Handwritten,
        Printed
    }
}
