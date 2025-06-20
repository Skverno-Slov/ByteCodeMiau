using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices
{
    public class ReviewService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Review>> GetReviewsAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Review>>("review");

        public async Task<Review> GetReviewAsync(int id)
            => await _client.GetFromJsonAsync<Review>($"review/{id}");

        public async Task UpdateReviewAsync(Review review)
        {
            var response = await _client.PutAsJsonAsync($"review/{review.EntertainmentId}", review);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateReviewAsync(Review review)
        {
            var response = await _client.PostAsJsonAsync($"review/", review);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var response = await _client.DeleteAsync($"review/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
