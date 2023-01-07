using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class VehicleTypeInfoService : IVehicleTypeInfoService
    {
        private readonly HttpClient _httpClient;

        public VehicleTypeInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<VehicleTypeInfoDto> Create(VehicleTypeInfoDto vehicleTypeInfoDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<VehicleTypeInfoDto>("https://localhost:44395/api/VehicleTypeInfo", vehicleTypeInfoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(VehicleTypeInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<VehicleTypeInfoDto>();

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

        public async Task<VehicleTypeInfoDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/VehicleTypeInfo/{id}");

                return default(VehicleTypeInfoDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<VehicleTypeInfoDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<VehicleTypeInfoDto>>("https://localhost:44395/api/VehicleTypeInfo");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<VehicleTypeInfoDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleTypeInfoDto> UpdateSubType(VehicleTypeInfoDto vehicleTypeInfoDto)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/VehicleTypeInfo/{vehicleTypeInfoDto.VehicleTypeInfoId}", vehicleTypeInfoDto);

                return vehicleTypeInfoDto;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
