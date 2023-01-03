using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class VehicleSubTypeService : IVehicleSubTypeService
    {
        private readonly HttpClient _httpClient;

        public VehicleSubTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VehicleSubTypeDto> Create(VehicleSubTypeDto vehicleSubTypeDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<VehicleSubTypeDto>("https://localhost:44395/api/VehicleSubTypeInfo", vehicleSubTypeDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(VehicleSubTypeDto);
                    }

                    return await response.Content.ReadFromJsonAsync<VehicleSubTypeDto>();

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

        public async Task<VehicleSubTypeDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/VehicleSubTypeInfo/{id}");

                return default(VehicleSubTypeDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<VehicleSubTypeDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<VehicleSubTypeDto>>("https://localhost:44395/api/VehicleSubTypeInfo");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<VehicleSubTypeDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleSubTypeDto> UpdateSubType(VehicleSubTypeDto vehicleSubTypeDto)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/VehicleSubTypeInfo/{vehicleSubTypeDto.VehicleSubTypeInfoId}", vehicleSubTypeDto);

                return vehicleSubTypeDto;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
