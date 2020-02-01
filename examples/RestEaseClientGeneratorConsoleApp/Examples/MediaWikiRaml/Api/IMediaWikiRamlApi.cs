using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.MediaWikiRaml.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.MediaWikiRaml.Api
{
    /// <summary>
    /// The MediaWiki action API is a web service that provides convenient access to wiki features, data, and meta-data over HTTP, via a URL usually at api.php
    /// </summary>
    public interface IMediaWikiRamlApi
    {
        /// <summary>
        /// GetHelloworld (/helloworld)
        /// </summary>
        [Get("/helloworld")]
        Task GetHelloworldAsync();

        /// <summary>
        /// Put (/)
        /// </summary>
        [Put("/")]
        Task PutAsync();

        /// <summary>
        /// Get (/)
        /// </summary>
        [Get("/")]
        Task<GetAnyOfResult> GetAsync();
    }
}
