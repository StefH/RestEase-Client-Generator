using System.Text.Json;
using AnyOfTypes.System.Text.Json;
using Microsoft.Extensions.Logging;
using MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Api;
using MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Api;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Models;
using MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Api;

namespace MicrosoftExampleConsoleApp;

internal class Worker
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new AnyOfJsonConverter() }
    };

    private readonly IMicrosoftStorageApi _storageApi;
    private readonly IMicrosoftStorage20190401Api _storageApi2019;
    private readonly IMicrosoftContainerInstanceApi _aci;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IMicrosoftStorageApi storageApi,
        IMicrosoftStorage20190401Api storageApi2019,
        IMicrosoftContainerInstanceApi aci,
        ILogger<Worker> logger)
    {
        _storageApi = storageApi;
        _storageApi.ApiVersion = "2021-04-01";

        _storageApi2019 = storageApi2019;
        _storageApi2019.ApiVersion = "2019-04-01";

        _aci = aci;

        _logger = logger;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        const string sub = "2de19637-27a3-42a8-812f-2c2a7f7f935c";
        const string rg = "testformanagementsdk";

        try
        {
            var aci = await _aci.ContainerGroupsListAsync("2de19637-27a3-42a8-812f-2c2a7f7f935c");
            _logger.LogInformation("ContainerGroupsListAsync = '{aci}'", JsonSerializer.Serialize(aci.GetContent(), _options));
            
            foreach (var cg in aci.GetContent().First.Value.Where(x => x.Name.StartsWith("acistef")))
            {
                _logger.LogWarning("Deleting : {name}", cg.Name);
                var d = await _aci.ContainerGroupsDeleteAsync(
                    sub,
                    rg,
                    cg.Name);
                _logger.LogInformation("ContainerGroupsDeleteAsync = '{d}'", JsonSerializer.Serialize(d.GetContent().CurrentValue, _options));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        try
        {
            var name = ("stef" + Guid.NewGuid().ToString().Replace("-", "")).Substring(0, 10);
            var cg = new ContainerGroup
            {
                Location = "westeurope",
                Properties = new Properties
                {
                    Containers = new[]
                    {
                        new Container
                        {
                            Name = $"container{name}",
                            Properties = new ContainerProperties
                            {
                                Image = "nginx",
                                Resources = new ResourceRequirements
                                {
                                    Requests = new ResourceRequests
                                    {
                                        Cpu = 1,
                                        MemoryInGB = 1.5
                                    }
                                }
                            }
                        }
                    },
                    OsType = OsTypeConstants.Linux
                }
            };
            var aci = await _aci.ContainerGroupsCreateOrUpdateAsync(
                "2de19637-27a3-42a8-812f-2c2a7f7f935c",
                "testformanagementsdk",
                $"aci{name}",
                cg);
            _logger.LogInformation("ContainerGroupsListAsync = '{aci}'", JsonSerializer.Serialize(aci.GetContent(), _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

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
                    Name = "Standard_LRS"
                },
                Kind = "StorageV2",
                Location = "westeurope"
            };

            var name = ("stef" + Guid.NewGuid().ToString().Replace("-", "")).Substring(0, 24);

            var sa1 = await _storageApi.StorageAccountsCreateAsync(
                "testformanagementsdk",
                name,
                "2de19637-27a3-42a8-812f-2c2a7f7f935c",
                content);
            _logger.LogInformation("_storageApi.StorageAccountsCreateAsync {status} = '{sa}'", sa1.ResponseMessage.StatusCode, sa1.StringContent);

            Console.WriteLine("waiting...");
            await Task.Delay(5000, cancellationToken).ConfigureAwait(false);

            var sa2 = await _storageApi.StorageAccountsCreateAsync(
                "testformanagementsdk",
                name,
                "2de19637-27a3-42a8-812f-2c2a7f7f935c",
                content);
            _logger.LogInformation("_storageApi.StorageAccountsCreateAsync {status} = '{sa}'", sa2.ResponseMessage.StatusCode, sa2.GetContent().First.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}