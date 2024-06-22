using System.Text.Json.Serialization;

namespace CosmicView.Models
{
    public class Picture
    {
        public Guid Id { get; set; }
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }

        [JsonPropertyName("hdurl")]
        public string Hdurl { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }

        [JsonPropertyName("service_version")]
        public string ServiceVersion { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}
