using System.Text.Json.Serialization;

namespace api_red_social.Models
{
    public class GetUserDTO
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("public_repos")]
        public int PublicRepos { get; set; }

        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        [JsonPropertyName("following")]
        public int Following { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
    }
}
