using System;
using BLL.Repositories;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Airplane> Airplanes { get; }
        IAirportRepository Airports { get; }
        IRepository<RecurringFlightsTemplate> Models { get; }
        IFlightRepository Flights { get; }
        event EventHandler OnUpdateDbEvent;
        void Save();
    }
}