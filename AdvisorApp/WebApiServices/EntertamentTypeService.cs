using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices
{
    internal class EntertamentTypeService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<EntertamentType>> GetEntertamentTypesAsync()
            => await _client.GetFromJsonAsync<IEnumerable<EntertamentType>>("entertamenttype");

        public async Task<EntertamentType> GetEntertamentTypeAsync(int id)
            => await _client.GetFromJsonAsync<EntertamentType>($"entertamenttype/{id}");

        public async Task UpdateEntertamentTypeAsync(EntertamentType entertamentType)
        {
            var response = await _client.PutAsJsonAsync($"entertamenttype/{entertamentType.EntertamentTypeId}", entertamentType);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateEntertamentTypeAsync(EntertamentType entertamentType)
        {
            var response = await _client.PostAsJsonAsync($"entertamenttype/", entertamentType);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEntertamentTypeAsync(int id)
        {
            var response = await _client.DeleteAsync($"entertamenttype/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}