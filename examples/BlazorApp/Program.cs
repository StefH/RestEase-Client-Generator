using System.Threading.Tasks;
using Blazor.FileReader;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RestEaseClientGenerator;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);

            builder.Services.AddSingleton<IGenerator, Generator>();
            builder.Services.AddSingleton<IRestEaseCodeGenerator, RestEaseCodeGenerator>();

            await builder.Build().RunAsync();
        }
    }
}