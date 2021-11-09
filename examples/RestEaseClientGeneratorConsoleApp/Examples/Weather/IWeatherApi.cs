using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        [Post("/WeatherForecast")]
        Task<bool?> PostWeatherForecastAsync();

        /// <summary>
        /// DeleteWeatherForecast (/WeatherForecast)
        /// </summary>
        [Delete("/WeatherForecast")]
        Task<string> DeleteWeatherForecastAsync();

        /// <summary>
        /// PatchWeatherForecast (/WeatherForecast)
        /// </summary>
        [Patch("/WeatherForecast")]
        Task<int> PatchWeatherForecastAsync();

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
