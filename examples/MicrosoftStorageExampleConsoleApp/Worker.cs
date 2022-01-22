using System.Text.Json;
using Microsoft.Extensions.Logging;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Api;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Models;
using MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Api;

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
        _storageApi.ApiVersion = "2021-04-01";

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

        try
        {
            var sa = await _storageApi.StorageAccountsListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
            // _logger.LogInformation("StorageAccountsListAsync = '{sa}'", JsonSerializer.Serialize(sa.GetContent(), _options));
        }
        catch (Exception ex)
        {
            // Console.WriteLine(ex);
            // Fails with Error converting value {null} to type 'System.DateTime'. Path 'value[0].properties.keyCreationTime.key1', line 1, position 361.
        }

        try
        {
            // var sa = await _storageApi2019.StorageAccountsListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
            // _logger.LogInformation("_storageApi2019.StorageAccountsListAsync = '{sa}'", JsonSerializer.Serialize(sa.GetContent(), _options));
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
                    Name = "Standard_LRS",
                    Tier = "Standard"
                },
                Kind = "StorageV2",
                Location = "westeurope"
                //Properties = new StorageAccountPropertiesCreateParameters
                //{
                //    IsHnsEnabled = true,
                //    AllowBlobPublicAccess = false,
                //    AllowSharedKeyAccess = false
                //}
            };

            var name = ("stef" + Guid.NewGuid().ToString().Replace("-", "")).Substring(0, 24);

            var sa1 = await _storageApi.StorageAccountsCreateAsync(
                "testformanagementsdk",
                name,
                "2de19637-27a3-42a8-812f-2c2a7f7f935c",
                content);
            _logger.LogInformation("_storageApi.StorageAccountsCreateAsync {status} = '{sa}'", sa1.ResponseMessage.StatusCode, sa1.StringContent);
            //_logger.LogInformation("_storageApi.StorageAccountsCreateAsync 204 = '{sa}'", sa1.Second);

            Console.WriteLine("waiting...");
            await Task.Delay(5000, cancellationToken).ConfigureAwait(false);

            // Task<Response<AnyOf<StorageAccount, object>>> StorageAccountsCreateAsyncOK
            var sa2 = await _storageApi.StorageAccountsCreateAsync(
                "testformanagementsdk",
                name,
                "2de19637-27a3-42a8-812f-2c2a7f7f935c",
                content);
            _logger.LogInformation("_storageApi.StorageAccountsCreateAsync {status} = '{sa}'", sa2.ResponseMessage.StatusCode, sa2.GetContent().First.Id);
            //_logger.LogInformation("_storageApi.StorageAccountsCreateAsync 200 = '{sa}'", sa2.First.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}