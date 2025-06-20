using DatabaseLibrary.Models;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class EntertainmentService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Entertainment>> GetEntertainmentsAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Entertainment>>("entertainment");

        public async Task<Entertainment> GetEntertainmentsAsync(int id)
            => await _client.GetFromJsonAsync<Entertainment>($"entertainment/{id}");

        public async Task UpdateEntertainmentsAsync(Entertainment entertainment)
        {
            var response = await _client.PutAsJsonAsync($"entertainment/{entertainment.EntertainmentId}", entertainment);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateEntertainmentsAsync(Entertainment entertainment)
        {
            var response = await _client.PostAsJsonAsync($"entertainment/", entertainment);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Entertainment>> GetEntertainmentsAsyncByType(string type)
        {
            var result = GetEntertainmentsAsync().Result;
            return await Task.FromResult(result.Where(obj => obj.EntertainmentType == type));
        }

        public async Task DeleteEntertainmentsAsync(int id)
        {
            var response = await _client.DeleteAsync($"entertainment/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
