using System;
using System.Collections.Generic;
using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IAirportRepository : IService<AirportModel>
    {
        public AirportModel MainAirport { get; }
        public int TimeBetweenFlights { get; }
        public List<AirportModel> GetListWithoutMain();
        public void SetMainAirportId(int id);
        public event EventHandler OnSelectedAirport;
    }

    public interface IFlightRepository : IService<FlightModel>
    {
        public void CreateFlightsByTemplate(int templateId);
        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight);
        public (bool isCreate, string message) CreateFlight(FlightModel flight);
        public (bool isCreate, string message) CheckFlights(FlightModel flight);

    }
}