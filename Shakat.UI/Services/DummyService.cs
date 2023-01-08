
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class DummyService : IDummyService
    {
        private readonly HttpClient _httpClient;

        public DummyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DummyDto> Create(DummyDto dummyDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<DummyDto>("https://localhost:44395/api/Dummy", dummyDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(DummyDto);
                    }

                    return await response.Content.ReadFromJsonAsync<DummyDto>();
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

        public async Task<DummyDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44395/api/Dummy/{id}");
                return default(DummyDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<DummyDto>> GetAll()
        {
            try
            {
                Console.WriteLine("https://localhost:44395/api/Dummy");
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<DummyDto>>("https://localhost:44395/api/Dummy");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<DummyDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DummyDto> Update(DummyDto dummyDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:44395/api/Dummy/{dummyDto.DummyId}", dummyDto);
                return dummyDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
