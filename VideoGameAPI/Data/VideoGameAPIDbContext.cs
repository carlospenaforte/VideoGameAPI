using Microsoft.EntityFrameworkCore;
using VideoGameAPI.Models;

namespace VideoGameAPI.Data
{
    public class VideoGameAPIDbContext : DbContext
    {
        public VideoGameAPIDbContext(DbContextOptions<VideoGameAPIDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
