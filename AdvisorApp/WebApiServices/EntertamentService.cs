using DatabaseLibrary.Models;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class EntertamentService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Entertament>> GetEntertainmentsAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Entertament>>("entertainment");

        public async Task<Entertament> GetEntertainmentsAsync(int id)
            => await _client.GetFromJsonAsync<Entertament>($"entertainment/{id}");

        public async Task UpdateEntertainmentsAsync(Entertament entertainment)
        {
            var response = await _client.PutAsJsonAsync($"entertainment/{entertainment.EntertamentId}", entertainment);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateEntertainmentsAsync(Entertament entertainment)
        {
            var response = await _client.PostAsJsonAsync($"entertainment/", entertainment);
            response.EnsureSuccessStatusCode();
        }

        //public async Task<IEnumerable<Entertament>> GetEntertainmentsAsyncByType(string type)
        //{
        //    var result = GetEntertainmentsAsync().Result;
        //    return await Task.FromResult(result.Where(obj => obj.EntertamentTypeId== type));
        //}

        public async Task DeleteEntertainmentsAsync(int id)
        {
            var response = await _client.DeleteAsync($"entertainment/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
