using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Users.Model;
using VectoVia.Models.Users;
using VectoVia_LabCourse.Models.KompaniaTaxi.Model;

namespace VectoVia_LabCourse.Models.KompaniaTaxi.Model;

public class KompaniaTaxisDbContext : DbContext
{
    public KompaniaTaxisDbContext(DbContextOptions<KompaniaTaxisDbContext> options) : base(options)
    {
    }

    public DbSet<KompaniaTaxi> KompaniaTaxis { get; set; }
}

