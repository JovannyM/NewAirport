using System;
using BLL.Interfaces;
using BLL.Models;
using BLL.Repositories;
using DAL.Context;

namespace BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseContext db;

        private AirplaneService airplaneService;
        private AirportService airportService;
        private TemplateService templateService;
        private FlightService flightService;
        
        public UnitOfWork(BaseContext db)
        {
            this.db = db;
        }

        public IAirplaneService Airplanes => airplaneService ??= new AirplaneService(db, this);
        public IAirportRepository Airports => airportService ??= new AirportService(db, this);
        public IService<RecurringFlightsTemplateModel> Templates => templateService ??= new TemplateService(db, this);
        public IFlightRepository Flights => flightService ??= new FlightService(db, this);

        public event EventHandler OnUpdateDbEvent;
        public void Save()
        {
            db.SaveChanges();
            OnUpdateDbEvent?.Invoke(this, new EventArgs());
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}