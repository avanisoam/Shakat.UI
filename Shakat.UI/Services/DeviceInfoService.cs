using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class DeviceInfoService : IDeviceInfoService
    {
        private readonly HttpClient _httpClient;

        public DeviceInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DeviceInfoDto> Create(DeviceInfoDto deviceInfoDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<DeviceInfoDto>("https://localhost:44395/api/DeviceInfo", deviceInfoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(DeviceInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<DeviceInfoDto>();
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

        public async Task<DeviceInfoDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/DeviceInfo/{id}");
                return default(DeviceInfoDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<DeviceInfoDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<DeviceInfoDto>>("https://localhost:44395/api/DeviceInfo");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<DeviceInfoDto> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DeviceInfoDto>($"https://localhost:44395/api/DeviceInfo/{id}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<DeviceInfoDto> Update(DeviceInfoDto deviceInfoDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/DeviceInfo/{deviceInfoDto.DeviceInfoId}", deviceInfoDto);
                return deviceInfoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
