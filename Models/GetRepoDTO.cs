namespace api_red_social.Models {
    public class GetRepoDTO {
        public string Name { get; set; }
        public string Html_Url { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int Stargazers_Count { get; set; }
        public int Forks_Count { get; set; }
    }
}
