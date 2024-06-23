using CosmicView.Models;
using CosmicView.Services.Interfaces;
using CosmicViewSharedLib.Models;
using System.Text.Json;

namespace CosmicView.Services
{
    public class CosmicViewApiService : ICosmicViewApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public CosmicViewApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration["NasaApiSettings:BaseUrl"];
            _apiKey = _configuration["NasaApiSettings:ApiKey"];
        }

        public async Task<List<Picture>> GetPictureAsync(QueryParams queryParams)
        {
            var queryDictionary = new Dictionary<string, string>
            {
                { "api_key", _apiKey },
                { "date", queryParams.Date },
                { "start_date", queryParams.StartDate },
                { "end_date", queryParams.EndDate },
                { "count", queryParams.Count?.ToString() },
                { "thumbs", queryParams.Thumbs ? "true" : null }
            };

            var query = string.Join("&", queryDictionary
                .Where(kv => !string.IsNullOrEmpty(kv.Value))
                .Select(kv => $"{kv.Key}={kv.Value}"));

            var response = await _httpClient.GetAsync($"{_baseUrl}apod?{query}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var pictureResponse = new PictureResponse();

            try
            {
                pictureResponse.SinglePicture = JsonSerializer.Deserialize<Picture>(content);
            }
            catch
            {
                pictureResponse.Pictures = JsonSerializer.Deserialize<List<Picture>>(content);
            }

            return pictureResponse.GetPictures();
        }
    }
}
