/*using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace WPF.Repositories
{
    public class ActivityDataRepository
    {
        private HttpClient _httpClient;
        public ActivityDataRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Activity>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/activities");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Activity>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async void Post()
        {

        }
    }
}*/