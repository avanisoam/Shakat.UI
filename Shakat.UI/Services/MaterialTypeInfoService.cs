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

        public async Task<MaterialTypeInfoDto> Create(MaterialTypeInfoDto materialTypeInfoDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<MaterialTypeInfoDto>("https://localhost:44395/api/MaterialTypeInfo", materialTypeInfoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(MaterialTypeInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<MaterialTypeInfoDto>();

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

        public async Task<MaterialTypeInfoDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/MaterialTypeInfo/{id}");

                return default(MaterialTypeInfoDto);
            }
            catch (Exception)
            {

                throw;
            }
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

        public async Task<MaterialTypeInfoDto> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<MaterialTypeInfoDto>($"https://localhost:44395/api/MaterialTypeInfo/{id}");
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<MaterialTypeInfoDto> Update(MaterialTypeInfoDto materialTypeInfoDto)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/materialTypeInfo/{materialTypeInfoDto.MaterialTypeInfoId}", materialTypeInfoDto);

                return materialTypeInfoDto;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
