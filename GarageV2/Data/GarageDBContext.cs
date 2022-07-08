using Microsoft.EntityFrameworkCore;

namespace GarageV2.Data
{
    public class GarageDBContext : DbContext
    {
        public GarageDBContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    }
}
