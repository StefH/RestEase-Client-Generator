using System.Threading.Tasks;
using BlazorApp.Services;
using BlazorDownloadFile;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
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

            // 3rd Party
            builder.Services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            builder.Services.AddBlazorDownloadFile();

            // Own Services
            builder.Services.AddSingleton<IGenerator, Generator>();
            builder.Services.AddSingleton<IRestEaseCodeGenerator, RestEaseCodeGenerator>();

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}