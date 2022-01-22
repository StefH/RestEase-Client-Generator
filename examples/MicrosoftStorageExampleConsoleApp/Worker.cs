using System.Text.Json;
using Microsoft.Extensions.Logging;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Api;
using MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Api;
using MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models;

namespace MicrosoftExampleConsoleApp;

internal class Worker
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    private readonly IMicrosoftStorageApi _storageApi;
    private readonly IMicrosoftStorage20190401Api _storageApi2019;
    private readonly ILogger<Worker> _logger;

    public Worker(IMicrosoftStorageApi storageApi, IMicrosoftStorage20190401Api storageApi2019, ILogger<Worker> logger)
    {
        _storageApi = storageApi;
        _storageApi.ApiVersion = "2021-08-01";

        _storageApi2019 = storageApi2019;
        _storageApi2019.ApiVersion = "2019-04-01";

        _logger = logger;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        //try
        //{
        //    var operations = await _storageApi.OperationsListAsync();
        //    _logger.LogInformation("OperationsListAsync = '{operations}'", JsonSerializer.Serialize(operations, _options));
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //}

        //try
        //{
        //    var skus = await _storageApi.SkusListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
        //    _logger.LogInformation("SkusListAsync = '{skus}'", JsonSerializer.Serialize(skus, _options));
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //}

        //try
        //{
        //    var sa = await _storageApi.StorageAccountsListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
        //    _logger.LogInformation("StorageAccountsListAsync = '{sa}'", JsonSerializer.Serialize(sa, _options));
        //}
        //catch (Exception ex)
        //{
        //    // Console.WriteLine(ex);
        //    // Fails with Error converting value {null} to type 'System.DateTime'. Path 'value[0].properties.keyCreationTime.key1', line 1, position 361.
        //}

        try
        {
            var sa = await _storageApi2019.StorageAccountsListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
            _logger.LogInformation("_storageApi2019.StorageAccountsListAsync = '{sa}'", JsonSerializer.Serialize(sa, _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        try
        {
            var content = new StorageAccountCreateParameters
            {
                Sku = new Sku
                {
                    Kind = "Standard_RAGRS",
                    Tier = "Standard"
                },
                Kind = "StorageV2",
                Location = "westeurope",
                Properties = new StorageAccountPropertiesCreateParameters
                {
                    IsHnsEnabled = true,
                    AllowBlobPublicAccess = false,
                    AllowSharedKeyAccess = false
                }
            };

            var sa = await _storageApi2019.StorageAccountsCreateAsync("stef-resourcegroup-westeuropa", "test123", "2de19637-27a3-42a8-812f-2c2a7f7f935c", content);
            _logger.LogInformation("_storageApi2019.StorageAccountsListAsync = '{sa}'", JsonSerializer.Serialize(sa.CurrentValue, _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}