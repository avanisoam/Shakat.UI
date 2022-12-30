using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetAllWeather()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastDto>>("https://kunba.in/WeatherForecast");
                //var response = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastDto>>("https://localhost:44395/WeatherForecast");

                return response;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
