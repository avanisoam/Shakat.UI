using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class ProductCategoryInfoService : IProductCategoryInfoService
    {
        private readonly HttpClient _httpClient;

        public ProductCategoryInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductCategoryInfoDto> Create(ProductCategoryInfoDto productCategoryInfoDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ProductCategoryInfoDto>("https://localhost:44395/api/ProductCategoryInfo", productCategoryInfoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductCategoryInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ProductCategoryInfoDto>();

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

        public async Task<ProductCategoryInfoDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/ProductCategoryInfo/{id}");

                return default(ProductCategoryInfoDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductCategoryInfoDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductCategoryInfoDto>>("https://localhost:44395/api/ProductCategoryInfo");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductCategoryInfoDto> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ProductCategoryInfoDto>($"https://localhost:44395/api/ProductCategoryInfo/{id}");
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ProductCategoryInfoDto> Update(ProductCategoryInfoDto productCategoryInfoDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/ProductCategoryInfo/{productCategoryInfoDto.ProductCategoryInfoId}", productCategoryInfoDto);

                return productCategoryInfoDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
