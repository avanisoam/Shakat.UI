
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly HttpClient _httpClient;

        public ShipmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShipmentDto> Create(ShipmentDto shipmentDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ShipmentDto>("https://localhost:44395/api/Shipment", shipmentDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ShipmentDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ShipmentDto>();
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

        public async Task<ShipmentDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/Shipment/{id}");
                return default(ShipmentDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<ShipmentDto>> GetAll()
        {
            try
            {
                Console.WriteLine("https://localhost:44395/api/Shipment");
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ShipmentDto>>("https://localhost:44395/api/Shipment");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<ShipmentDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ShipmentDto> Update(ShipmentDto shipmentDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/Shipment/{shipmentDto.ShipmentId}", shipmentDto);
                return shipmentDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
