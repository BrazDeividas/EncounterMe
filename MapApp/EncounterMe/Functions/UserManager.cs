using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EncounterMe.Functions
{
    public interface IUserManager
    {
        Task<User?> Authenticate(Credentials credentials);
        User? CurrentUser(string token);
    }
    public class UserManager: IUserManager
    {
        private readonly HttpClient _httpClient;

        public UserManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User?> Authenticate(Credentials credentials)
        {
            var json = JsonConvert.SerializeObject(credentials);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/User/authenticate", data);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            return null;
        }

        public User? CurrentUser(string token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = _httpClient.GetAsync("api/User").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User>(content);
            }
            return null;
        }
    }
}
