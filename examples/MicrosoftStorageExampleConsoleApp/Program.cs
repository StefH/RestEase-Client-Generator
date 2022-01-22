using AnyOfTypes.Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Readers;
using MicrosoftExampleConsoleApp;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Api;
using MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Api;
using Newtonsoft.Json;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

//Generate20190401();
Generate20210401();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

await using ServiceProvider serviceProvider = RegisterServices(args);

Worker worker = serviceProvider.GetRequiredService<Worker>();

await worker.RunAsync(CancellationToken.None);

static void Generate20190401()
{
    var generator = new Generator();

    var storageSettings = new GeneratorSettings
    {
        Namespace = "MicrosoftExampleConsoleApp.MicrosoftStorage20190401",
        ApiName = "MicrosoftStorage20190401",
        SingleFile = false,
        PreferredMultipleResponsesType = MultipleResponsesType.AnyOf,
        PreferredSecurityDefinitionType = SecurityDefinitionType.None,
        GenerationType = GenerationType.Both
    };

    const string x = @"C:\Dev\azure-rest-api-specs\specification\storage\resource-manager\Microsoft.Storage\stable\2019-04-01\storage.json";
    foreach (var file in generator.FromFile(x, storageSettings, out OpenApiDiagnostic diagnosticStorage))
    {
        Console.WriteLine("Generating file-type '{0}': {1}\\{2}", file.FileType, file.Path, file.Name);
        File.WriteAllText($"../../../MicrosoftStorage20190401/{file.Path}/{file.Name}", file.Content);
    }
}

static void Generate20210401()
{
    var generator = new Generator();

    var storageSettings = new GeneratorSettings
    {
        Namespace = "MicrosoftExampleConsoleApp.MicrosoftStorage",
        ApiName = "MicrosoftStorage",
        SingleFile = false,
        PreferredMultipleResponsesType = MultipleResponsesType.AnyOf,
        PreferredSecurityDefinitionType = SecurityDefinitionType.None,
        GenerationType = GenerationType.Both
    };

    const string x = @"C:\Dev\azure-rest-api-specs\specification\storage\resource-manager\Microsoft.Storage\stable\2021-04-01\storage.json";
    foreach (var file in generator.FromFile(x, storageSettings, out OpenApiDiagnostic diagnosticStorage))
    {
        Console.WriteLine("Generating file-type '{0}': {1}\\{2}", file.FileType, file.Path, file.Name);
        File.WriteAllText($"../../../MicrosoftStorage/{file.Path}/{file.Name}", file.Content);
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
        .UseWithAzureAuthenticatedRestEaseClient<IMicrosoftStorage20190401Api>(
            configuration.GetSection("ManagementOptions"),
            c =>
            {
                c.JsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter> { new AnyOfJsonConverter() }
                };
            });


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
