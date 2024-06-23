using CosmicView.Models;

namespace CosmicView.Services.Interfaces
{
    public interface ICosmicViewApiService
    {
        Task<List<Picture>> GetPictureAsync(QueryParams queryParams);
    }
}
