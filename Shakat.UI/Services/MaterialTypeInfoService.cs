using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class MaterialTypeInfoService : IMaterialTypeInfoService
    {
        private readonly HttpClient _httpClient;

        public MaterialTypeInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<MaterialTypeInfoDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<MaterialTypeInfoDto>>("https://localhost:44395/api/MaterialTypeInfo");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
