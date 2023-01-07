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
        public StringBuilder GetTemplate(string dto, string service = "", string serviceUrl = "", string primaryKey = "")
        {
            string dtoObject = dto.FirstCharToLowerCase();

            StringBuilder sourceBuilder = new StringBuilder(@"");

            sourceBuilder.AppendFormat(@"
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{0}
    public class {3} : I{3}
    {0}
        private readonly HttpClient _httpClient;

        public {3}(HttpClient httpClient)
        {0}
            _httpClient = httpClient;
        {1}

        public async Task<{2}> Create({2} {4})
        {0}
            try
            {0}
                var response = await _httpClient.PostAsJsonAsync<{2}>(""{5}"", {4});

                if (response.IsSuccessStatusCode)
                {0}
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {0}
                        return default({2});
                    {1}

                    return await response.Content.ReadFromJsonAsync<{2}>();

                {1}
                else
                {0}
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($""Http status:{0}response.StatusCode{1} Message -{0}message{1}"");
                {1}
            {1}
            catch (Exception)
            {0}

                throw;
            {1}
        {1}

        public async Task<{2}> Delete(int id)
        {0}
            try
            {0}
                var response = await _httpClient.DeleteAsync($""{5}/{0}id{1}"");

                return default({2});
            {1}
            catch (Exception)
            {0}

                throw;
            {1}
        {1}

        public async Task<IEnumerable<{2}>> GetAll()
        {0}
            try
            {0}
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<{2}>>(""{5}"");
                return response;
            {1}
            catch (Exception)
            {0}

                throw;
            {1}
        {1}

        public Task<{2}> GetById(int id)
        {0}
            throw new NotImplementedException();
        {1}

        public async Task<{2}> Update({2} {4})
        {0}
            try
            {0}

                var response = await _httpClient.PutAsJsonAsync($""{5}/{0}{4}.{6}{1}"", {4});

                return {4};

            {1}
            catch (Exception ex)
            {0}

                throw;
            {1}
        {1}
    {1}
{1}
", "{", "}", dto, service, dtoObject, serviceUrl, primaryKey);

            return sourceBuilder;
        }
    }
}
