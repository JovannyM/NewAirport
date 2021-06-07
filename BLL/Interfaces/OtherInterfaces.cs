using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IAirportRepository : IRepository<Airport>
    {
        public Airport MainAirport { get; }
    }

    public interface IFlightRepository : IRepository<Flight>
    {
        public void CreateFlightsByModel(Model model);
    }
}