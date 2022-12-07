/*using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace WPF.Repositories
{
    public class ProjectDataRepository
    {
        private HttpClient _httpClient;
        public ProjectDataRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/projects");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Project>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}*/