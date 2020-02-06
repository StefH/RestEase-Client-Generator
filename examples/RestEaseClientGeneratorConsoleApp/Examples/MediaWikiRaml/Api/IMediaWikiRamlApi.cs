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
        Task<GetHelloworldResult> GetHelloworldAsync();

        /// <summary>
        /// Get (/)
        /// </summary>
        /// <param name="action"></param>
        /// <param name="titles"></param>
        /// <param name="format"></param>
        /// <param name="redirects"></param>
        /// <param name="generator"></param>
        /// <param name="export"></param>
        /// <param name="indexpageids"></param>
        [Get("/")]
        Task<GetAnyOfResult> GetAsync([Query] Models.Action action, [Query] Titles titles, [Query] Format format, [Query] string redirects, [Query] Generator generator, [Query] string export, [Query] string indexpageids);
    }
}
