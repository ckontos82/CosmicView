using CosmicViewSharedLib.Models;
using CosmicViewSharedLib.Services.Interfaces;

namespace CosmicViewMvc.Services
{
    public class PictureService : IPictureService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public PictureService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task AddPictureAsync(Picture picture)
        {
            await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/CosmicView", picture);
        }

        public async Task<bool> DeletePictureByDateAsync(string date)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/CosmicView/{date}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Picture> GetPictureByDateAsync(string date)
        {
            return await _httpClient.GetFromJsonAsync<Picture>($"{_apiBaseUrl}/CosmicView/{date}");
        }

        public async Task<IEnumerable<Picture>> GetAllPicturesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Picture>>($"{_apiBaseUrl}/CosmicView/pictures");
        }
    }
}
