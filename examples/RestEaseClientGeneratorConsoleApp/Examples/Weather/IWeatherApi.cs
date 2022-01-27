using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using Weather.Models;

namespace Weather.Api
{
    /// <summary>
    /// Weather
    /// </summary>
    public interface IWeatherApi
    {
        /// <summary>
        /// PostWeatherForecast (/WeatherForecast)
        /// </summary>
        /// <param name="content"></param>
        [Post("/WeatherForecast")]
        [Header("Content-Type", "application/json")]
        Task<bool?> PostWeatherForecastAsync([Body] WeatherForecast content);

        /// <summary>
        /// DeleteWeatherForecast (/WeatherForecast)
        /// </summary>
        /// <param name="content"></param>
        [Delete("/WeatherForecast")]
        [Header("Content-Type", "application/json")]
        Task<string> DeleteWeatherForecastAsync([Body] WeatherForecast content);

        /// <summary>
        /// PatchWeatherForecast (/WeatherForecast)
        /// </summary>
        /// <param name="content"></param>
        [Patch("/WeatherForecast")]
        [Header("Content-Type", "application/json")]
        Task<int> PatchWeatherForecastAsync([Body] WeatherForecast content);

        /// <summary>
        /// GetWeatherForecast (/WeatherForecast)
        /// </summary>
        [Get("/WeatherForecast")]
        Task<WeatherForecast[]> GetWeatherForecastAsync();
    }
}
namespace Weather.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}