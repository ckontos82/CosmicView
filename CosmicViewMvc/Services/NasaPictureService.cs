using CosmicViewSharedLib.Models;
using CosmicViewSharedLib.Services.Interfaces;

namespace CosmicViewMvc.Services
{
    public class NasaPictureService : IPictureService
    {
        Task IPictureService.AddPictureAsync(Picture picture)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPictureService.DeletePictureByDateAsync(string date)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Picture>> IPictureService.GetAllPicturesAsync()
        {
            throw new NotImplementedException();
        }

        Task<Picture> IPictureService.GetPictureByDateAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
