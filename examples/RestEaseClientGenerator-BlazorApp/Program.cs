using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RestEaseClientGenerator;
using RestEaseClientGeneratorBlazorApp.Services;

namespace RestEaseClientGeneratorBlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons()
                .AddBlazorDownloadFile();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            // Own Services
            builder.Services.AddSingleton<IGenerator, Generator>();
            builder.Services.AddSingleton<IRestEaseCodeGenerator, RestEaseCodeGenerator>();
            builder.Services.AddSingleton<IFileZipper, FileZipper>();

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
