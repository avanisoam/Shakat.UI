// using System;
// using System.Collections.Generic;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Threading.Tasks;
// using BlazorTasks.Client.Data;
// using BlazorTasks.Client.Models;
// using Microsoft.AspNetCore.Blazor;
// using Newtonsoft.Json;

using DaiNandani.Models;
using System.Net.Http.Json;
// using System.Net.Http.Json;

namespace DaiNandani.Services
{

	public class CategoriesService
	{
        private readonly HttpClient _httpClient;

        public CategoriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // _httpClient.BaseAddress = new Uri("http://localhost:7777/api/");
            // _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));   
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "*");
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "*");
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Max-Age", "86400");  
        }


        public async Task<ApiObjectResponse<Category>> CreateCategory(CategoryForm form)
        {
            try
            {
                var categoryFormObj = new Category
                {
                    Name = form.Name,
                    Color = form.Color
                };
                var response = await _httpClient.PostAsJsonAsync<Category>("https://localhost:44354/api/Categories", categoryFormObj);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ApiObjectResponse<Category>);
                    }

                    return await response.Content.ReadFromJsonAsync<ApiObjectResponse<Category>>();

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
            // return await _httpClient.ApiPostAsync<Category>("categories", form);
           // return null;
        }

        public async Task<ApiResponse> UpdateCategory(Category category)
        {
            //try
            //{

            //    var response = await _httpClient.PutAsJsonAsync($"https://localhost:44354/api/Categories/{category.Id}", category);

            //    return response;

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
            // return await _httpClient.ApiUpdateAsync($"categories/{category.Id}", category);
            return null;
        }

        public async Task<Collection<Category>> GetCategories()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Collection<Category>>("https://localhost:44354/api/Categories");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
            // return await _httpClient.GetJsonAsync<Collection<Category>>("categories");
            //return null;
        }

		public async Task<ApiResponse> DeleteCategory(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:44354/api/Categories/{id}");

                return default(ApiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            // return await _httpClient.ApiDeleteAsync($"categories/{id}");
            //return null;
        }
	}

}