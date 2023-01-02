using Shakat.Shared.Models.RequestModels;
using Shakat.Shared.Models.ResponseModels;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class LogisticsOrderService : ILogisticsOrderService
    {
        private readonly HttpClient _httpClient;

        public LogisticsOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LogisticsOrderRequestDto> CreateLogisticOrder(LogisticsOrderRequestDto logisticsOrderRequestDto)
        {
            try
            {
                //logisticsOrderRequestDto = new LogisticsOrderRequestDto
                //{
                //    CustomerId = 1,
                //    ProductId = 2,
                                    //    //Quantity = 40,
                                    //    //Price = 1000,
                                    //    //ShippingAddress = "chennai",
                                    //    //OrderStatus = "Placed",
                //    SourceCity = "Bhiwani",
                //    DestinationCity = "Gurgaon",
                //    WeightInKg = 10000,
                //    VehicleSubTypeId = 1,
                //    MaterialTypeId = 2,
                //    ScheduledDate = new DateTime(1984, 1, 30)
                //};

                var request = await _httpClient.PostAsJsonAsync<LogisticsOrderRequestDto>("https://localhost:44395/api/LogisticOrders", logisticsOrderRequestDto);

                if (request.IsSuccessStatusCode)
                {
                    if (request.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(LogisticsOrderRequestDto);
                    }

                    return await request.Content.ReadFromJsonAsync<LogisticsOrderRequestDto>();

                }
                else
                {
                    var message = await request.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{request.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<LogisticsOrderResponseDto>> GetAllLogisticsOrders()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<LogisticsOrderResponseDto>>("https://localhost:44395/api/LogisticOrders");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
