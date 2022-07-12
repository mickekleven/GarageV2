using Microsoft.EntityFrameworkCore;

namespace GarageV2.Data
{
    public class GarageDBContext : DbContext
    {
        public GarageDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Vehicle>().HasData(

                new Vehicle
                {
                    RegNr = "abc123",
                    Brand = "Volvo",
                    Model = "X90",
                    Color = "Röd",
                    VehicleType = "PersonBil",
                    Wheels = 4,
                    ArrivalTime = DateTime.Now.AddMinutes(-10)
                },

                new Vehicle
                {
                    RegNr = "abb456",
                    Brand = "Saab",
                    Model = "99",
                    Color = "Grön",
                    VehicleType = "PersonBil",
                    Wheels = 4,
                    ArrivalTime = DateTime.Now.AddMinutes(-15)
                },

                new Vehicle
                {
                    RegNr = "oPq144",
                    Brand = "Tesla",
                    Model = "Super",
                    Color = "Silver",
                    VehicleType = "PersonBil",
                    Wheels = 4,
                    ArrivalTime = DateTime.Now.AddMinutes(-2)
                },

                new Vehicle
                {
                    RegNr = "krtekl",
                    Brand = "Ford",
                    Model = "Taunus",
                    Color = "Brun",
                    VehicleType = "PersonBil",
                    Wheels = 4,
                    ArrivalTime = DateTime.Now
                },

                new Vehicle
                {
                    RegNr = "MyBike",
                    Brand = "Honda",
                    Model = "XFusion",
                    Color = "Svart",
                    VehicleType = "MotorCykel",
                    Wheels = 4,
                    ArrivalTime = DateTime.Now.AddHours(-1)
                }
            );

            base.OnModelCreating(modelBuilder);
        }




    }
}
