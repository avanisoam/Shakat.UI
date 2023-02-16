using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class DeviceHistoryService : IDeviceHistoryService
    {
        private readonly HttpClient _httpClient;

        public DeviceHistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DeviceHistoryDto> Create(DeviceHistoryDto deviceHistoryDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<DeviceHistoryDto>("https://localhost:44395/api/DeviceHistory", deviceHistoryDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(DeviceHistoryDto);
                    }

                    return await response.Content.ReadFromJsonAsync<DeviceHistoryDto>();
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

        public async Task<DeviceHistoryDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/DeviceHistory/{id}");
                return default(DeviceHistoryDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<DeviceHistoryDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<DeviceHistoryDto>>("https://localhost:44395/api/DeviceHistory");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<DeviceHistoryDto> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DeviceHistoryDto>($"https://localhost:44395/api/DeviceHistory/{id}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<DeviceHistoryDto> Update(DeviceHistoryDto deviceHistoryDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/DeviceHistory/{deviceHistoryDto.DeviceHistoryId}", deviceHistoryDto);
                return deviceHistoryDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
