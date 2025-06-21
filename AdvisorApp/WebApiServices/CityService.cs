using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices
{
    public class CityService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<City>> GetCitiesAsync()
            => await _client.GetFromJsonAsync<IEnumerable<City>>("city");

        public async Task<City> GetCityAsync(int id)
            => await _client.GetFromJsonAsync<City>($"city/{id}");

        public async Task UpdateCityAsync(City city)
        {
            var response = await _client.PutAsJsonAsync($"city/{city.CityId}", city);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateCityAsync(City city)
        {
            var response = await _client.PostAsJsonAsync($"city/", city);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCityAsync(int id)
        {
            var response = await _client.DeleteAsync($"city/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
