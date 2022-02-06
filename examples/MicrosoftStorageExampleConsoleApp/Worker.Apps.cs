using System.Text.Json;
using Microsoft.Extensions.Logging;
using MicrosoftExampleConsoleApp.MicrosoftWebApps.Models;


namespace MicrosoftExampleConsoleApp;

internal partial class Worker
{
    public async Task RunWebAppsAsync()
    {
        try
        {
            var app = await _apps.WebAppsGetAsync("Stef-SmartContract-FunctionApp", "stef-ResourceGroup-WestEuropa", sub);
            _logger.LogInformation("WebAppsGetAsync = '{asp}'", JsonSerializer.Serialize(app.GetContent().CurrentValue, _options));
            int x = 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        try
        {
            var site = new Site
            {
                Properties = new SiteProperties
                {
                    HttpsOnly = true,
                    ContainerSize = 1536
                },
                Kind = "functionapp",
                Location = "West Europe"
            };
            var x = await _apps.WebAppsCreateOrUpdateAsync("Stef-SmartContract-FunctionApp2", "stef-ResourceGroup-WestEuropa", sub, site);
            _logger.LogInformation("WebAppsCreateOrUpdateAsync = '{asp}'", JsonSerializer.Serialize(x.GetContent().CurrentValue, _options));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        //try
        //{
        //    var plan = new AppServicePlan
        //    {
        //        Sku = new SkuDescription
        //        {
        //            Name = "Y1",
        //            Tier = "Dynamic",
        //            Size = "Y1",
        //            Family = "Y"
        //        },
        //        Kind = "functionapp",
        //        Location = "West Europe"
        //    };
        //    var asp = await _web.AppServicePlansCreateOrUpdateAsync("RestEaseTestPlan", "stef-ResourceGroup-WestEuropa", sub, plan);
        //    _logger.LogInformation("AppServicePlansCreateOrUpdateAsync = '{asp}'", JsonSerializer.Serialize(asp.GetContent().CurrentValue, _options));
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //}
    }
}

/*
[12:26:46 INF] WebAppsGetAsync = '{
  "Properties": {
    "State": "Stopped",
    "HostNames": [
      "stef-smartcontract-functionapp.azurewebsites.net"
    ],
    "RepositorySiteName": "Stef-SmartContract-FunctionApp",
    "UsageState": "Normal",
    "Enabled": true,
    "EnabledHostNames": [
      "stef-smartcontract-functionapp.azurewebsites.net",
      "stef-smartcontract-functionapp.scm.azurewebsites.net"
    ],
    "AvailabilityState": "Normal",
    "HostNameSslStates": [
      {
        "Name": "stef-smartcontract-functionapp.azurewebsites.net",
        "SslState": "Disabled",
        "VirtualIP": null,
        "Thumbprint": null,
        "ToUpdate": false,
        "HostType": "Standard"
      },
      {
        "Name": "stef-smartcontract-functionapp.scm.azurewebsites.net",
        "SslState": "Disabled",
        "VirtualIP": null,
        "Thumbprint": null,
        "ToUpdate": false,
        "HostType": "Repository"
      }
    ],
    "ServerFarmId": "/subscriptions/2de19637-27a3-42a8-812f-2c2a7f7f935c/resourceGroups/stef-ResourceGroup-WestEuropa/providers/Microsoft.Web/serverfarms/WestEuropePlan",
    "Reserved": false,
    "IsXenon": false,
    "HyperV": false,
    "LastModifiedTimeUtc": "2022-02-06T11:25:24.9266667",
    "SiteConfig": {
      "NumberOfWorkers": 1,
      "DefaultDocuments": null,
      "NetFrameworkVersion": null,
      "PhpVersion": null,
      "PythonVersion": null,
      "NodeVersion": null,
      "PowerShellVersion": null,
      "LinuxFxVersion": "",
      "WindowsFxVersion": null,
      "RequestTracingEnabled": false,
      "RequestTracingExpirationTime": "0001-01-01T00:00:00",
      "RemoteDebuggingEnabled": false,
      "RemoteDebuggingVersion": null,
      "HttpLoggingEnabled": false,
      "AcrUseManagedIdentityCreds": false,
      "AcrUserManagedIdentityID": null,
      "LogsDirectorySizeLimit": 0,
      "DetailedErrorLoggingEnabled": false,
      "PublishingUsername": null,
      "AppSettings": null,
      "ConnectionStrings": null,
      "MachineKey": null,
      "HandlerMappings": null,
      "DocumentRoot": null,
      "ScmType": null,
      "Use32BitWorkerProcess": false,
      "WebSocketsEnabled": false,
      "AlwaysOn": false,
      "JavaVersion": null,
      "JavaContainer": null,
      "JavaContainerVersion": null,
      "AppCommandLine": null,
      "ManagedPipelineMode": null,
      "VirtualApplications": null,
      "LoadBalancing": null,
      "Experiments": null,
      "Limits": null,
      "AutoHealEnabled": false,
      "AutoHealRules": null,
      "TracingOptions": null,
      "VnetName": null,
      "VnetRouteAllEnabled": false,
      "VnetPrivatePortsCount": 0,
      "Cors": null,
      "Push": null,
      "ApiDefinition": null,
      "ApiManagementConfig": null,
      "AutoSwapSlotName": null,
      "LocalMySqlEnabled": false,
      "ManagedServiceIdentityId": 0,
      "XManagedServiceIdentityId": 0,
      "KeyVaultReferenceIdentity": null,
      "IpSecurityRestrictions": null,
      "ScmIpSecurityRestrictions": null,
      "ScmIpSecurityRestrictionsUseMain": false,
      "Http20Enabled": false,
      "MinTlsVersion": null,
      "ScmMinTlsVersion": null,
      "FtpsState": null,
      "PreWarmedInstanceCount": 0,
      "FunctionAppScaleLimit": 0,
      "HealthCheckPath": null,
      "FunctionsRuntimeScaleMonitoringEnabled": false,
      "WebsiteTimeZone": null,
      "MinimumElasticInstanceCount": 0,
      "AzureStorageAccounts": null,
      "PublicNetworkAccess": null
    },
    "TrafficManagerHostNames": null,
    "ScmSiteAlsoStopped": false,
    "TargetSwapSlot": null,
    "HostingEnvironmentProfile": null,
    "ClientAffinityEnabled": false,
    "ClientCertEnabled": false,
    "ClientCertMode": "Required",
    "ClientCertExclusionPaths": null,
    "HostNamesDisabled": false,
    "CustomDomainVerificationId": "1ED7CC089DF843E197D1694E3F692EB125AF313E5E025139A5E2D83DECFEC8EE",
    "OutboundIpAddresses": "52.178.32.213,13.95.223.21,13.81.115.28,13.81.115.53",
    "PossibleOutboundIpAddresses": "52.178.32.213,13.95.223.21,13.81.115.28,13.81.115.53,23.97.134.136,52.174.24.17,52.174.24.19,52.174.24.23,52.174.24.131,52.178.37.244,13.69.68.51",
    "ContainerSize": 1536,
    "DailyMemoryTimeQuota": 0,
    "SuspendedTill": "0001-01-01T00:00:00",
    "MaxNumberOfWorkers": 0,
    "CloningInfo": null,
    "ResourceGroup": "stef-ResourceGroup-WestEuropa",
    "IsDefaultContainer": false,
    "DefaultHostName": "stef-smartcontract-functionapp.azurewebsites.net",
    "SlotSwapStatus": null,
    "HttpsOnly": true,
    "RedundancyMode": "None",
    "InProgressOperationId": null,
    "StorageAccountRequired": false,
    "KeyVaultReferenceIdentity": "SystemAssigned",
    "VirtualNetworkSubnetId": null
  },
  "Identity": {
    "Type": "SystemAssigned",
    "TenantId": "020b0cf3-d6b2-464e-9b2d-45e124244428",
    "PrincipalId": "99227c2e-5e8d-41cf-a789-d7bd40b9d4d5",
    "UserAssignedIdentities": null
  },
  "ExtendedLocation": null,
  "Id": "/subscriptions/2de19637-27a3-42a8-812f-2c2a7f7f935c/resourceGroups/stef-ResourceGroup-WestEuropa/providers/Microsoft.Web/sites/Stef-SmartContract-FunctionApp",
  "Name": "Stef-SmartContract-FunctionApp",
  "Kind": "functionapp",
  "Location": "West Europe",
  "Type": "Microsoft.Web/sites",
  "Tags": {
    "hidden-related:/subscriptions/2de19637-27a3-42a8-812f-2c2a7f7f935c/resourceGroups/stef-ResourceGroup-WestEuropa/providers/Microsoft.Web/serverfarms/WestEuropePlan": "empty"
  }
}'
*/