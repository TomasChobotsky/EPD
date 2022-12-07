/*using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace WPF.Repositories
{
    public class CustomerDataRepository
    {
        private HttpClient _httpClient;
        public CustomerDataRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/customers");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Customer>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}*/