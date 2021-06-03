using System;
using BLL.Interfaces;
using BLL.Repositories;
using DAL.Context;
using DAL.Entities;

namespace BLL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseContext DB;

        private AirplaneRepos AirplaneRepos;
        private AirportRepos AirportRepos;
        private ModelRepos ModelRepos;
        private FlightRepos FlightRepos;
        private TicketRepos TicketRepos;
        
        public UnitOfWork(BaseContext db)
        {
            DB = db;
        }

        public IRepository<Airplane> Airplanes { get; } 
        public IRepository<Airport> Airports { get; }
        public IRepository<Model> Models { get; }
        public IRepository<Flight> Flights { get; }
        public IRepository<Ticket> Tikets { get; }
        public void Save()
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            DB.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}