using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class BaseContext : DbContext
    {
        private const string Connect = "NewAirport";
        public BaseContext() : base(Connect)
        {
            Database.SetInitializer(new NewAirportInitializer());
        }
        
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<RecurringFlightsTemplate> RecurringFlightsTemplates { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Airport>().ToTable("Airports");
            modelBuilder.Entity<Airplane>().ToTable("Airplanes");
            modelBuilder.Entity<RecurringFlightsTemplate>().ToTable("RecurringFlightsTemplates");
            modelBuilder.Entity<Flight>().ToTable("Flights");
        }
    }
}