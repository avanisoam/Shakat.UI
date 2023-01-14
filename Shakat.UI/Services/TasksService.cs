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

	public class TasksService
	{
        private readonly HttpClient _httpClient;

        public TasksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // _httpClient.BaseAddress = new Uri("http://localhost:7777/api/");
            // _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));   
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "*");
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "*");
            // _httpClient.DefaultRequestHeaders.Add("Access-Control-Max-Age", "86400");  
        }

        public async Task<ApiObjectResponse<TodoTask>> GetTask(string taskId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiObjectResponse<TodoTask>>($"https://localhost:44354/api/Tasks/{taskId}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
            //return await _httpClient.ApiGetAsync<TodoTask>($"tasks/{taskId}");
            //return null;
        }

        public async Task<ApiObjectResponse<Collection<TodoTask>>> GetTasks(Category filterByCategory = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (filterByCategory != null)
            {
                queryParams.Add("search", $"categoryid eq {filterByCategory.Id}");
            }
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiObjectResponse<Collection<TodoTask>>>($"https://localhost:44354/api/Tasks");
                //var response = await _httpClient.GetFromJsonAsync < ApiObjectResponse<Collection<TodoTask>>($"https://localhost:44354/api/Tasks");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
            // return await _httpClient.ApiGetAsync<Collection<TodoTask>>("tasks", queryParams);
            //return null;
        }

        public async Task<ApiObjectResponse<TodoTask>> CreateTask(TodoTaskForm form)
        {
            // return await _httpClient.ApiPostAsync<TodoTask>("tasks", form);
            return null;
        }

		public async Task<ApiResponse> DeleteTask(string id)
        {
            // return await _httpClient.ApiDeleteAsync($"tasks/{id}");
            return null;
        }

		// public async Task UpdateTask(TodoTask task)
        // {
        //     // await _httpClient.PutJsonAsync($"tasks/{task.Id}", task);
        //     return await Task.Delay(0);
        // }
	}

}