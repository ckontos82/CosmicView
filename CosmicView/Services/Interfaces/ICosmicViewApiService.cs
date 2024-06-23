using CosmicView.Models;
using CosmicViewSharedLib.Models;

namespace CosmicView.Services.Interfaces
{
    public interface ICosmicViewApiService
    {
        Task<List<Picture>> GetPictureAsync(QueryParams queryParams);
    }
}
