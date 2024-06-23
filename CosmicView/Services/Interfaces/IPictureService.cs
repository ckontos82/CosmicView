using CosmicView.Models;

namespace CosmicView.Services.Interfaces
{
    public interface IPictureService
    {
        Task AddPictureAsync(Picture picture);
        Task<bool> DeletePictureByDateAsync(string date);
        Task<Picture> GetPictureByDateAsync(string date);
        Task<IEnumerable<Picture>> GetAllPicturesAsync();
    }
}
