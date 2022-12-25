using Newtonsoft.Json;

namespace ConsoleAppV2.Examples.dsmr.Models;

public class ElectricityLive
{
    public DateTime Timestamp { get; set; }

    [JsonProperty("currently_delivered")]
    public int CurrentlyDelivered { get; set; }

    [JsonProperty("currently_returned")]
    public int CurrentlyReturned { get; set; }

    [JsonProperty("cost_per_hour")]
    public object? CostPerHour { get; set; }

    [JsonProperty("tariff_name")]
    public string TariffName { get; set; } = null!;
}