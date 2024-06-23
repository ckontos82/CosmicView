using CosmicView.Models;
using CosmicView.Services.Interfaces;
using CosmicViewSharedLib.Models;
using CosmicViewSharedLib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CosmicView.Services
{
    public class PictureService : IPictureService
    {
        private readonly ApplicationDbContext _context;

        public PictureService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Picture> GetPictureByDateAsync(string date)
        {
            return await _context.Pictures.FirstOrDefaultAsync(p => p.Date == date);
        }

        public async Task<IEnumerable<Picture>> GetAllPicturesAsync()
        {
            return await _context.Pictures.ToListAsync();
        }

        public async Task AddPictureAsync(Picture picture)
        {
            if (picture.Id == Guid.Empty)
            {
                picture.Id = Guid.NewGuid();
            }

            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePictureByDateAsync(string date)
        {
            var picture = await _context.Pictures.FirstOrDefaultAsync(p => p.Date == date);

            if (picture is null)
                return false;
           
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
            return true;       
        }
    }
}
