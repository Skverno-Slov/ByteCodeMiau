using DatabaseLibrary.Models;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class GamesService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Game>> GetGamesAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Game>>("games");

        public async Task<Game> GetGameAsync(int id)
            => await _client.GetFromJsonAsync<Game>($"games/{id}");

        public async Task UpdateGameAsync(Game game)
        {
            var response = await _client.PutAsJsonAsync($"games/{game.Id}", game);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateGameAsync(Game game)
        {
            var response = await _client.PostAsJsonAsync($"games/", game);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGameAsync(int id)
        {
            var response = await _client.DeleteAsync($"games/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
