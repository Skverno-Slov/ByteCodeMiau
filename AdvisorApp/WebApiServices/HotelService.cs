using DatabaseLibrary.Models;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class HotelService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Entertainment>> GetGamesAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Entertainment>>("entertainment");

        public async Task<Entertainment> GetGameAsync(int id)
            => await _client.GetFromJsonAsync<Entertainment>($"entertainment/{id}");

        public async Task UpdateGameAsync(Entertainment entertainment)
        {
            var response = await _client.PutAsJsonAsync($"entertainment/{entertainment.EntertainmentId}", entertainment);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateGameAsync(Entertainment entertainment)
        {
            var response = await _client.PostAsJsonAsync($"entertainment/", entertainment);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGameAsync(int id)
        {
            var response = await _client.DeleteAsync($"entertainment/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
