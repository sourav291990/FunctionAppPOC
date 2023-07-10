using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTopicFunction.Infrastructure
{
    public class ApiRepository : IApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;

        public ApiRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiEndpoint = configuration["ApiEndpoint"];
        }

        public async Task PostEventAsync(string message)
        {
            try
            {
                var content = new StringContent(message, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiEndpoint, content);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the HTTP request
            }
        }
    }
}
