using Microsoft.EntityFrameworkCore;

namespace AirSnC.Models
{
    public class ProductsDbContext:DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) :base(options)
        {

        }
        public DbSet<Products> Productss { get; set; }

        public static implicit operator ProductsDbContext?(Products? v)
        {
            throw new NotImplementedException();
        }
    }
}
