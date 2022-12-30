using Shakat.UI.Services.Contracts;
using System.Net.Http.Json;

namespace Shakat.UI.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        private readonly HttpClient _httpClient;

        public HelloWorldService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetString()
        {
            // https://jasonwatmore.com/post/2020/09/20/blazor-webassembly-http-get-request-examples

            using var httpResponse = await _httpClient.GetAsync("https://localhost:44395/api/HelloWorld");

            if (!httpResponse.IsSuccessStatusCode)
            {
                // set error message for display, log to console and return
                var errorMessage = httpResponse.ReasonPhrase;
                Console.WriteLine($"There was an error! {errorMessage}");
                
                return null;
            }

            // convert http response data to UsersResponse object
            var response = await httpResponse.Content.ReadAsStringAsync();

            return response;
        }
    }
}
