using System.Text.Json.Serialization;

namespace api_red_social.Models
{
    public class FollowingDTO
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("HtmlUrl")]
        public string HtmlUrl { get; set; }
    }
}
