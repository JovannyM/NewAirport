using System;
using System.Data.Entity;
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

        public IRepository<Airplane> Airplanes => AirplaneRepos ??= new AirplaneRepos(DB);
        public IRepository<Airport> Airports => AirportRepos ??= new AirportRepos(DB);
        public IRepository<Model> Models => ModelRepos ??= new ModelRepos(DB);
        public IRepository<Flight> Flights => FlightRepos ??= new FlightRepos(DB);
        public IRepository<Ticket> Tikets => TicketRepos ??= new TicketRepos(DB);
        public void Save()
        {
            DB.SaveChanges();
        }
        public void Dispose()
        {
            DB.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}