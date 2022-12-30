using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecastDto>> GetAllWeather();
    }
}
