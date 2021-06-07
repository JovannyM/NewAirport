using System;
using BLL.Repositories;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Airplane> Airplanes { get; }
        IAirportRepository Airports { get; }
        IRepository<Model> Models { get; }
        IFlightRepository Flights { get; }
        IRepository<Ticket> Tikets { get; }
        void Save();
    }
}