using System;
using BLL.Repositories;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Airplane> Airplanes { get; }
        IRepository<Airport> Airports { get; }
        IRepository<Model> Models { get; }
        IRepository<Flight> Flights { get; }
        IRepository<Ticket> Tikets { get; }
        void Save();
    }
}