using CosmicView.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmicView
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Picture> Pictures { get; set; }
    }
}
