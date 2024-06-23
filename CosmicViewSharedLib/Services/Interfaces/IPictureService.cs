using CosmicViewSharedLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicViewSharedLib.Services.Interfaces
{
    public interface IPictureService
    {
        Task AddPictureAsync(Picture picture);
        Task<bool> DeletePictureByDateAsync(string date);
        Task<Picture> GetPictureByDateAsync(string date);
        Task<IEnumerable<Picture>> GetAllPicturesAsync();
    }
}
