using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Cars.Model;

namespace VectoVia.Models.Cars
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {

        }

        public DbSet<Car> CarsDB { get; set; }
    }
}
