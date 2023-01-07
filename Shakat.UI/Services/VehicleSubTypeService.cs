using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class VehicleSubTypeInfoService : IVehicleSubTypeInfoService
    {
        private readonly HttpClient _httpClient;

        public VehicleSubTypeInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VehicleSubTypeInfoDto> Create(VehicleSubTypeInfoDto vehicleSubTypeDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<VehicleSubTypeInfoDto>("https://localhost:44395/api/VehicleSubTypeInfo", vehicleSubTypeDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(VehicleSubTypeInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<VehicleSubTypeInfoDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<VehicleSubTypeInfoDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/VehicleSubTypeInfo/{id}");

                return default(VehicleSubTypeInfoDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<VehicleSubTypeInfoDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<VehicleSubTypeInfoDto>>("https://localhost:44395/api/VehicleSubTypeInfo");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<VehicleSubTypeInfoDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleSubTypeInfoDto> UpdateSubType(VehicleSubTypeInfoDto vehicleSubTypeInfoDto)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/VehicleSubTypeInfo/{vehicleSubTypeInfoDto.VehicleSubTypeInfoId}", vehicleSubTypeInfoDto);

                return vehicleSubTypeInfoDto;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
