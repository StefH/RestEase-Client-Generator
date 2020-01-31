using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.MediaWiki.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.MediaWiki.Api
{
    /// <summary>
    /// The MediaWiki action API is a web service that provides convenient access to wiki features, data, and meta-data over HTTP, via a URL usually at api.php
    /// </summary>
    public interface IMediaWikiApi
    {
        /// <summary>
        /// GETHelloworld (/helloworld)
        /// </summary>
        [Get("/helloworld")]
        Task GETHelloworldAsync();

        /// <summary>
        /// PUTRoot (/)
        /// </summary>
        [Put("/")]
        [Header("Content-Type", "application/json")]
        Task PUTRootAsync();

        /// <summary>
        /// GETRoot (/)
        /// </summary>
        /// <param name="action"></param>
        /// <param name="titles"></param>
        /// <param name="format"></param>
        /// <param name="redirects"></param>
        /// <param name="generator"></param>
        /// <param name="export"></param>
        /// <param name="indexpageids"></param>
        [Get("/")]
        Task GETRootAsync([Query] string action, [Query] string titles, [Query] string format, [Query] string redirects, [Query] string generator, [Query] string export, [Query] string indexpageids);
    }
}
