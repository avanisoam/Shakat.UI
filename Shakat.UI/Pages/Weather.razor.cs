using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages
{
    public partial class Weather
    {
        [Inject]
        public IWeatherService WeatherService { get; set; }

        public IEnumerable<WeatherForecastDto>? Weathers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Weathers = await WeatherService.GetAllWeather();
        }
    }
}
