using api_red_social.Models;
using System.Text.Json;

namespace api_red_social.Services {
    public class RepoService {
        private readonly HttpClient _httpClient;

        public RepoService(HttpClient httpClient) {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
        }

        public async Task<List<GetRepoDTO>?> GetReposByUser(string username) {
            var response = await _httpClient.GetAsync(
                $"https://api.github.com/users/{username}/repos"
            );

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<GetRepoDTO>>(
                json,
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
