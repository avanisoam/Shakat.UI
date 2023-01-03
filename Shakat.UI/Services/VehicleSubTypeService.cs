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

        public Task<VehicleSubTypeDto> Create(VehicleSubTypeDto vehicleSubTypeDto)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleSubTypeDto> Delete(VehicleSubTypeDto vehicleSubTypeDto)
        {
            throw new NotImplementedException();
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

        public Task<VehicleSubTypeDto> UpdateSubType(VehicleSubTypeDto vehicleSubTypeDto)
        {
            throw new NotImplementedException();
        }
    }
}
