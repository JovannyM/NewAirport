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

        public void SetMainAirportId(int id);
        public event EventHandler OnSelectedAirport;
        public List<AirportModel> GetList(bool withoutMain);
    }

    public interface IFlightRepository : IService<FlightModel>
    {
        public string CreateFlightsByTemplate(int templateId);
        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight);
        public (bool isCreate, string message) CreateFlight(FlightModel flight);
        public (bool isCreate, string message) CheckFlights(FlightModel flight);

        public List<FlightModel> GetList(bool sortByDate);
    }

    public interface IAirplaneService : IService<AirplaneModel>
    {
        public List<AirplaneModel> GetList(bool withoutUsingAirplane);
    }
}