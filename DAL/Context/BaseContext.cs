using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class BaseContext : DbContext
    {
        private const string BaseName = "NEWAIRPORT";

        public BaseContext() : base(BaseName)
        {
            Database.SetInitializer(new NewAirportInitializer());
        }
        
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Airport>().ToTable("Airports");
            modelBuilder.Entity<Airplane>().ToTable("Airplanes");
            modelBuilder.Entity<Model>().ToTable("Models");
        }
    }
}