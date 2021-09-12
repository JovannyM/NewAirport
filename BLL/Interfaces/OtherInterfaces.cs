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
        public void CreateFlightsByTemplate(int templateId);
        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight);
        
    }
}