using CosmicView.Models;

namespace CosmicView.Services
{
    public interface ICosmicViewApiService
    {
        Task<List<Picture>> GetPictureAsync(QueryParams queryParams);
    }
}
