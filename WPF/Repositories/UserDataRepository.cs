/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using WPF.Stores;

namespace WPF.Repositories
{
    public class UserDataRepository
    {
        private readonly HttpClient _httpClient;
        public UserDataRepository(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public void SetAuthorizationHeader(string username, string password)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}")));
        }
        
        public bool CheckCredentials()
        {
            var response = _httpClient.GetAsync("api/users").Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        
        public async Task<User> Get()
        {
            var response = await _httpClient.GetAsync("api/users");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}*/
