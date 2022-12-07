using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace WPF.Services
{
    public class ApiAuthRepository
    {
        private string _username;
        private string _password;
        public void SetAuthorizationHeader(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public bool CheckCredentials(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string apiUrl = "https://localhost:5001/" + url;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{_username}:{_password}")));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            
            return false;
        }
        public async Task<T> Get<T>(string url) where T : IEntity
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string apiUrl = "https://localhost:5001/" + url;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{_username}:{_password}")));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(apiUrl);
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public Task<HttpResponseMessage> Post<T>(string url, T model) where T : IEntity
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string apiUrl = "https://localhost:5001/" + url;
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync(apiUrl, model);
                response.Wait();
                return response;
            }
        }

        public Task<HttpResponseMessage> Put<T>(string url, T model) where T : IEntity
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string apiUrl = "https://localhost:5001/" + url;
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{_username}:{_password}")));
                client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PutAsJsonAsync(apiUrl, model);
                response.Wait();
                return response;
            }
        }
        
        public Task<HttpResponseMessage> Delete(string url)   
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;  
            string apiUrl = "https://localhost:5001/" + url;
            
            using (HttpClient client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiUrl);  
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{_username}:{_password}")));
                client.Timeout = TimeSpan.FromSeconds(900);  
                client.DefaultRequestHeaders.Accept.Clear();  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
                var response = client.DeleteAsync(apiUrl);  
                response.Wait();  
                return response;  
            }
        } 
    }
}
