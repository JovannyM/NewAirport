using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IAirportRepository : IService<AirportModel>
    {
        public AirportModel MainAirport { get; }
    }

    public interface IFlightRepository : IService<FlightModel>
    {
        public void CreateFlightsByModel(RecurringFlightsTemplateModel model);
        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight);
        
    }
}