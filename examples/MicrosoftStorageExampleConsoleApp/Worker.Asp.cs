using System.Text.Json;
using Microsoft.Extensions.Logging;
using MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models;

namespace MicrosoftExampleConsoleApp;

internal partial class Worker
{
    public async Task RunWebAspAsync()
    {
        try
        {
            var asp = await _web.AppServicePlansGetAsync(sub, "stef-ResourceGroup-WestEuropa", "WestEuropePlan");
            _logger.LogInformation("AppServicePlansGetAsync = '{asp}'", JsonSerializer.Serialize(asp.GetContent().CurrentValue, _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        try
        {
            var plan = new AppServicePlan
            {
                Sku = new SkuDescription
                {
                    Name = "Y1",
                    Tier = "Dynamic",
                    Size = "Y1",
                    Family = "Y"
                },
                Kind = "functionapp",
                Location = "West Europe"
            };
            var asp = await _web.AppServicePlansCreateOrUpdateAsync(sub, "stef-ResourceGroup-WestEuropa", "RestEaseTestPlan2", plan);
            _logger.LogInformation("AppServicePlansCreateOrUpdateAsync = '{asp}'", JsonSerializer.Serialize(asp.GetContent().CurrentValue, _options));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}

/*
{
  "Properties": {
    "WorkerTierName": null,
    "Status": "Ready",
    "Subscription": "2de19637-27a3-42a8-812f-2c2a7f7f935c",
    "HostingEnvironmentProfile": null,
    "MaximumNumberOfWorkers": 0,
    "GeoRegion": "West Europe",
    "PerSiteScaling": false,
    "ElasticScaleEnabled": false,
    "MaximumElasticWorkerCount": 1,
    "NumberOfSites": 2,
    "IsSpot": false,
    "SpotExpirationTime": "0001-01-01T00:00:00",
    "FreeOfferExpirationTime": "0001-01-01T00:00:00",
    "ResourceGroup": "stef-ResourceGroup-WestEuropa",
    "Reserved": false,
    "IsXenon": false,
    "HyperV": false,
    "TargetWorkerCount": 0,
    "TargetWorkerSizeId": 0,
    "ProvisioningState": "Succeeded",
    "KubeEnvironmentProfile": null,
    "ZoneRedundant": false
  },
  
  "ExtendedLocation": null,
  "Id": "/subscriptions/2de19637-27a3-42a8-812f-2c2a7f7f935c/resourceGroups/stef-ResourceGroup-WestEuropa/providers/Microsoft.Web/serverfarms/WestEuropePlan",
  "Name": "WestEuropePlan",
  "Kind": "functionapp",
  "Location": "West Europe",
  "Type": "Microsoft.Web/serverfarms",
  "Tags": null
}'
*/