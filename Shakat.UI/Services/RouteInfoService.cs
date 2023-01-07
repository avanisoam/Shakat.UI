
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class RouteInfoService : IRouteInfoService
    {
        private readonly HttpClient _httpClient;

        public RouteInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RouteInfoDto> Create(RouteInfoDto routeInfoDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<RouteInfoDto>("https://localhost:44395/api/RouteInfo", routeInfoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(RouteInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<RouteInfoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<RouteInfoDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/RouteInfo/{id}");
                return default(RouteInfoDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<RouteInfoDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<RouteInfoDto>>("https://localhost:44395/api/RouteInfo");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<RouteInfoDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RouteInfoDto> Update(RouteInfoDto routeInfoDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/RouteInfo/{routeInfoDto.RouteInfoId}", routeInfoDto);
                return routeInfoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
