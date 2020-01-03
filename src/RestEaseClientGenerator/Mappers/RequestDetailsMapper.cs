//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.OpenApi.Models;
//using RestEaseClientGenerator.Constants;
//using RestEaseClientGenerator.Extensions;
//using RestEaseClientGenerator.Models.Internal;
//using RestEaseClientGenerator.Settings;
//using RestEaseClientGenerator.Types;
//using RestEaseClientGenerator.Utils;

//namespace RestEaseClientGenerator.Mappers
//{
//    internal class RequestDetailsMapper
//    {
//        private readonly GeneratorSettings _settings;

//        public RequestDetailsMapper(GeneratorSettings settings)
//        {
//            _settings = settings;
//        }

//        public RequestDetails Map(KeyValuePair<string, OpenApiMediaType> detected)
//        {
//            if (detected.Key == SupportedContentType.MultipartFormData)
//            {
//                string httpContentDescription;
//                if (!_settings.GenerateMultipartFormDataExtensionMethods)
//                {
//                    httpContentDescription = "Manually add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
//                }
//                else
//                {
//                    httpContentDescription = "An extension method is generated to support the exact parameters.";
//                    extensionMethodParameterList.AddRange(detected.Value.Schema.Properties.Select(p => BuildValidParameter(p.Key, p.Value, p.Value.Nullable, p.Value.Description, string.Empty)));
//                }

//                bodyParameterList.Add(new RestEaseParameter
//                {
//                    Required = true,
//                    Identifier = "content",
//                    IdentifierWithType = "HttpContent content",
//                    IdentifierWithRestEase = "[Body] HttpContent content",
//                    Summary = httpContentDescription,
//                    IsSpecial = true
//                });

//                return new RequestDetails
//                {
//                    DetectedContentType = detectedMultipartForm,
//                    IsExtension = true
//                };
//            }

//            return null;
//        }
//    }
//}