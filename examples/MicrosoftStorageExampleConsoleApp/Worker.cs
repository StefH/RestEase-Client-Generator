using System.Text.Json;
using Microsoft.Extensions.Logging;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Api;

namespace MicrosoftExampleConsoleApp;

internal class Worker
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    private readonly IMicrosoftStorageApi _storageApi;
    private readonly ILogger<Worker> _logger;

    public Worker(IMicrosoftStorageApi storageApi, ILogger<Worker> logger)
    {
        _storageApi = storageApi;
        // _storageApi.SubscriptionId = "xxx";

        _logger = logger;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var skus = await _storageApi.SkusListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
            _logger.LogInformation("IDocumentApi : GetDocumentAsync = '{doc}'", JsonSerializer.Serialize(skus, _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}