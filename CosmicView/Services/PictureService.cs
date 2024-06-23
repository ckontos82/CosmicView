using CosmicView.Models;
using CosmicView.Services.Interfaces;

namespace CosmicView.Services
{
    public class PictureService : IPictureService
    {
        private readonly ApplicationDbContext _context;

        public PictureService(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
