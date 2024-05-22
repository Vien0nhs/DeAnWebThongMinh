using DeAnWebThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace DeAnWebThongMinh.Data
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }
    }
}
