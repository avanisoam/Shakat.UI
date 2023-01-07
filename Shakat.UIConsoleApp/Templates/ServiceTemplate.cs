using Shakat.UIConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakat.UIConsoleApp.Templates
{
    public class ServiceTemplate : ITemplate
    {
        public StringBuilder GetTemplate(string model, Dictionary<string, Dictionary<string, string>> keyValuePairs = null)
        {
            string dtoObject = $"{model}Dto".FirstCharToLowerCase();
            var url = $"https://localhost:44395/api/{model}";

            var primaryKey = $"{model}Id";

            StringBuilder sourceBuilder = new StringBuilder(@"");

            sourceBuilder.AppendFormat(@"
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{0}
    public class {2}Service : I{2}Service
    {0}
        private readonly HttpClient _httpClient;

        public {2}Service(HttpClient httpClient)
        {0}
            _httpClient = httpClient;
        {1}

        public async Task<{2}Dto> Create({2}Dto {3})
        {0}
            try
            {0}
                var response = await _httpClient.PostAsJsonAsync<{2}Dto>(""{4}"", {3});

                if (response.IsSuccessStatusCode)
                {0}
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {0}
                        return default({2}Dto);
                    {1}

                    return await response.Content.ReadFromJsonAsync<{2}Dto>();
                {1}
                else
                {0}
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($""Http status:{0}response.StatusCode{1} Message -{0}message{1}"");
                {1}
            {1}
            catch (Exception ex)
            {0}
                Console.WriteLine(ex.Message);
                throw;
            {1}
        {1}

        public async Task<{2}Dto> Delete(int id)
        {0}
            try
            {0}
                var response = await _httpClient.DeleteAsync($""{4}/{0}id{1}"");
                return default({2}Dto);
            {1}
            catch (Exception ex)
            {0}
                Console.WriteLine(ex.Message);
                throw;
            {1}
        {1}

        public async Task<IEnumerable<{2}Dto>> GetAll()
        {0}
            try
            {0}
                Console.WriteLine(""{4}"");
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<{2}Dto>>(""{4}"");
                return response;
            {1}
            catch (Exception ex)
            {0}
                Console.WriteLine(ex.Message);
                throw;
            {1}
        {1}

        public Task<{2}Dto> GetById(int id)
        {0}
            throw new NotImplementedException();
        {1}

        public async Task<{2}Dto> Update({2}Dto {3})
        {0}
            try
            {0}
                var response = await _httpClient.PutAsJsonAsync($""{4}/{0}{3}.{2}Id{1}"", {3});
                return {3};
            {1}
            catch (Exception ex)
            {0}
                Console.WriteLine(ex.Message);
                throw;
            {1}
        {1}
    {1}
{1}
", "{", "}", model, dtoObject, url, primaryKey);

            return sourceBuilder;
        }
    }
}
