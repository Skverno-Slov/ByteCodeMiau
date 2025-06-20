using DatabaseLibrary.Models;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class HotelService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Hotel>> GetGamesAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Hotel>>("hotel");

        public async Task<Hotel> GetGameAsync(int id)
            => await _client.GetFromJsonAsync<Hotel>($"hotel/{id}");

        public async Task UpdateGameAsync(Hotel hotel)
        {
            var response = await _client.PutAsJsonAsync($"hotel/{hotel.HotelId}", hotel);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateGameAsync(Hotel hotel)
        {
            var response = await _client.PostAsJsonAsync($"hotel/", hotel);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGameAsync(int id)
        {
            var response = await _client.DeleteAsync($"hotel/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
