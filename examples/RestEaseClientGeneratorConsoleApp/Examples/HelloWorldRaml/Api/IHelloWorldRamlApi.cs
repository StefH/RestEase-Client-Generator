using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace RestEaseClientGeneratorConsoleApp.Examples.HelloWorldRaml.Api
{
    /// <summary>
    /// HelloWorldRaml
    /// </summary>
    public interface IHelloWorldRamlApi
    {
        /// <summary>
        /// GetHelloworld (/helloworld)
        /// </summary>
        [Get("/helloworld")]
        Task GetHelloworldAsync();
    }
}
