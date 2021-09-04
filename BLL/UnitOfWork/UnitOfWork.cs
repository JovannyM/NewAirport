using System;
using System.Data.Entity;
using BLL.Interfaces;
using BLL.Repositories;
using DAL.Context;
using DAL.Entities;

namespace BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseContext db;

        private AirplaneRepos airplaneRepos;
        private AirportRepos airportRepos;
        private ModelRepos modelRepos;
        private FlightRepos flightRepos;
        private TicketRepos ticketRepos;
        
        public UnitOfWork(BaseContext db)
        {
            this.db = db;
        }

        public IRepository<Airplane> Airplanes => airplaneRepos ??= new AirplaneRepos(db);
        public IAirportRepository Airports => airportRepos ??= new AirportRepos(db);
        public IRepository<Model> Models => modelRepos ??= new ModelRepos(db, this);
        public IFlightRepository Flights => flightRepos ??= new FlightRepos(db, this);
        public IRepository<Ticket> Tikets => ticketRepos ??= new TicketRepos(db);

        public event EventHandler OnUpdateDbEvent;
        public void Save()
        {
            db.SaveChanges();
            OnUpdateDbEvent.Invoke(this, new EventArgs());
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}