using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly HttpClient _httpClient;

        public VehicleTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<VehicleTypeDto> Create(VehicleTypeDto vehicleTypeDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<VehicleTypeDto>("https://localhost:44395/api/VehicleTypeInfo", vehicleTypeDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(VehicleTypeDto);
                    }

                    return await response.Content.ReadFromJsonAsync<VehicleTypeDto>();

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

        public async Task<VehicleTypeDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/VehicleTypeInfo/{id}");

                return default(VehicleTypeDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<VehicleTypeDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<VehicleTypeDto>>("https://localhost:44395/api/VehicleTypeInfo");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<VehicleTypeDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleTypeDto> UpdateSubType(VehicleTypeDto vehicleTypeDto)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/VehicleTypeInfo/{vehicleTypeDto.VehicleTypeInfoId}", vehicleTypeDto);

                return vehicleTypeDto;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
