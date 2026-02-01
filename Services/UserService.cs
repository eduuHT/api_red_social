namespace api_red_social.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        public UserService(IConfiguration configuration )
        {
            var baseAddress = configuration["GitHub:BaseUrl"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
        public async Task<string> GetUserAsync(string username)
        {
            var response = await _httpClient.GetAsync($"/users/{username}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
