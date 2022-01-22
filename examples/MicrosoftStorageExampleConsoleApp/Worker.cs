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

    private readonly IMicrosoftStorageApiWithSubscriptionId _storageApi;
    private readonly ILogger<Worker> _logger;

    public Worker(IMicrosoftStorageApiWithSubscriptionId storageApi, ILogger<Worker> logger)
    {
        _storageApi = storageApi;
        _storageApi.SubscriptionId = "xxx";

        _logger = logger;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var skus = await _storageApi.SkusListAsync();
            _logger.LogInformation("IDocumentApi : GetDocumentAsync = '{doc}'", JsonSerializer.Serialize(skus, _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}