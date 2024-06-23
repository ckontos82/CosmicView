using CosmicView.Models;

namespace CosmicView.Services.Interfaces
{
    public interface IPictureService
    {
        Task AddPictureAsync(Picture picture);
    }
}
