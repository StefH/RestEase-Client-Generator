using AnyOfTypes.Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Readers;
using MicrosoftExampleConsoleApp;
using MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Api;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Api;
using Newtonsoft.Json;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

GenerateMicrosoftContainerInstance20211001();
GenerateMicrosoftStorage20210401();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

await using ServiceProvider serviceProvider = RegisterServices(args);

await serviceProvider.GetRequiredService<Worker>().RunAsync(CancellationToken.None);

static void GenerateMicrosoftStorage20210401()
{
    var generator = new Generator();

    var storageSettings = new GeneratorSettings
    {
        Namespace = "MicrosoftExampleConsoleApp.MicrosoftStorage",
        ApiName = "MicrosoftStorage",
        SingleFile = false,
        PreferredSecurityDefinitionType = SecurityDefinitionType.None,
        ConstantQueryParameters = new Dictionary<string, string> { { "api-version", "2021-04-01" } }
    };

    const string x = @"C:\Dev\azure-rest-api-specs\specification\storage\resource-manager\Microsoft.Storage\stable\2021-04-01\storage.json";
    foreach (var file in Directory.GetFiles("../../../MicrosoftStorage/Models", "*.cs"))
    {
        File.Delete(file);
    }
    foreach (var file in generator.FromFile(x, storageSettings, out OpenApiDiagnostic diagnosticStorage))
    {
        // Console.WriteLine("Generating file-type '{0}': {1}\\{2}", file.FileType, file.Path, file.Name);
        File.WriteAllText($"../../../MicrosoftStorage/{file.Path}/{file.Name}", file.Content);
    }
}

static void GenerateMicrosoftContainerInstance20211001()
{
    var generator = new Generator();

    var storageSettings = new GeneratorSettings
    {
        Namespace = "MicrosoftExampleConsoleApp.MicrosoftContainerInstance",
        ApiName = "MicrosoftContainerInstance",
        SingleFile = false,
        PreferredSecurityDefinitionType = SecurityDefinitionType.None,
        ConstantQueryParameters = new Dictionary<string, string> { { "api-version", "2021-10-01" } }
    };

    const string x = @"C:\Dev\azure-rest-api-specs\specification\containerinstance\resource-manager\Microsoft.ContainerInstance\stable\2021-10-01\containerInstance.json";

    foreach (var file in Directory.GetFiles("../../../MicrosoftContainerInstance/Models", "*.cs"))
    {
       File.Delete(file);
    }
    foreach (var file in generator.FromFile(x, storageSettings, out var xxxx))
    {
        Console.WriteLine("Generating file-type '{0}': {1}\\{2}", file.FileType, file.Path, file.Name);
        File.WriteAllText($"../../../MicrosoftContainerInstance/{file.Path}/{file.Name}", file.Content);
    }
}

static ServiceProvider RegisterServices(string[] args)
{
    IConfiguration configuration = SetupConfiguration(args);
    var services = new ServiceCollection();

    services.AddSingleton(configuration);

    services.AddLogging(builder => builder.AddSerilog(logger: Log.Logger, dispose: true));

    services
        .UseWithAzureAuthenticatedRestEaseClient<IMicrosoftStorageApi>(
            configuration.GetSection("ManagementOptions"),
            c =>
            {
                c.JsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter> { new AnyOfJsonConverter() }
                };
            })
        .UseWithAzureAuthenticatedRestEaseClient<IMicrosoftContainerInstanceApi>(
            configuration.GetSection("ManagementOptions"),
            c =>
            {
                c.JsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter> { new AnyOfJsonConverter() }
                };
            })
        ;


    services.AddSingleton<Worker>();

    return services.BuildServiceProvider();
}

static IConfiguration SetupConfiguration(string[] args)
{
    return new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();
}
